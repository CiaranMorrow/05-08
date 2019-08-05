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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        MySqlConnection dbconnection;
        int count = 0;

        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sql = $"select * from library_person where username='{textBox1.Text}' and password='{textBox2.Text}';";
            //takes the data from the password and user fields and checks them agains the database 
            MySqlCommand cmd = new MySqlCommand(sql, dbconnection);
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            // creating a datatable to populate with the users' credentials provided 
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //uses a data adatapter and fills the newly created datatable 
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if (count == 0)
            {

                MessageBox.Show("username password does not match");
            }
            else
            {
               
                this.Hide(); // hides the page as it is no longer required 
                dbconnection.Close(); // closes the db connecection 
                mdi_user mdi = new mdi_user(); //navigates to the mdi user 
                mdi.Show(); //shows the defined link above 
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            // loading the db connection if it is  not already open 

            try
            {
                dbconnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=;");
                if (dbconnection.State == ConnectionState.Closed) 
                {
                    dbconnection.Open();
                }
            }
            catch (SqlException exception)
            {
                throw (exception);
            }
        }

       

        private void Button2_Click(object sender, EventArgs e)
        {
            //vavigating to the register form if the user needs to sign up 

            RegisterForm RF = new RegisterForm();
            RF.Show();
            this.Hide();
        }
    }
}
