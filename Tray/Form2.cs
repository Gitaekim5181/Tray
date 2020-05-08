
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
    public delegate void bnt1(object sender, EventArgs e);

    public partial class Form2 : Form
    {
        public event bnt1 bnt;
        public Form2()
        {
            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bnt(null, null);
            this.Close();
        }   
    
    }
}

