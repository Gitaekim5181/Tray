using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerTray
{
    public partial class Form1 : Form
    {
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        DateTime aTime;
        int time = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm_Show();
            if (timer1.Enabled)
            {
                panel1.Visible = true;
            }
        }

        private void frm_Show()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            txtTime.Focus();
            txtTime.Select(int.Parse(txtTime.Text), 0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    btnReset.PerformClick();
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    frm_Close();
                }
            }
        }

        private void frm_Close()
        {
            if (MessageBox.Show("시스템을 종료하시겠습니까?", "TimerTray", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    frm_Show();
                }
                txtTime.Focus();
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Tick -= popup_Show;

            if (String.IsNullOrEmpty(txtTime.Text))
            {
                MessageBox.Show("시간을 입력해 주세요.","TimerTray");
                txtTime.Focus();
            }

            this.WindowState = FormWindowState.Minimized;
            timer1.Start();
            timer1.Interval = Convert.ToInt32(txtTime.Text) * 60000;
            timer1.Tick += popup_Show;

            aTime = DateTime.Now.AddMilliseconds(timer1.Interval);
            timer2.Interval = 1000;
            timer2.Start();
            timer2.Tick += timeCheck;
            panel1.Visible = true;
        }

        private void popup_Show(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Form2 frm = new Form2();
            timer1.Stop();
            timer1.Tick -= popup_Show;
            timer2.Stop();
            timer2.Tick -= timeCheck;
            frm.btnClick += new eventBtnClick(btnStart_Click);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm_Show();
            }
        }

        private void timeCheck(object sender, EventArgs e)
        {
            TimeSpan result = aTime - DateTime.Now;
            lblTimer.Text = result.ToString(@"hh\:mm\:ss") + " 후 알람";
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frm_Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Tick -= popup_Show;
            timer2.Tick -= timeCheck;
            panel1.Visible = false;
            txtTime.Text = "";
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Show();
            if (timer1.Enabled)
            {
                panel1.Visible = true;
            }
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                if (MessageBox.Show("알람이 진행 중 입니다. 그래도 초기값으로 실행 하시겠습니까?", "TimerTray", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    txtTime.Text = "50";
                    btnStart_Click(null, null);
                }
            }
            else
            {
                txtTime.Text = "50";
                btnStart_Click(null, null);
            }
        }

        private void 재시작설정값ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                if (MessageBox.Show("알람이 진행 중 입니다 그래도 재시작 하시겠습니까?", "재시작", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    txtTime.Text = "50";
                    btnStart_Click(null, null);
                }
            }
            else
            {
                txtTime.Text = "50";
                btnStart_Click(null, null);
            }
        }

        private void 프로그램종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtTime.Text))
            {
                txtTime.Text = "5";
            }
            else
            {
                time = Convert.ToInt32(txtTime.Text) + 5;
                txtTime.Text = time.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTime.Text))
            {
                txtTime.Text = "10";
            }
            else
            {
                time = Convert.ToInt32(txtTime.Text) + 10;
                txtTime.Text = time.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTime.Text))
            {
                txtTime.Text = "50";
            }
            else
            {
                time = Convert.ToInt32(txtTime.Text) + 50;
                txtTime.Text = time.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTime.Text))
            {
                txtTime.Text = "60";
            }
            else
            {
                time = Convert.ToInt32(txtTime.Text) + 60;
                txtTime.Text = time.ToString();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            }
        }
    }
}
