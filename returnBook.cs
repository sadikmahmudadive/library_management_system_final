using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lib_managemenet_system
{
    public partial class returnBook : Form
    {
        public returnBook()
        {
            InitializeComponent();
        }

        private void btnSrcStudent_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IssueBook where stu_enroll = '" + textBoxEnrllID.Text + "' and book_returnDate is null";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0 )
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Enrollment ID or no ISSUED book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnBook_Load(object sender, EventArgs e)
        {
            geadriant3.Visible = false;
            textBoxEnrllID.Clear();
        }

        String bName;
        String b_IssueDate;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            geadriant3.Visible=true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bName = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                b_IssueDate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            textBoxBookName.Text = bName;
            textBoxBookIssueDate.Text = b_IssueDate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IssueBook set book_returnDate = '"+dateTimePicker2.Text+"' where stu_enroll = '"+textBoxEnrllID.Text+"' and id = "+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Book RETURN is success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            returnBook_Load(this, null);
        }

        private void textBoxEnrllID_TextChanged(object sender, EventArgs e)
        {
            if(textBoxEnrllID.Text == "")
            {
                geadriant3.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            textBoxEnrllID.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            geadriant3.Visible=false;
        }
    }
}
