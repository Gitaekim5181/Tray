using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Tray
{
    public partial class Form1 : Form
    {
        Timer time = new Timer();
        Timer time_start = new Timer();
        DateTime start;

        public Form1()
        {    
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {

            time.Tick -= time_t;
            time_start.Tick -= time_starting;
            if (textBox1.Text==null || textBox1.Text.Trim()=="" || textBox1.Text.Trim() =="0")
            {

                MessageBox.Show("알람 시간 Default 50분으로 진행 합니다.");
                textBox1.Text = "50";
            }
            
            this.WindowState = FormWindowState.Minimized;
            time.Enabled = true;
            time.Interval = Convert.ToInt32(textBox1.Text) * 60 * 1000;
            time.Start();
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;  
            time.Tick += time_t;
            
            start = DateTime.Now.AddMilliseconds(time.Interval);
            time_start.Enabled = true;
            time_start.Interval = 1000;
            time_start.Start();
            time_start.Tick += time_starting;

        }

        private void time_t(object sender, EventArgs e)
        {
            
            time.Stop();
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            Form2 form2 = new Form2();
            time.Tick -= time_t;
            form2.bnt += new bnt1(button1_Click);
            if (form2.ShowDialog()==DialogResult.OK)
            {
                
                frm_Start();
            }

        }
        private void time_starting(object sender, EventArgs e)
        {
            TimeSpan time_Result = start - DateTime.Now;
            label5.Text = time_Result.ToString(@"hh\:mm\:ss") + " 후 알람";
        }
        private void Form1_Resize()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;

            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm_Start();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Close();
            //Application.Exit();
            End();
        }
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Start();
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            End();
            //Application.Exit();
        }
        private void frm_Start()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            textBox1.Focus();
            textBox1.Select(int.Parse(textBox1.Text), 0);

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                if(e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                     if(time.Enabled==true)
            {
                if(MessageBox.Show("알람이 진행 중 입니다 그래도 재시작 하시겠습니까?", "재시작", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                     this.WindowState = FormWindowState.Minimized;
                     return;
                }
                else
                {
                    textBox1.Text = textBox1.Text;
                    button1_Click(null, null);
                }

            }
                    button1.PerformClick();
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    End();
                }
            }
         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.Text = "50";
            textBox1.Focus();
            textBox1.Select(int.Parse(textBox1.Text),0);
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

        }
        private void End()
        {
            if (MessageBox.Show("시스템을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //NO일때
                MessageBox.Show("취소 하셨습니다.!!", "취소");
                if (this.WindowState == FormWindowState.Minimized)
                {
                    frm_Start();
                }
                    textBox1.Focus();

            }
            else
            {
                Application.Exit();  //YES일때
            }
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "50";
            button1_Click(null, null);

        }

        private void 재시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(time.Enabled==true)
            {
                if(MessageBox.Show("알람이 진행 중 입니다 그래도 재시작 하시겠습니까?", "재시작", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    textBox1.Text = textBox1.Text;
                    button1_Click(null, null);
                }

            }
            else
            {
                textBox1.Text = "50";
                button1_Click(null, null);
            }
            
        }

        private void 휴식ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           if(time.Enabled==true)
           {
                if (MessageBox.Show("휴식(10분) 알람을 진행 하시겠습니까?", "휴식(10분)", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    textBox1.Text = "10";
                    button1_Click(null, null);
                }
           }
           else
           {
              textBox1.Text = "10";
              button1_Click(null, null);

           }

        }
    }
}

