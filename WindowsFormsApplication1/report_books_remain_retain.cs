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
    public partial class report_books_remain_retain : Form
    {
        SqlConnection con = new SqlConnection("server=localhost;port=3306;username=root;password=;database=120itdb");      
 
        public report_books_remain_retain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DataSet1 ds = new DataSet1();
           SqlCommand cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from issue_books where book_return_date=''";
           cmd.ExecuteNonQuery();
           DataTable dt = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds.DataTable1);
           CrystalReport1 myreport = new CrystalReport1();
           myreport.SetDataSource(ds);
           crystalReportViewer1.ReportSource = myreport;
        }

        private void report_books_remain_retain_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
