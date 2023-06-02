using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cardGame_app
{
    public partial class challenge : Form
    {
        int ii;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // Disable the system close button
                cp.ClassStyle |= 0x200;

                return cp;
            }
        }
        public challenge()
        {
            InitializeComponent();
            
        }

        public int get_pl
        {
            get { return ii; }
        }
        private void b_confirm_Click(object sender, EventArgs e)
        {
            
            if(radioButton1.Checked == true)
            {
                ii = 1;
            }
            else if (radioButton2.Checked == true)
            {
                ii = 2;
            }
            else if (radioButton3.Checked == true)
            {
                ii = 3;
            }
            else if (radioButton4.Checked == true)
            {
                ii = 4;
            }
            else if (radioButton5.Checked == true)
            {
                ii = 5;
            }
            else if (radioButton6.Checked == true)
            {
                ii = 6;
            }
            this.Hide();
           
        }
    }
}
