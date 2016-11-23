namespace Mandelbrot
{
    partial class ImageOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelImageWidth = new System.Windows.Forms.Label();
            this.textBoxImageWidth = new System.Windows.Forms.TextBox();
            this.labelImageHeight = new System.Windows.Forms.Label();
            this.textBoxImageHeight = new System.Windows.Forms.TextBox();
            this.buttonImageOptionsConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelImageWidth
            // 
            this.labelImageWidth.AutoSize = true;
            this.labelImageWidth.Location = new System.Drawing.Point(0, 6);
            this.labelImageWidth.Name = "labelImageWidth";
            this.labelImageWidth.Size = new System.Drawing.Size(65, 12);
            this.labelImageWidth.TabIndex = 0;
            this.labelImageWidth.Text = "图片宽度：";
            // 
            // textBoxImageWidth
            // 
            this.textBoxImageWidth.Location = new System.Drawing.Point(61, 3);
            this.textBoxImageWidth.Name = "textBoxImageWidth";
            this.textBoxImageWidth.Size = new System.Drawing.Size(60, 21);
            this.textBoxImageWidth.TabIndex = 1;
            // 
            // labelImageHeight
            // 
            this.labelImageHeight.AutoSize = true;
            this.labelImageHeight.Location = new System.Drawing.Point(0, 34);
            this.labelImageHeight.Name = "labelImageHeight";
            this.labelImageHeight.Size = new System.Drawing.Size(65, 12);
            this.labelImageHeight.TabIndex = 2;
            this.labelImageHeight.Text = "图片高度：";
            // 
            // textBoxImageHeight
            // 
            this.textBoxImageHeight.Location = new System.Drawing.Point(61, 31);
            this.textBoxImageHeight.Name = "textBoxImageHeight";
            this.textBoxImageHeight.Size = new System.Drawing.Size(60, 21);
            this.textBoxImageHeight.TabIndex = 3;
            // 
            // buttonImageOptionsConfirm
            // 
            this.buttonImageOptionsConfirm.Location = new System.Drawing.Point(2, 58);
            this.buttonImageOptionsConfirm.Name = "buttonImageOptionsConfirm";
            this.buttonImageOptionsConfirm.Size = new System.Drawing.Size(119, 23);
            this.buttonImageOptionsConfirm.TabIndex = 4;
            this.buttonImageOptionsConfirm.Text = "确定";
            this.buttonImageOptionsConfirm.UseVisualStyleBackColor = true;
            this.buttonImageOptionsConfirm.Click += new System.EventHandler(this.buttonImageOptionsConfirm_Click);
            // 
            // ImageOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 81);
            this.Controls.Add(this.buttonImageOptionsConfirm);
            this.Controls.Add(this.textBoxImageHeight);
            this.Controls.Add(this.labelImageHeight);
            this.Controls.Add(this.textBoxImageWidth);
            this.Controls.Add(this.labelImageWidth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageOptions";
            this.Text = "图像设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelImageWidth;
        private System.Windows.Forms.TextBox textBoxImageWidth;
        private System.Windows.Forms.Label labelImageHeight;
        private System.Windows.Forms.TextBox textBoxImageHeight;
        private System.Windows.Forms.Button buttonImageOptionsConfirm;
    }
}