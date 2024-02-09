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
    public partial class viewBook : Form
    {
        public viewBook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void viewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid=int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewBook where bid = "+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowID = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            textBoxName.Text = ds.Tables[0].Rows[0][1].ToString();
            textBoxAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            textBoxPub.Text = ds.Tables[0].Rows[0][3].ToString();
            textBoxPDatte.Text = ds.Tables[0].Rows[0][4].ToString();
            textBoxPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            textBoxQuant.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnCncl_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void textBoxBookSearch_TextChanged(object sender, EventArgs e)
        {
            if(textBoxBookSearch.Text !="")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewBook where bName LIKE '"+textBoxBookSearch.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefersh_Click(object sender, EventArgs e)
        {
            textBoxBookSearch.Clear();
            panel2.Visible = false;
        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("If you click yes Data will be update with new data. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                    String bname = textBoxName.Text;
                    String bauthor = textBoxAuthor.Text;
                    String bpub = textBoxPub.Text;
                    String pdate = textBoxPDatte.Text;
                    Int64 price = Int64.Parse(textBoxPrice.Text);
                    Int64 quant = Int64.Parse(textBoxQuant.Text);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "update NewBook set bName = '" + bname + "', bAuthor = '" + bauthor + "', bPub = '" + bpub + "', bPubData ='" + pdate + "', bPrice= " + price + ", bQuant= " + quant + " where bid =" + rowID + " ";
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

                cmd.CommandText = "delete from NewBook where bid="+bid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
