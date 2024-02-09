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
    public partial class issuBooks : Form
    {
        public issuBooks()
        {
            InitializeComponent();
        }

        private void issuBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            
            cmd = new SqlCommand ("Select bName from NewBook" ,con);
            SqlDataReader sdr = cmd.ExecuteReader();
            
            while(sdr.Read()) 
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBoxBook.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int count;
        private void btnSrcStudent_Click(object sender, EventArgs e)
        {
            if (textBoxEnrllID.Text!= "")
            {
                String eid = textBoxEnrllID.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewStudent where enrollID = '" + eid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //......................................................................................................
                //this portion is for how manny book  has been issue on a particular enrollment number
                cmd.CommandText = "Select count(stu_enroll) from IssueBook where stu_enroll = '" + eid + "' and book_returnDate is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                //......................................................................................................

                if (ds.Tables[0].Rows.Count != 0)
                {
                    textBoxName.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBoxDept.Text = ds.Tables[0].Rows[0][3].ToString();
                    textBoxSems.Text = ds.Tables[0].Rows[0][4].ToString();
                    textBoxContc.Text = ds.Tables[0].Rows[0][5].ToString();
                    textBoxEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    textBoxName.Clear();
                    textBoxDept.Clear();
                    textBoxSems.Clear();
                    textBoxContc.Clear();
                    textBoxEmail.Clear();
                    MessageBox.Show("Invalid Enrollment No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text !="")
            {
                if(comboBoxBook.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = textBoxEnrllID.Text;
                    String sname = textBoxName.Text;
                    String dept = textBoxDept.Text;
                    String sems = textBoxSems.Text;
                    Int64 conct = Int64.Parse(textBoxContc.Text);
                    String email = textBoxEmail.Text;
                    String bookname = comboBoxBook.Text;
                    String bookIssueDate = dateTimePicker1.Text;

                    String eid = textBoxEnrllID.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IssueBook (stu_enroll, stu_name, stu_dept, stu_sems, stu_contact, stu_email, book_name, book_issueDate) values ('"+enroll+ "','"+sname+ "','"+dept+ "','"+sems+ "',"+conct+ ",'"+email+ "','"+bookname+ "','"+bookIssueDate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book or Maximum number of book has been ISSUED for the perticular student.", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter valid Enrollment Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxEnrllID_TextChanged(object sender, EventArgs e)
        {
            if(textBoxEnrllID.Text == "")
            {
                textBoxName.Clear();
                textBoxDept.Clear();
                textBoxSems.Clear();
                textBoxContc.Clear();
                textBoxEmail.Clear();
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            textBoxEnrllID.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.OK)
            {
            this.Close();
            }
        }
    }
}
