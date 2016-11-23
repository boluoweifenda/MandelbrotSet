using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace Mandelbrot
{
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //在屏幕正中显示窗体
           
        }

        

        #region 公共变量
        
        public static int imageWidth = 640;//初始图片宽度
        public static int imageHeight = 480;//初始图片高度
        public static int escapeRadius = 2;//逃逸半径，当Z的模大于2时，会很快趋于无穷(逃逸半径)
        public static int escapeTimes = 512;//最大迭代次数(逃逸时间)

        public static int threadTotal = 4;//绘图迭代总线程数
        public static int threadLeft;//绘图迭代剩余线程数

        public static decimal Xmin = -2;//实轴初始范围
        public static decimal Xmax = 2;//实轴初始范围
        public static decimal Ymin = -2;//虚轴初始范围
        public static decimal Ymax = 2;//虚轴初始范围

        public static decimal bitWidth;//每个像素点所占实轴宽度
        public static decimal bitHeight;//每个像素点所占虚轴宽度

        public static int random100 = 95;
        public static Bitmap bitmap;//构造像素矩阵
        public static int[, ,] bitmapArray ;//像素色彩数组 

        public static int trackBarColorMoverValue = 1;
        public static int rMover = 2;
        public static int gMover = 4;
        public static int bMover = 3;

        public static int progressBarValue = 0;//绘图进度条

        //颜色分量
        public static int R; 
        public static int G; 
        public static int B;

        public static double H = 240;//色相偏移量
        public static double S = 1;//饱和度偏移量
        public static double V = 1;//色调偏移量

        

        public static int csMaxColorRoundValue = 256;
        public static ulong[] colorRound_table = new ulong[(csMaxColorRoundValue + 1) * 2];
        #endregion


        public long round_color(int x)
        {
            if (x < 0) x = -x;//取值变成  513到0，再到512。首尾相接
            while (x > csMaxColorRoundValue) x -= csMaxColorRoundValue;//最后x范围是 1 512 到0 再到512
            const double PI = 3.1415926535897932384626433832795;
            double rd = (Math.Sin(x * (2.0 * PI / csMaxColorRoundValue)) + 1.1) / 2.1;//色环！正好2pi转了一圈！
            //rd取值从 -0.1到1到0.1到1到-0.1
            long ri = (long)(rd * 255 + 0.5);
            //long ri=abs(x-csMaxColorRoundValue/2);
            if (ri < 0) return 0;
            else if (ri > 255) return 255;
            else return ri;
        }

        public void Creat_colorRound_table()
        {
            for (int i = 0; i < (csMaxColorRoundValue + 1) * 2; i++)//首尾相接！为了柔和！
                colorRound_table[i] = (ulong)round_color(i - (csMaxColorRoundValue + 1));//取值是 -513到+510
        }//i是0到1023


        public static void HSV2RGB(double h)
        {
            h += H;
            double s = S;//( S + h * 0.07) % 2;
            if (s > 1)
                s = 2 - s;
            double v =( V + h * 0.001 ) % 2;
           if (v > 1)
               v = 2 - v;
        
            int hi = ( (int) (Math.Floor(h / 60)) ) % 6;
            double f = ( (h %360 )/ 60) - hi;
            int p = (int)(v * (1 - s) * 255);
            int q = (int)(v * (1 - f * s) * 255);
            int t = (int)(v * (1 - (1 - f) * s) * 255);
            v *= 255;
            switch (hi)
            {
                case 0:
                    R = (int)v;
                    G = t;
                    B = p;
                    break;
                case 1:
                    R = q;
                    G = (int)v;
                    B = p;
                    break;
                case 2:
                    R = p;
                    G = (int)v;
                    B = t;
                    break;
                case 3:
                    R = p;
                    G = q;
                    B = (int)v;
                    break;
                case 4:
                    R = t;
                    G = p;
                    B = (int)v;
                    break;
                case 5:
                    R = (int)v;
                    G = p;
                    B = q;
                    break;
                default:
                    MessageBox.Show("出现了BUG！");
                    break;

            }
            return;
        }

        //绘图总调度
        public void DrawControl()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            设置ToolStripMenuItem.Enabled = false;//绘图过程中不可修改参数
            开始ToolStripMenuItem.Enabled = false;
            MaximizeBox = false;//绘图过程不可最大化
            labelTime.ResetText();
            
            pictureBox.Width = imageWidth;
            pictureBox.Height = imageHeight;

            //调整横纵比例
            YminTemp = (Ymin + Ymax) / 2 - (Xmax - Xmin) * ((decimal)imageHeight / (decimal)imageWidth) / 2;
            YmaxTemp = (Ymin + Ymax) / 2 + (Xmax - Xmin) * ((decimal)imageHeight / (decimal)imageWidth) / 2;
            Ymin = YminTemp;
            Ymax = YmaxTemp;

            Creat_colorRound_table();//初始化“首尾相接”的色环数组！此色环非一般色环

            bitWidth = (decimal)(Xmax - Xmin) / imageWidth;//计算每个像素点所占实轴宽度
            bitHeight = (decimal)(Ymax - Ymin) / imageHeight;//计算每个像素点所占虚轴宽度

            bitmap = new Bitmap(imageWidth, imageHeight);//构造像素矩阵

            DrawMandelbrot[] drawThreads = new DrawMandelbrot[threadTotal];
            Thread[] threads = new Thread[threadTotal];
            bitmapArray = new int[imageWidth, imageHeight, 3];

            threadLeft = threadTotal;
            

            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
           
            for (int i = 0; i < threadTotal; i++)
            {
                drawThreads[i] = new DrawMandelbrot(i);
                threads[i] = new Thread(drawThreads[i].ThreadProc);
                threads[i].Name = "绘图线程" + Convert.ToString(i) ;
                threads[i].Start();
               
            }

            while (threadLeft != 0)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                progressBar.Value = ( progressBarValue * 100 / imageWidth ) % 100;
            }

            for (int i = 0; i < MainForm.imageWidth; i++)
            {
                for (int j = 0; j < MainForm.imageHeight; j++)
                {
                    Color bitColor = Color.FromArgb(MainForm.bitmapArray[i, j, 0], MainForm.bitmapArray[i, j, 1], MainForm.bitmapArray[i, j, 2]);
                    MainForm.bitmap.SetPixel(i, j, bitColor);//这是最关键的函数，画点！
                     
                }
            }
            
            pictureBox.Image = MainForm.bitmap;
            
            //提示音！！！！
            System.Media.SystemSounds.Asterisk.Play();

            //刷新放大倍数和参数窗口位置
            StatusLabel_mag.Text = "放大倍数:" + Convert.ToString((decimal)4.00 / ((MainForm.Xmax - MainForm.Xmin)));
            //滚动条归位
            progressBarValue = 0;
            progressBar.Value = 0;

            设置ToolStripMenuItem.Enabled = true;
            MaximizeBox = true;
            开始ToolStripMenuItem.Enabled = true;

         
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double seconds = timespan.TotalSeconds;  //  总秒数

            labelTime.Text = "耗时" + Convert.ToString((int)(seconds)) + "秒";

            return;
  }


        #region 鼠标操作

        decimal XminTemp;//用于鼠标拉框的临时数据
        decimal XmaxTemp;//用于鼠标拉框的临时数据
        decimal YminTemp;//用于鼠标拉框的临时数据
        decimal YmaxTemp;//用于鼠标拉框的临时数据

        bool MouseIsDown = false;
        Rectangle MouseRect = Rectangle.Empty;

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (threadLeft != 0)
                return;
            else if (e.Button == MouseButtons.Left)
            {
                MouseIsDown = true;
                Cursor.Clip = this.RectangleToScreen(new Rectangle(0, panel.Location.Y, pictureBox.Width, pictureBox.Height));

                MouseRect = new Rectangle(e.X, e.Y + panel.Location.Y, 0, 0);//加panel.Location.Y是因为e.Y是相对于pictureBox的坐标,
                //但后面画矩形却以Form为参照,所以矩形第一点会有增量

                //获取矩形第一个点的实际坐标
                
                XminTemp = Xmin + (Xmax - Xmin) * ((decimal)e.X / (decimal)pictureBox.Width);
                YmaxTemp = Ymax - (Ymax - Ymin) * ((decimal)e.Y / (decimal)pictureBox.Height);
                
            }

            else{ };
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            if (threadLeft != 0)
                return;
            else if (e.Button == MouseButtons.Left && MouseIsDown)
            {
                //清理
                Cursor.Clip = Rectangle.Empty;
                MouseIsDown = false;

                //重画以清理矩形
                Rectangle rect = this.RectangleToScreen(MouseRect);
                ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);
                MouseRect = Rectangle.Empty;


                //获取矩形第二个点的实际坐标
                XmaxTemp = Xmin + (Xmax - Xmin) * ((decimal)e.X / (decimal)pictureBox.Width);
                YminTemp = Ymax - (Ymax - Ymin) * ((decimal)e.Y / (decimal)pictureBox.Height);
               
                //坐标规范化
                if ((XminTemp == XmaxTemp) || (YminTemp == YmaxTemp))
                {
                    MessageBox.Show("矩形框面积为零！！！\n你可能单击了鼠标，请拖动鼠标拉框放大");
                    return;
                }
                else if ((XmaxTemp < XminTemp) || (YmaxTemp < YminTemp))
                {
                    if (XmaxTemp < XminTemp)
                    {
                        Xmin = XmaxTemp;
                        Xmax = XminTemp;
                    }
                    if (YmaxTemp < YminTemp)
                    {
                        Ymin = YmaxTemp;
                        Ymax = YminTemp;
                    }

                    Thread drawControlThread = new Thread(DrawControl);
                    drawControlThread.Name = "绘图总调度线程";
                    drawControlThread.Start();
                }
                else
                {
                    Xmin = XminTemp;
                    Ymin = YminTemp;
                    Xmax = XmaxTemp;
                    Ymax = YmaxTemp;
                    Thread drawControlThread = new Thread(DrawControl);
                    drawControlThread.Name = "绘图总调度线程";
                    drawControlThread.Start();
                }
            }

            else { };

        }
       
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                Rectangle rect = this.RectangleToScreen(MouseRect);
                ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);//reversible frame,重画以清除之前的矩形

                MouseRect.Width = e.X - MouseRect.Left;
                MouseRect.Height = e.Y -(MouseRect.Top - panel.Location.Y);//由于MouseRect.Top在前面已经加上了偏移量,这里计算宽度时
                                                                           //要减去偏移量得到绝对高度 e.Y(UP)-e.Y(DOWN)
                
                rect = this.RectangleToScreen(MouseRect);
                ControlPaint.DrawReversibleFrame(rect, Color.White, FrameStyle.Dashed);//画新的矩形  
            }

            StatusLabel_p.Text = "X:" + Convert.ToString(Xmin + (Xmax - Xmin) * ((decimal) e.X / (decimal) pictureBox.Width ));
            StatusLabel_q.Text = "Y:" + Convert.ToString(Ymax - (Ymax - Ymin) * ((decimal) e.Y / (decimal)pictureBox.Height ));
        }

        #endregion


        //监测CPU占有率
        private void ThreadForCPUView(object obj)
        {
            PerformanceCounter CPULoad = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            while (true)
            {
                
                Thread.Sleep(1000);
                CPUInfo.Text = "CPU占用率:" + Convert.ToString(CPULoad.NextValue()) + "%";
            }
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Normal)
            {
                imageHeight = panel.Height;
                imageWidth = panel.Width;
                Thread drawControlThread = new Thread(DrawControl);
                drawControlThread.Name = "绘图总调度线程";
                drawControlThread.Start();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread CPUThread = new Thread(ThreadForCPUView);
            CPUThread.Name = "CPU占用率线程";
            CPUThread.IsBackground = true;
            CPUThread.Start();

            Thread drawControlThread = new Thread(DrawControl);
            drawControlThread.Name = "绘图总调度线程";
            drawControlThread.Start();
        }

        #region 菜单

        private void 图片尺寸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageOptions setImageOptions = new ImageOptions();
            setImageOptions.ShowDialog();
        }


        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComputeOptions setComputeOptions = new ComputeOptions();
            setComputeOptions.ShowDialog();
        }

       

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();//新建打开文件对话框
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//设置初始文件目录
            openFile.Filter = "数据文件(*.ini)|*.ini";//设置打开文件类型
            openFile.Title = "打开数据文件";
            if (openFile.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFile.FileName;//FileName就是要打开的文件路径
                //下边可以添加用户代码  
                FileStream fileStream = new FileStream(FileName, FileMode.Open);

                StreamReader m_streamReader = new StreamReader(fileStream);
                Match match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                imageWidth = Convert.ToInt32(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                imageHeight = Convert.ToInt32(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                Xmin = Convert.ToDecimal(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                Xmax = Convert.ToDecimal(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                Ymin = Convert.ToDecimal(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                Ymax = Convert.ToDecimal(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                escapeRadius = Convert.ToInt32(match.Result("$1"));
                match = Regex.Match(m_streamReader.ReadLine(), @"=([\s\S]*?);");
                escapeTimes = Convert.ToInt32(match.Result("$1"));

                Thread drawControlThread = new Thread(DrawControl);
                drawControlThread.Name = "绘图总调度线程";
                drawControlThread.Start();
            }
        }



        

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);//设置初始文件目录
            saveFile.Filter = "数据文件(*.ini)|*.ini";
            saveFile.Title = "保存数据";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.WriteLine("Width=" + Convert.ToString(pictureBox.Width) + ";");
                streamWriter.WriteLine("Height=" + Convert.ToString(pictureBox.Height) + ";");
                streamWriter.WriteLine("Xmin=" + Convert.ToString(Xmin) + ";");
                streamWriter.WriteLine("Xmax=" + Convert.ToString(Xmax) + ";");
                streamWriter.WriteLine("Ymin=" + Convert.ToString(Ymin) + ";");
                streamWriter.WriteLine("Ymax=" + Convert.ToString(Ymax) + ";");
                streamWriter.WriteLine("escapeRadius=" + Convert.ToString(escapeRadius) + ";");
                streamWriter.WriteLine("escapeTimes=" + Convert.ToString(escapeTimes) + ";");
                streamWriter.WriteLine(DateTime.Now + ".");


                streamWriter.Close();
                fileStream.Close();
             }

        }

        #endregion


    }

 
    
    
    public class DrawMandelbrot
    {
        //要用到的属性，也就是我们要传递的参数
        public int threadID = 0;
       
        //包含参数的构造函数
        public DrawMandelbrot(int ID)
        {
            threadID = ID;
        }

        //要丢给线程执行的方法，本处无返回类型就是为了能让ThreadStart来调用
        public void ThreadProc()
        {
            decimal CX;//复常数C实部
            decimal CY;//复常数C虚部

            int times;//迭代次数

            //临时变量
            decimal X0;
            decimal Y0;
            decimal X1;
            decimal Y1;
          
            for (int bitX = threadID; bitX < MainForm.imageWidth; bitX += MainForm.threadTotal)
            {
                MainForm.progressBarValue++;

                for (int bitY = 0; bitY < MainForm.imageHeight; bitY++)
                {
                    X0 = 0;
                    Y0 = 0;
                    X1 = 0;
                    Y1 = 0;

                    CX = MainForm.Xmin + MainForm.bitWidth * bitX;//每个像素对应实轴坐标
                    CY = MainForm.Ymax - MainForm.bitHeight * bitY;//每个像素对应虚轴坐标

                    int escapeRadiusSquare = MainForm.escapeRadius * MainForm.escapeRadius;//逃逸半径平方

                    for (times = 0; times < MainForm.escapeTimes; times++)
                    {
                        //由f(n)推f(n+1)
                        X1 = X0 * X0 - Y0 * Y0 + CX;//对于给定的p和q，按照下面两行迭代，验证是否收敛。
                        Y1 = 2 * X0 * Y0 + CY;
                        X0 = X1;
                        Y0 = Y1;
                        if (X0 * X0 + Y0 * Y0 > escapeRadiusSquare)//如果z的模值大于2的时候，z的模值会很快趋于无穷。
                        {
                            break;
                        }
                    }

                    if (times == MainForm.escapeTimes)
                    {
                        MainForm.bitmapArray[bitX, bitY, 0] = 0;
                        MainForm.bitmapArray[bitX, bitY, 1] = 0;
                        MainForm.bitmapArray[bitX, bitY, 2] = 0;
                    }
                    else
                    {
                        MainForm.bitmapArray[bitX, bitY, 0] = (int)MainForm.colorRound_table[(MainForm.random100 * MainForm.random100 % MainForm.csMaxColorRoundValue + times * MainForm.rMover + MainForm.trackBarColorMoverValue) % (MainForm.csMaxColorRoundValue - 1)];
                        MainForm.bitmapArray[bitX, bitY, 1] = (int)MainForm.colorRound_table[(MainForm.random100 % MainForm.csMaxColorRoundValue + times * MainForm.gMover + MainForm.trackBarColorMoverValue) % (MainForm.csMaxColorRoundValue - 1)];
                        MainForm.bitmapArray[bitX, bitY, 2] = (int)MainForm.colorRound_table[(MainForm.random100 * MainForm.random100 * MainForm.random100 % MainForm.csMaxColorRoundValue + times * MainForm.bMover + MainForm.trackBarColorMoverValue) % (MainForm.csMaxColorRoundValue - 1)];
                        //MainForm.HSV2RGB(times);
                        //MainForm.bitmapArray[bitX, bitY, 0] = MainForm.R;
                        //MainForm.bitmapArray[bitX, bitY, 1] = MainForm.G;
                        //MainForm.bitmapArray[bitX, bitY, 2] = MainForm.B;
                    }
                    
                }
            }
 
            MainForm.threadLeft--;
             return;
       }
    }
}

