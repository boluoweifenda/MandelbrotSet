using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class ImageOptions : Form
    {
        public ImageOptions()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //在屏幕正中显示窗体
            textBoxImageWidth.Text = Convert.ToString(MainForm.imageWidth);
            textBoxImageHeight.Text = Convert.ToString(MainForm.imageHeight);
        }

        private void buttonImageOptionsConfirm_Click(object sender, EventArgs e)
        {
            MainForm.imageWidth = Convert.ToInt32(textBoxImageWidth.Text);
            MainForm.imageHeight = Convert.ToInt32(textBoxImageHeight.Text);
            this.Close();
        }
    }
}
