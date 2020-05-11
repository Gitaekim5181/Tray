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
    public delegate void eventBtnClick(object sender, EventArgs e);
    public partial class Form2 : Form
    {
        public event eventBtnClick btnClick;
        public Form2()
        {
            InitializeComponent();
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnClick(null, null);
            this.Close();
        }
    }
}
