namespace Mandelbrot
{
    partial class ComputeOptions
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
            this.labelEscapeRadius = new System.Windows.Forms.Label();
            this.labelEscapeTimes = new System.Windows.Forms.Label();
            this.labelThreadTotal = new System.Windows.Forms.Label();
            this.textBoxEscapeRadius = new System.Windows.Forms.TextBox();
            this.textBoxEscapeTimes = new System.Windows.Forms.TextBox();
            this.textBoxThreadTotal = new System.Windows.Forms.TextBox();
            this.buttonComputeOptionsConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelEscapeRadius
            // 
            this.labelEscapeRadius.AutoSize = true;
            this.labelEscapeRadius.Location = new System.Drawing.Point(3, 6);
            this.labelEscapeRadius.Name = "labelEscapeRadius";
            this.labelEscapeRadius.Size = new System.Drawing.Size(65, 12);
            this.labelEscapeRadius.TabIndex = 0;
            this.labelEscapeRadius.Text = "逃逸半径：";
            // 
            // labelEscapeTimes
            // 
            this.labelEscapeTimes.AutoSize = true;
            this.labelEscapeTimes.Location = new System.Drawing.Point(3, 37);
            this.labelEscapeTimes.Name = "labelEscapeTimes";
            this.labelEscapeTimes.Size = new System.Drawing.Size(65, 12);
            this.labelEscapeTimes.TabIndex = 1;
            this.labelEscapeTimes.Text = "逃逸次数：";
            // 
            // labelThreadTotal
            // 
            this.labelThreadTotal.AutoSize = true;
            this.labelThreadTotal.Location = new System.Drawing.Point(3, 66);
            this.labelThreadTotal.Name = "labelThreadTotal";
            this.labelThreadTotal.Size = new System.Drawing.Size(65, 12);
            this.labelThreadTotal.TabIndex = 2;
            this.labelThreadTotal.Text = "线程数量：";
            // 
            // textBoxEscapeRadius
            // 
            this.textBoxEscapeRadius.Location = new System.Drawing.Point(61, 3);
            this.textBoxEscapeRadius.Name = "textBoxEscapeRadius";
            this.textBoxEscapeRadius.Size = new System.Drawing.Size(60, 21);
            this.textBoxEscapeRadius.TabIndex = 3;
            // 
            // textBoxEscapeTimes
            // 
            this.textBoxEscapeTimes.Location = new System.Drawing.Point(61, 34);
            this.textBoxEscapeTimes.Name = "textBoxEscapeTimes";
            this.textBoxEscapeTimes.Size = new System.Drawing.Size(60, 21);
            this.textBoxEscapeTimes.TabIndex = 4;
            // 
            // textBoxThreadTotal
            // 
            this.textBoxThreadTotal.Location = new System.Drawing.Point(61, 63);
            this.textBoxThreadTotal.Name = "textBoxThreadTotal";
            this.textBoxThreadTotal.Size = new System.Drawing.Size(60, 21);
            this.textBoxThreadTotal.TabIndex = 5;
            // 
            // buttonComputeOptionsConfirm
            // 
            this.buttonComputeOptionsConfirm.Location = new System.Drawing.Point(5, 90);
            this.buttonComputeOptionsConfirm.Name = "buttonComputeOptionsConfirm";
            this.buttonComputeOptionsConfirm.Size = new System.Drawing.Size(116, 23);
            this.buttonComputeOptionsConfirm.TabIndex = 6;
            this.buttonComputeOptionsConfirm.Text = "确定";
            this.buttonComputeOptionsConfirm.UseVisualStyleBackColor = true;
            this.buttonComputeOptionsConfirm.Click += new System.EventHandler(this.buttonComputeOptionsConfirm_Click);
            // 
            // ComputeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(126, 117);
            this.Controls.Add(this.buttonComputeOptionsConfirm);
            this.Controls.Add(this.textBoxThreadTotal);
            this.Controls.Add(this.textBoxEscapeTimes);
            this.Controls.Add(this.textBoxEscapeRadius);
            this.Controls.Add(this.labelThreadTotal);
            this.Controls.Add(this.labelEscapeTimes);
            this.Controls.Add(this.labelEscapeRadius);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComputeOptions";
            this.Text = "计算设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEscapeRadius;
        private System.Windows.Forms.Label labelEscapeTimes;
        private System.Windows.Forms.Label labelThreadTotal;
        private System.Windows.Forms.TextBox textBoxEscapeRadius;
        private System.Windows.Forms.TextBox textBoxEscapeTimes;
        private System.Windows.Forms.TextBox textBoxThreadTotal;
        private System.Windows.Forms.Button buttonComputeOptionsConfirm;
    }
}