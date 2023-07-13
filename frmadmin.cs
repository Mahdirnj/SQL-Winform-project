using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kianosh_Safarzadeh_Project
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
            txtStuCode.Focus();
        }

        private int checktype()
        {
            Type type = txtStuCode.GetType();
            if (type == (typeof(string)))
            {
                MessageBox.Show("Incorrect ID format\nEnter it as a number");
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        private void Deleteinput()
        {
            if (chkAutoDelete.Checked) 
            {
                txtStuCode.Text = ""; 
                txtStuField.Text = "";
                txtStuName.Text = "";
            }
        }

        private void Updategrd()
        {
            if (chkAutoLoad.Checked)
            {
                string SQL = "SELECT * FROM tbl_Stu";
                grdData.DataSource = Mydatabase.OpenSQL(SQL);
                grdData.Refresh(); 
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnShowtbl_Click(object sender, EventArgs e)
        {
            string SQL = "SELECT * FROM tbl_Stu";
            grdData.DataSource = Mydatabase.OpenSQL(SQL);
            grdData.Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int status = checktype();
                if (status == 0)
                {
                    string SQL = "INSERT INTO tbl_Stu(stucode,stuname,stufield) VALUES ('" + txtStuCode.Text + "','" + txtStuName.Text + "','" + txtStuField.Text + "')";
                    Mydatabase.RunSQL(SQL);
                    SQL = "SELECT * FROM tbl_Stu";
                    grdData.DataSource = Mydatabase.OpenSQL(SQL);
                    grdData.Refresh();
                    Deleteinput();
                    txtStuCode.Focus();
                    Updategrd();
                }
            }
            catch (Exception )
            {

                MessageBox.Show("Student code should be number");
            }

            
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                string SQL = "DELETE FROM tbl_Stu";
                Mydatabase.RunSQL(SQL);
                grdData.Refresh();
                Updategrd();
            }
            catch (Exception ix)
            {

                MessageBox.Show(ix.Message);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string SQL = "delete from tbl_Stu where stucode='" + txtSearch.Text + "'";
            Mydatabase.RunSQL(SQL);
            grdData.Refresh();
            Updategrd();
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string SQL = "select * FROM tbl_Stu WHERE stuname LIKE '" + txtSearch.Text.ToString()+ "%' OR stucode LIKE '" + txtSearch.Text.ToString() + "%' OR stufield LIKE '" + txtSearch.Text.ToString() +"'";
            grdData.DataSource = Mydatabase.OpenSQL(SQL);
            grdData.Refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtStuCode.Text != "")
            {
                MessageBox.Show("Cant edit student ID");
            }
            string SQL = "update tbl_Stu set stuname='" + txtStuName.Text + "',stufield='" + txtStuField.Text + "' where stucode='" + txtSearch.Text + "'";
            Mydatabase.RunSQL(SQL);
            grdData.Refresh();
            Updategrd();
        }
    }
}
