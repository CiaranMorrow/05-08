using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class media_stock : Form
    {
        MySqlConnection dbconnection;
        int count = 0;
               
        public media_stock()
        {
            InitializeComponent(); // initialises the design 

        }
        
        private void media_stock_Load(object sender, EventArgs e)
        {
            try
            {
                // connects to the db when the the pagfe loads
                dbconnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=;");
                {
                    if (dbconnection.State == ConnectionState.Closed)
                    {
                        dbconnection.Open();
                    }
                }
            }
            catch (SqlException exceptt)
            {
                
                throw (exceptt);
            }
            fill_media_info(); // fills the media table using the method below, does this as soon as the table loads so the user can see the media stock

        }

        public void fill_media_info()
        {
            //populates the datatable for the user to see the media
            MySqlCommand cmd = dbconnection.CreateCommand(); 
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select media_name,media_creator,media_quantity,available_qty from media_info;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // finding out which media has not yet been returned based upon the lack of a return date

            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString(); //allows the user to select a media that they would like to see the transaxtions of
            
            MySqlCommand cmd = dbconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_media where media_name= '"+ i.ToString() +"' and media_return_date=''";
            cmd.ExecuteNonQuery(); //s3lects data from the table where it has no return date and has been selected by the user 
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //allows a search function for the shop assistant so they can see whats in the db rather than scrolling 
            MySqlCommand command = dbconnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select media_name,media_creator,media_quantity,available_qty from media_info where media_name like('%" + textBox1.Text+ "%')";
            command.ExecuteNonQuery();//takes the listed data id the textbox is similar to the search
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //populates the user email etc of the person who owes the media
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            textBox2.Text = i.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this function is not working due to the security functionality of the fastmail's server
            // this is a disposable account that i have no affliation too
            // i tried using google's function but it didnt work very well and again the security protocol required two stage verification on my account. 
            // this data is possible to achieve, howwvever further lend it out research would be necessarys
            SmtpClient smtpProtocol = new SmtpClient("smtp.fastmail.com", 465);
            smtpProtocol.EnableSsl = true;
            smtpProtocol.UseDefaultCredentials = false;
            //(username,password)
            smtpProtocol.Credentials = new NetworkCredential("cjtmorrow@fastmail.com", "u5zcna9ruk8cztjx");
            //(from,to,subject,body)
            MailMessage mail = new MailMessage("cjtmorrow@fastmail.com", textBox2.Text, "This is for Media return notice", textBox3.Text);
            //fills the message with mail 
            mail.Priority = MailPriority.High;
            //mail priority setting 
            smtpProtocol.Send(mail);

            MessageBox.Show("Sent To user");
        }
    }
}
