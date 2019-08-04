using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class add_student_info : Form
    {
        MySqlConnection connnection;
        int count = 0;

        // string pawthway directory for images
        string imagepathway;
        string pwd = Class1.GetRandomPassword(20); 
        public add_student_info()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            imagepathway = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult imageroute = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (imageroute == DialogResult.OK) // Test imageroute.
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            //pictureBox1.ImageLocation = @"..\..\student_images\" + pwd + ".jpg";


        }

        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string img_path;
                File.Copy(openFileDialog1.FileName, imagepathway + "\\student_images\\" + pwd + ".jpg");
                img_path = pwd + ".jpg";

                connnection.Open();
                MySqlCommand Command = connnection.CreateCommand();
                Command.CommandType = CommandType.Text;
                Command.CommandText = "insert into student_info values(null, '" + textBox1.Text + "','" + img_path + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                Command.ExecuteNonQuery();
                connnection.Close();

                MessageBox.Show("record inserted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        public void add_student_info_Load(object sender, EventArgs e)
        {

            try
            {
                using (connnection = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password="))
                {
                    if (connnection.State == ConnectionState.Closed)
                    {
                        connnection.Open();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw (ex);
            }


        }

       
    }
}
