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
        
        public Form1()
        {    
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            time.Tick -= time_t;
             
            if (textBox1.Text==null || textBox1.Text.Trim()=="" || textBox1.Text.Trim() =="0")
            {
                MessageBox.Show("알람 시간을 설정 바랍니다.");

            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                time.Enabled = true;
                time.Interval = Convert.ToInt32(textBox1.Text) * 60 * 1000;
                time.Start();
                time.Tick += time_t;
            }
           


        }
        private void time_t(object sender, EventArgs e)
        {
            
            time.Stop();
            Form2 form2 = new Form2();
            
            time.Tick -= time_t;
            if(form2.ShowDialog()==DialogResult.OK)
            {
                frm_Start();
            }
            

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
            Application.Exit();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Start();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frm_Start()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                if(e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    button1.PerformClick();
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                {
                    if (MessageBox.Show("시스템을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //NO일때
                        MessageBox.Show("취소 하셨습니다.!!","취소");
                        textBox1.Focus();

                    }
                    else
                    {
                        Application.Exit();  //YES일때
                    }
                    
                }
            }
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.Focus();
        }
    }
}

