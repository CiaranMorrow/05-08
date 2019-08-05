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
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class issue_media : Form
    {
        MySqlConnection dbconnection;
        int counter = 0;

        public issue_media()
        {
        InitializeComponent(); // Initialises the designer 
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            MySqlCommand cmd = dbconnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where student_enrollment_no ='" + txt_enrollment.Text +"'";
            cmd.ExecuteNonQuery(); //excecutes the cmd3 above to select the student enrolment line from the db when it matches the number issued by the user
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd); //data adaption for the table created to show student info
            da.Fill(dt); //fills the table created with info from the MySql DB(Local)
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Enrollment Number not found"); //User Feedback if the enrollment is not found 
            }
            else
            {

                foreach (DataRow dr in dt.Rows)//populates the text boxes with the data for user to confirm / ammend 
                {
                   
                    txt_studentname.Text = dr["student_name"].ToString();
                    txt_studentdept.Text = dr["student_department"].ToString();
                    txt_stuxdentHireCount.Text = dr["student_HireCount"].ToString();
                    txt_studentcontact.Text = dr["student_contact"].ToString();
                    txt_studentemail.Text = dr["student_email"].ToString();

                }
            }
        }

        public void issue_media_Load(object sender, EventArgs e)
        {
            //loads the db when the page opens
            try
            {
                dbconnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=");
                {
                    if (dbconnection.State == ConnectionState.Closed)
                    {
                        dbconnection.Open();
                    }
                }
            }
            catch (SqlException exception)
            {
                throw (exception); // throws an exception if the db cant be connected to correctly,  useful in development to show where the code is breaking 
            }
        }

        public void txt_Media_KeyUp(object sender, KeyEventArgs e)
        {

            int counter = 0;

            if (e.KeyCode != Keys.Enter)
            {
                //allows user to scroll through the database's list of medias and press enter 
                listBox1.Items.Clear();
                MySqlCommand command = dbconnection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from media_info where media_name like('%" + txt_Medianame.Text + "%')";
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                da.Fill(dt);
                counter = Convert.ToInt32(dt.Rows.Count.ToString());

                if (counter > 0)
                {
                    listBox1.Visible = true;
                    foreach (DataRow dr in dt.Rows)
                    {
                        listBox1.Items.Add(dr["media_name"].ToString());
                        //populates the textbox with the media's name to commit it to the db 
                    }

                }
            }
        }

        public void txt_Medianame_KeyDown(object sender, KeyEventArgs e)
        {
            //allows user to scroll through the database's list of medias

            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                
                listBox1.SelectedIndex = 0;
            }
        }

        public void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //allows user to scroll through the database's list of medias and this bit allows the button to press enter 
            if (e.KeyCode == Keys.Enter)
            {
                txt_Medianame.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        public void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //allows the mouse to be used to select the media 
            txt_Medianame.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            // checks the issue request against database 
            int available_qty=0; // sets a variable to see if the db has a media available to issue
            MySqlCommand cmd2 = dbconnection.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from media_info where media_name='"+ txt_Medianame.Text +"'";
            cmd2.ExecuteNonQuery(); //executes the query above, where the media name matches the textbox above, selected from media info
            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            da2.Fill(dt2);//fills the table 
            foreach(DataRow dr2 in dt2.Rows)
            {
                available_qty = Convert.ToInt32(dr2["available_qty"].ToString()); // conversion 
            }
            if (available_qty > 0) // checks if the media is available for hire
            {
                MySqlCommand cmd3 = dbconnection.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "insert into issue_media values(null, '" + txt_enrollment.Text + "','" + txt_studentname.Text + "','" + txt_studentdept.Text + "','" + txt_stuxdentHireCount.Text + "','" + txt_studentcontact.Text + "','" + txt_studentemail.Text + "','" + txt_Medianame.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','')";
                cmd3.ExecuteNonQuery();//commiuts the data above to the table, so as to update the db to the media request made by the user
                MySqlCommand cmd4 = dbconnection.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update media_info set available_qty=available_qty-1 where media_name='" + txt_Medianame.Text + "'";
                cmd4.ExecuteNonQuery(); //we need to show that the media is now less available to before. we only need to reduce this by one
                // we will increase this in the returning class later when the user has returned the media 
                MySqlCommand cmd5 = dbconnection.CreateCommand();
                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "update student_info set Student_HireCount=Student_HireCount+1 where student_enrollment_no='" + txt_enrollment.Text + "'";
                cmd5.ExecuteNonQuery(); // to show which user has been most enaged, this will produce a field that can be used in the reporting tool
                 MessageBox.Show("Media issued successfully");
            }
            else // shows the media is not available for hire 
            {
                MessageBox.Show("Media not avaialble");
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
