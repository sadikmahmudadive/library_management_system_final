using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace lib_managemenet_system
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (textUsername.Text =="" && textPassword.Text =="" && textConfPassword.Text =="")
            {
                MessageBox.Show("Please fill up the Username and Password box", "Sign Up FAILED!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textPassword.Text == textConfPassword.Text)
            {
                String username = textUsername.Text;
                String password = textPassword.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into LoginTable (username, pass) values('" + textUsername.Text + "','" + textPassword.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                textUsername.Text = "";
                textPassword.Text = "";
                textConfPassword.Text = "";

                MessageBox.Show("Sign Up compleate!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match, Please re enter Password", "Sign Up FAILD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Text = "";
                textConfPassword.Text = "";
                textPassword.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(!checkBox1.Checked)
            {
                textPassword.PasswordChar = '*';
                textConfPassword.PasswordChar = '*';
            }
            else
            {
                textPassword.PasswordChar = '\0';
                textConfPassword.PasswordChar = '\0';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            textPassword.Text = "";
            textConfPassword.Text = "";
            textUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
