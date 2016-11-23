using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class ComputeOptions : Form
    {
        public ComputeOptions()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //在屏幕正中显示窗体
            textBoxEscapeRadius.Text = Convert.ToString(MainForm.escapeRadius);
            textBoxEscapeTimes.Text = Convert.ToString(MainForm.escapeTimes);
            textBoxThreadTotal.Text = Convert.ToString(MainForm.threadTotal);
        }

        private void buttonComputeOptionsConfirm_Click(object sender, EventArgs e)
        {
            MainForm.escapeRadius = Convert.ToInt32(textBoxEscapeRadius.Text);
            MainForm.escapeTimes = Convert.ToInt32(textBoxEscapeTimes.Text);
            MainForm.threadTotal = Convert.ToInt32(textBoxThreadTotal.Text);
            this.Close();
        }
    }
}
