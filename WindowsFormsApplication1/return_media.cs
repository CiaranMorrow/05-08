using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace WindowsFormsApplication1
{
    public partial class return_media : Form
    {
        MySqlConnection dbconnnection;
        int count = 0;

        public return_media()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //shows the hidden pannel that is not visable straight away, adds a cool visual effect 
            panel3.Visible = true;
            panel2.Visible = true;  
            fill_grid(textBox1.Text);

        }

        private void Return_media_Load(object sender, EventArgs e)
        {
            //opens db connection 
            try
            {
                dbconnnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=");
                {
                    if (dbconnnection.State == ConnectionState.Closed)
                    {
                        dbconnnection.Open();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        

        public void fill_grid(string enrollment)
        {
            // fills the grid with the enrolment number of the customer, as added by the user 
           MySqlCommand command = dbconnnection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from issue_media where student_enrollment = '"+ enrollment.ToString() +"'";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

      
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //shows the panel populated with the students details 
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            MySqlCommand cmd = dbconnnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_media where id= "+i+"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            foreach(DataRow dr in dt.Rows)
            {
                lbl_mediaName.Text = dr["media_name"].ToString();
                lbl_issuedate.Text = Convert.ToString(dr["media_issue_date"].ToString());

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            MySqlCommand cmd = dbconnnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update issue_media set media_return_date='" + dateTimePicker1.Value.ToString() + "' where Id=" + i + "";
            cmd.ExecuteNonQuery(); // details the date time that has been selected by the user, could have done a date time stamp but retrospective returns wouldnt have been possible 

            MySqlCommand cmd1 = dbconnnection.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update media_info set available_qty=available_qty+1 where media_name='" + lbl_mediaName.Text + "'";
            cmd1.ExecuteNonQuery(); // increases the number of media available to be hired after the hire 


            MessageBox.Show("Media return successfully");
            //user feedback 

            panel3.Visible = true;

            fill_grid(textBox1.Text);
        }
    }
}
