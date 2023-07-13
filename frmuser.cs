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
    public partial class frmuser : Form
    {
        public frmuser()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmLogin f1 = new frmLogin();
            f1.Show();
            this.Hide();
        }
    }
}
