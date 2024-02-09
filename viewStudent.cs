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
    public partial class viewStudent : Form
    {
        public viewStudent()
        {
            InitializeComponent();
        }

        private void textBoxEnrollIDSrc_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEnrollIDSrc.Text!= "")
            {
                lableViewStudent.Visible = false;
                Image image = Image.FromFile("D:/Code/C#/lib_managemenet_system/image/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewStudent where enrollID LIKE '" + textBoxEnrollIDSrc.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                lableViewStudent.Visible = true;
                Image image = Image.FromFile("D:/Code/C#/lib_managemenet_system/image/Liberay Management System/search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void viewStudent_Load(object sender, EventArgs e)
        {
            geadriant1.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            geadriant1.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewStudent where stuID = " + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowID = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            textBoxName.Text = ds.Tables[0].Rows[0][1].ToString();
            textBoxEnrllID.Text = ds.Tables[0].Rows[0][2].ToString();
            textBoxDept.Text = ds.Tables[0].Rows[0][3].ToString();
            textBoxSems.Text = ds.Tables[0].Rows[0][4].ToString();
            textBoxContc.Text = ds.Tables[0].Rows[0][5].ToString();
            textBoxEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you click yes Data will be update with new data. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String name = textBoxName.Text;
                String enrollid = textBoxEnrllID.Text;
                String dept = textBoxDept.Text;
                String sems = textBoxSems.Text;
                Int64 contact = Int64.Parse(textBoxContc.Text);
                String email = textBoxEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set stuName = '" + name + "', enrollID = '" + enrollid + "', dept = '" + dept + "', sems ='" + sems + "', contact = " + contact + ", email= '" + email + "' where stuID =" + rowID + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnDlt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you click yes Data will be Delete. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuID=" + bid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            geadriant1.Visible = false;
        }

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            textBoxEnrollIDSrc.Clear();
            geadriant1.Visible = false;
        }
    }
}
