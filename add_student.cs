using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lib_managemenet_system
{
    public partial class add_student : Form
    {
        public add_student()
        {
            InitializeComponent();
        }

        private void geadriant1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm ?", "Alart", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefs_Click(object sender, EventArgs e)
        {
            textBoxStuName.Clear();
            textBoxEnrollID.Clear();
            textBoxDept.Clear();
            textBoxSem.Clear();
            textBoxStuMail.Clear();
            textBoxStuContact.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxStuName.Text != "" && textBoxEnrollID.Text != "" && textBoxDept.Text != "" && textBoxSem.Text != "" && textBoxStuContact.Text != "" && textBoxStuMail.Text != "")
            {
                String name = textBoxStuName.Text;
                String enrollID = textBoxEnrollID.Text;
                String dept = textBoxDept.Text;
                String sems = textBoxSem.Text;
                Int64 mobile = Int64.Parse(textBoxStuContact.Text);
                String email = textBoxStuMail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = PHOTONPLUSE\\SQLEXPRESS; database = lib_admin; integrated security=True ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (stuName, enrollId, dept, sems, contact, email) values('" + name + "','" + enrollID + "','" + dept + "','" + sems + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty filds", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
