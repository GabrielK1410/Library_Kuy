﻿using System;
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
    public partial class FormCRakun : Form
    {
        public FormCRakun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRakun1.SetParameterValue("akun_user",txtUsername.Text);
            crystalReportViewer1.ReportSource = CRakun1;
            crystalReportViewer1.Refresh();
        }
    }
}