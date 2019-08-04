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
    public partial class add_media : Form
    {
        MySqlConnection dbconnection;
        int count = 0;

        public  add_media()
        {
            InitializeComponent();          //initialises the component's designer 
        }

        public void button1_Click(object sender, EventArgs e)
        {
            dbconnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=");
            if (dbconnection.State == ConnectionState.Closed) //the connection could already be open and throw an exception, if statement checks this. 
            {
                dbconnection.Open();
            }

            MySqlCommand cmd = dbconnection.CreateCommand(); // defining the command to the db  
            cmd.CommandType = CommandType.Text; // defining the command type
            cmd.CommandText = "insert into media_info values (null, '" + textBox1.Text +"', '"+ textBox2.Text + "', '" + textBox3.Text + "','" + dateTimePicker1.Text + "', " + textBox5.Text + "," + textBox6.Text + "," + textBox6.Text + " )";
            cmd.ExecuteNonQuery(); //Executes the SQL statement above 
            dbconnection.Close();
            //clears the textboxes after the data has been added, therefore no duplicated data 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            MessageBox.Show("Media Added SuccessFully"); //Message to show the user it has been successfull and added the data 

        }

        public void add_media_Load(object sender, EventArgs e)
        {
            try
            {
                //loads dbconnection 
                dbconnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=");

                if (dbconnection.State == ConnectionState.Closed) //the connection could already be open and throw an exception, if statement checks this. 
                        {
                        dbconnection.Open();
                        }
             
            }
            catch (MySqlException exception)
            {
                throw (exception);
            }

        }

    }
}
