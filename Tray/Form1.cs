
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    

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
            this.WindowState = FormWindowState.Minimized;

            time.Enabled = true;
            time.Interval = Convert.ToInt32(textBox1.Text) * 60 * 1000;
            time.Start();
            time.Tick += time_t;
            

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
    }
}

