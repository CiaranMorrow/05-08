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
    public partial class view_media : Form
    {
        MySqlConnection dbcon;
        int count = 0;


        public view_media()
        {
            InitializeComponent();
        }

        private void view_media_Load(object sender, EventArgs e)
        {//loads db connection 
            try
            {
                dbcon = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=");
                
                    if (dbcon.State == ConnectionState.Closed)
                    {
                        dbcon.Open();
                    }
                
            }
            catch (SqlException ex)
            {
                throw (ex);
            }

            disp_media(); // displays media, see method below 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // search function for media name 
                dbcon.Open();
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from  media_info where media_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
               MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                dbcon.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dbcon.Open();
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from  media_info where media_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                dbcon.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                dbcon.Open();
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from  media_info where media_creator like('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                dbcon.Close();


                if(i==0)
                {
                    MessageBox.Show("No Media found");
                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // allows to select from table rather than just search 
            panel3.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
                dbcon.Open();
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from media_info where id="+i+"";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach(DataRow dr in dt.Rows)
                {

                    medianame.Text = dr["media_name"].ToString();
                    creatorname.Text = dr["media_creator"].ToString();
                    mediatype.Text = dr["media_type"].ToString();
                    mediaprice.Text = dr["media_price"].ToString();
                    mediaqty.Text = dr["media_quantity"].ToString();
                }

                    dbcon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // search feature
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            dbcon.Open();
               
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update media_info set media_name='"+ medianame.Text +"',media_creator='"+ creatorname.Text +"',media_type='"+ mediatype.Text +"',media_price="+ mediaprice.Text +",media_quantity='"+ mediaqty.Text +"' where id="+i+"";
                cmd.ExecuteNonQuery();
                dbcon.Close();
                disp_media();
                MessageBox.Show("Executed Correctly");
                panel3.Visible = false;
           }
            
            
            

        public void disp_media()
        {
            try
            {
                //ensures db is open 
                if(dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                                
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from  media_info";
                cmd.ExecuteNonQuery(); // shows all table detail, doesnt isolate inserts 
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                dbcon.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //ensures db is open 
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }

                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select `media_name`, COUNT(*) AS IssuedCounter FROM issue_media Group BY media_name ORDER By IssuedCounter DESC";
                cmd.ExecuteNonQuery(); // shows all table detail, doesnt isolate inserts 
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                dbcon.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        /*SELECT `media_name`,COUNT(*) AS IssuedCounter
FROM issue_media
GROUP BY media_name
ORDER BY IssuedCounter DESC*/


    }
}
