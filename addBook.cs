using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_managemenet_system
{
    public partial class addBook : Form
    {
        public addBook()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxBookName.Text != "" && textBoxBookAuthor.Text != "" && textBoxBookPub.Text != "" && textBoxBookPrice.Text != "" && textBoxQuant.Text != "")
            {
                String bname = textBoxBookName.Text;
                String bauthr = textBoxBookAuthor.Text;
                String publication = textBoxBookPub.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(textBoxBookPrice.Text);
                Int64 quant = Int64.Parse(textBoxQuant.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPub,bPubData,bPrice,bQuant) values('" + bname + "','" + bauthr + "','" + publication + "','" + pdate + "','" + price + "','" + quant + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxBookName.Clear();
                textBoxBookAuthor.Clear();
                textBoxBookPub.Clear();
                textBoxBookPrice.Clear();
                textBoxQuant.Clear();
            }
            else
            {
                MessageBox.Show("You need to fillup all the blank fild", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you click yes this will delete your DATA", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
