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
using MySql.Data;

    /*
        This part of the program is used to show the vaildation required when creating an account
        It shows that a user cant enter or omit required details by leaving them empty or entering inncorrect details
        This is proof of concept and there could be other details that an account must have such as a capital letter and number in the password
    */

namespace WindowsFormsApplication1
{
    public partial class RegisterForm : Form
    {
        MySqlConnection con;
        int count = 0;
        public RegisterForm()
        {
            InitializeComponent();
        }
        

        private void TextBoxFirstname_Enter_1(object sender, EventArgs e)
        {
            // when the user enters the textbox, it needs to be empty for the data to be inserted correctly
            string fname = textBoxFirstname.Text;
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.Black;
            }
        }

        private void TextBoxFirstname_Leave(object sender, EventArgs e)
        {
            // when the user leaves the text box we need to show that the field needs to be filled in
            // Lend-it-Out have then repopulated the textbox in red writing to show the appropriate missing detail
            string fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("FullName") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "FullName";
                textBoxFirstname.ForeColor = Color.Red;
            }

        }
        private void TextBoxEmail_Enter(object sender, EventArgs e)
        {
            // when the user enters the textbox, it needs to be empty for the data to be inserted correctly
            string email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email address"))
            {

                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void TextBoxEmail_Leave(object sender, EventArgs e)
        {
            // when the user leaves the text box we need to show that the field needs to be filled in
            // Lend-it-Out have then repopulated the textbox in red writing to show the appropriate missing detail
            string email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("email address") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "email address";
                textBoxEmail.ForeColor = Color.Red;
            }

        }

        private void TextBoxUsername_Enter(object sender, EventArgs e)
        {
            // when the user enters the textbox, it needs to be empty for the data to be inserted correctly
            string uname = textBoxUsername.Text;
            if (uname.ToLower().Trim().Equals("username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;

            }
        }

        private void TextBoxUsername_Leave(object sender, EventArgs e)
        {
            // when the user leaves the text box we need to show that the field needs to be filled in
            // Lend-it-Out have then repopulated the textbox in red writing to show the appropriate missing detail
            string uname = textBoxUsername.Text;
            if (uname.ToLower().Trim().Equals("username") || uname.Trim().Equals(""))
            {
                textBoxUsername.Text = "username";
                textBoxUsername.ForeColor = Color.Red;

            }
        }

        private void TextBoxPassword_Enter(object sender, EventArgs e)
        {
            // when the user enters the textbox, it needs to be empty for the data to be inserted correctly
            string password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void TextBoxPassword_Leave(object sender, EventArgs e)
        {
            // when the user leaves the text box we need to show that the field needs to be filled in
            // Lend-it-Out have then repopulated the textbox in red writing to show the appropriate missing detail
            string password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "password";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Red;
            }
        }

        private void TextBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            // when the user enters the textbox, it needs to be empty for the data to be inserted correctly
            string cpassword = textBoxConfirmPassword.Text;
            if (cpassword.ToLower().Trim().Equals("Confirm Password") || cpassword.Trim().Equals(""))
            {

                textBoxConfirmPassword.Text = "";
                textBoxConfirmPassword.UseSystemPasswordChar = true;
                // Hides the charectors used
                textBoxConfirmPassword.ForeColor = Color.Black;
            }
        }

        private void TextBoxConfirmPassword_Leave(object sender, EventArgs e)
        {
            // when the user leaves the text box we need to show that the field needs to be filled in
            // Lend-it-Out have then repopulated the textbox in red writing to show the appropriate missing detail
            
        }

       
        private void ButtonCreateAccount_Click(object sender, EventArgs e)
        {
            // opens dbconnection 
            con = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=;");
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into library_person(`Id`, `fullname`, `username`, `password`, `email`)  values (null,'" + textBoxFirstname.Text + "', '" + textBoxUsername.Text + "', '" + textBoxPassword.Text + "', '" + textBoxEmail.Text + "')";
            command.ExecuteNonQuery(); 
            // fills data into db if the following statements are correct 

            if (!CheckTextBoxesValues()) // see the method further below, but checks if the default values are present
            {
                // check if the password equal the confirm password
                if (textBoxPassword.Text.Equals(textBoxConfirmPassword.Text))
                {
                    // check if this username already exists
                    if (checkUsername())
                    {
                        MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // execute the query
                        if (command.ExecuteNonQuery()==1)
                        {
                            MessageBox.Show("Your Account Has Been Created", "Account Created, Welcome to Lend-It-Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            con.Close();
                            mdi_user mu = new mdi_user();
                            mu.Show();
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enter Your Data First", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }


        }

        public Boolean checkUsername()
        {
            con = new MySqlConnection("server=localhost;user=root;database=120itdb;port=3306;password=;");
            con.Open();
             string sql = $"select * from library_person where username='{textBoxUsername.Text}'";

             MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();

             DataTable dt = new DataTable();
             MySqlDataAdapter da = new MySqlDataAdapter(cmd);
             da.Fill(dt);
             count = Convert.ToInt32(dt.Rows.Count.ToString());

             if (count == 1)
             {
                
                return false;
                                          
             }
             else
             {
                return true;
                
             }
        }

        public Boolean CheckTextBoxesValues()
        {
            // asigns the data to a variable 
            string fname = textBoxFirstname.Text;
            string email = textBoxEmail.Text;
            string uname = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            //if statement to check the data agaainst the default data 
            if (fname.Equals("FullName") || email.Equals("email address") || uname.Equals("username") || pass.Equals("password"))
            {
                return true;
                //returns a bool val of 1 if true , this will influence the decision if the data is commited to the db 

            }
            return false;
        }

        private void BackToLogin_Click(object sender, EventArgs e)
        {
            login test = new login();
            test.Show();

            this.Hide();
            this.Hide();
            login test2 = new login();
            test2.Show();
        }


        public void RegisterForm_Load(object sender, EventArgs e)
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
        }

        private void BackToLogin_Click_1(object sender, EventArgs e)
        {
            //page navigation 
            login LI = new login();
            LI.Show();
            this.Hide();
        }
    }
}
   

