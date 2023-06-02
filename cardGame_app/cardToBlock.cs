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
    public partial class cardToBlock : Form
    {
        string temp;
        public cardToBlock()
        {
            InitializeComponent();
        }

        public string get_choosenCard
        {
            get { return temp; }
        }
        private void buttonCap_Click(object sender, EventArgs e)
        {
            temp = buttonCap.Text;
            this.Hide();
        }

        private void buttonAmb_Click(object sender, EventArgs e)
        {
            temp = buttonAmb.Text;
            this.Hide();
        }
    }
}
