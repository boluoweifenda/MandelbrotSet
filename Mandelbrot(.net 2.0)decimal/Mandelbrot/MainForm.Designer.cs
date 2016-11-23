namespace Mandelbrot
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定值计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图片尺寸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabel_p = new System.Windows.Forms.Label();
            this.StatusLabel_q = new System.Windows.Forms.Label();
            this.StatusLabel_mag = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel = new System.Windows.Forms.Panel();
            this.CPUInfo = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(640, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.定值计算ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 定值计算ToolStripMenuItem
            // 
            this.定值计算ToolStripMenuItem.Name = "定值计算ToolStripMenuItem";
            this.定值计算ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.定值计算ToolStripMenuItem.Text = "定值计算";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图片尺寸ToolStripMenuItem,
            this.计算ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 图片尺寸ToolStripMenuItem
            // 
            this.图片尺寸ToolStripMenuItem.Name = "图片尺寸ToolStripMenuItem";
            this.图片尺寸ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.图片尺寸ToolStripMenuItem.Text = "图像";
            this.图片尺寸ToolStripMenuItem.Click += new System.EventHandler(this.图片尺寸ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.计算ToolStripMenuItem.Text = "计算";
            this.计算ToolStripMenuItem.Click += new System.EventHandler(this.计算ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // StatusLabel_p
            // 
            this.StatusLabel_p.AutoSize = true;
            this.StatusLabel_p.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel_p.Location = new System.Drawing.Point(3, 4);
            this.StatusLabel_p.Name = "StatusLabel_p";
            this.StatusLabel_p.Size = new System.Drawing.Size(17, 12);
            this.StatusLabel_p.TabIndex = 3;
            this.StatusLabel_p.Text = "X:";
            // 
            // StatusLabel_q
            // 
            this.StatusLabel_q.AutoSize = true;
            this.StatusLabel_q.Location = new System.Drawing.Point(3, 16);
            this.StatusLabel_q.Name = "StatusLabel_q";
            this.StatusLabel_q.Size = new System.Drawing.Size(17, 12);
            this.StatusLabel_q.TabIndex = 4;
            this.StatusLabel_q.Text = "Y:";
            // 
            // StatusLabel_mag
            // 
            this.StatusLabel_mag.AutoSize = true;
            this.StatusLabel_mag.Location = new System.Drawing.Point(3, 28);
            this.StatusLabel_mag.Name = "StatusLabel_mag";
            this.StatusLabel_mag.Size = new System.Drawing.Size(59, 12);
            this.StatusLabel_mag.TabIndex = 5;
            this.StatusLabel_mag.Text = "放大倍数:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(147, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 6;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.CPUInfo);
            this.panel.Controls.Add(this.StatusLabel_p);
            this.panel.Controls.Add(this.StatusLabel_q);
            this.panel.Controls.Add(this.StatusLabel_mag);
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(640, 480);
            this.panel.TabIndex = 7;
            // 
            // CPUInfo
            // 
            this.CPUInfo.AutoSize = true;
            this.CPUInfo.Location = new System.Drawing.Point(3, 40);
            this.CPUInfo.Name = "CPUInfo";
            this.CPUInfo.Size = new System.Drawing.Size(65, 12);
            this.CPUInfo.TabIndex = 7;
            this.CPUInfo.Text = "CPU占用率:";
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 480);
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(253, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 12);
            this.labelTime.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(640, 505);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Mandelbrot";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图片尺寸ToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.Label CPUInfo;
        private System.Windows.Forms.Label StatusLabel_q;
        private System.Windows.Forms.Label StatusLabel_mag;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label StatusLabel_p;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定值计算ToolStripMenuItem;
        private System.Windows.Forms.Label labelTime;
    }
}

