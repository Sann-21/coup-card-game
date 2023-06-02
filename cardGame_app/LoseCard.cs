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
    public partial class LoseCard : Form
    {
        string choosen;

        public string choosen_card
        {
            get { return choosen; }
        }
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
        public LoseCard(string card_1, string card_2)
        {
            
            InitializeComponent();
            this.card1.Text = card_1;
            this.card2.Text = card_2;

            if(card_1 == "discarded")
            {
                this.card1.Enabled = false;
            }
            if (card_2 == "discarded")
            {
                this.card2.Enabled = false;
            }

        }

        private void card1_Click(object sender, EventArgs e)
        {
            choosen = this.card1.Text;
            this.Hide();
        }

        private void card2_Click(object sender, EventArgs e)
        {
            choosen = this.card2.Text;
            this.Hide();
        }
    }
}
