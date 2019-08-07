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
using System.IO;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    public partial class view_student_info : Form
    {
        MySqlConnection con;
        int count = 0;

        int i = 0;
        string wanted_path;
        string path;
        string pwd = Class1.GetRandomPassword(20);
        DialogResult result;
        public view_student_info()
        {
            InitializeComponent();
        }

        private void view_student_info_Load(object sender, EventArgs e)
        {

            try
            {
                con = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=;");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (SqlException ex)
            {
                throw (ex);
            }

            fill_grid();
          
        }

        public void fill_grid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info;";
            cmd.ExecuteNonQuery();
            
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            Bitmap img;
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.HeaderText = "student image";
            imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageCol.Width = 100;
            dataGridView1.Columns.Add(imageCol);
            foreach (DataRow dr in dt.Rows)
            {
               string imgPath = dr["student_image"].ToString();
                if (imgPath != null || imgPath != "")
                {
                    // view the attempt to have a dynamic routing system 
                    // string path = Path.GetFullPath(Path.Combine( @"..\..\")(Path.Combine("\student_info");
                    //string path = Path.GetFullPath(Path.Combine({Directory.GetCurrentDirectory()}, "\student_images")));
                    //path(Path.Combine(@"\student_images"));
                  string path = Directory.GetCurrentDirectory() + "..\\..\\..\\"; // finds the parent directory of current working folder 
                  //MessageBox.Show(path); // used this to see where i was working from and then i could navigate from here 
                  Image photo = Image.FromFile($"{path} \\student_images\\{imgPath}"); // the route that must now be taken to locate the image files 
                  img = new Bitmap(photo);
                  dataGridView1.Rows[i].Cells[8].Value = img; // view the image 
                  dataGridView1.Rows[i].Height = 100; // view the image sizing 
                  i = i + 1;
                
    }
                else
                {
                    continue; // if the image corrupt / fualty it carries on 
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //navigation
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                int i = 0;
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_name like('%"+ textBox1.Text +"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.HeaderText = "student image";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);
                foreach (DataRow dr in dt.Rows)
                {
                    string imgPath = dr["student_image"].ToString();
                    if (imgPath != null || imgPath != "")
                    {
                        string path = Directory.GetCurrentDirectory() + "..\\..\\..\\";
                        

                        Image photo = Image.FromFile($"{path} \\student_images\\{imgPath}");
                        img = new Bitmap(photo);
                        dataGridView1.Rows[i].Cells[8].Value = img;
                        dataGridView1.Rows[i].Height = 100;
                        i = i + 1;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //navigation for the user to click whcih student they want to edit 
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where id="+i+"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                student_name.Text = dr["student_name"].ToString();
                student_enroll.Text = dr["student_enrollment_no"].ToString();
                student_dept.Text = dr["student_department"].ToString();
                student_HireCount.Text = dr["student_HireCount"].ToString();
                student_contact.Text = dr["student_contact"].ToString();
                student_email.Text = dr["student_email"].ToString();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //updating the path for the image 

            string path = Directory.GetCurrentDirectory() + "..\\..\\..\\";
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = PrintButton.ShowDialog();
            PrintButton.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (result == DialogResult.OK) // Tests result
            {
                MessageBox.Show("Lend-It-Out Approves");
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;
                File.Copy(PrintButton.FileName, wanted_path + "\\student_images\\" + pwd + ".jpg");
                img_path = "student_images\\" + pwd + ".jpg";

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name='"+ student_name.Text +"',student_image='"+ img_path.ToString() +"',student_enrollment_no='"+ student_enroll.Text +"',student_department='"+ student_dept.Text +"',student_HireCount='"+ student_HireCount.Text +"',student_contact='"+ student_contact.Text+"',student_email='"+ student_email.Text+"' where id=" + i + "";
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("Please Check All Details Are Accurate");
            }
          
            else
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name='" + student_name.Text + "',student_enrollment_no='" + student_enroll.Text + "',student_department='" + student_dept.Text + "',student_HireCount='" + student_HireCount.Text + "',student_contact='" + student_contact.Text + "',student_email='" + student_email.Text + "' where id=" + i + "";
                cmd.ExecuteNonQuery();
                fill_grid();
                MessageBox.Show("record successfully");
            }
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            //Resize DataGridView to full height.
            int height = dataGridView1.Height;
           

            //Create a Bitmap and draw the DataGridView on it.
             bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        Bitmap bitmap;

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print the contents.
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < 8; i++)
                {
                    csv += row.Cells[i].Value.ToString().Replace(",", ";") + ',';
                } 
                //Add new line.
                csv += "\r\n";
            }
            //Exporting to CSV.
            string folderPath = "C:\\Users\\dell\\Documents\\uni\\Uni\\1st year\\120 IT Principles\\Assignment 2\\Appendix\\";
            File.WriteAllText(folderPath + "test.csv", csv);
        }
    }
}
