using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanSneakers
{
    public partial class FormAdminlogin : Form
    {
        public FormAdminlogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          FormAdminmain formAdminmain = new FormAdminmain();
            formAdminmain.Show();
            this.Hide();
        }
    }
}
