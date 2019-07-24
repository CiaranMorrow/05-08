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

namespace WindowsFormsApplication1
{
    public partial class add_books : Form
    {

        SqlConnection con = new SqlConnection("server=localhost;port=3306;username=root;password=;database=120itdb");



        public add_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('"+ textBox1.Text +"','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ dateTimePicker1.Text + "',"+ textBox5.Text + ","+ textBox6.Text + ","+ textBox6.Text + ")";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            MessageBox.Show("Books Added SuccessFully");
        }

        private void add_books_Load(object sender, EventArgs e)
        {

        }
    }
}
