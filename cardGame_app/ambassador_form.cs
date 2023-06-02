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
    public partial class ambassador_form : Form
    {
        private int checkCounter;
        private string choosen_1 = "none";
        private string choosen_2 = "none";
        private int max_card;
        private int ii;
        public string get_choosen_1()
        {
            return choosen_1;
        }
        public string get_choosen_2()
        {
            return choosen_2;
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
        public ambassador_form(string[] arr_cards, List<string> cards ,int i)
        {
            InitializeComponent();
            ii = i;
            if (i == 2)
            {
                max_card = 3;
                checkBox1.Text = arr_cards[0];
                checkBox2.Text = arr_cards[1];

                checkBox3.Text = cards[0];
                checkBox4.Text = cards[1];
            }
            else
            {
                max_card = 2;
                if(arr_cards[0] == "discarded")
                {
                    checkBox1.Text = arr_cards[1];
                }
                else
                {
                    checkBox1.Text = arr_cards[0];
                }
                checkBox2.Text = cards[0];
                checkBox3.Hide();
                checkBox4.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == max_card)
            {
                if (max_card == 3)
                {
                    MessageBox.Show("You can only choose 2 cards");
                }
                else
                {
                    MessageBox.Show("You can only choose 1 cards");
                }
                box.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == max_card)
            {
                if (max_card == 3)
                {
                    MessageBox.Show("You can only choose 2 cards");
                }
                else
                {
                    MessageBox.Show("You can only choose 1 cards");
                }
                box.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == max_card)
            {
                if (max_card == 3)
                {
                    MessageBox.Show("You can only choose 2 cards");
                }
                else
                {
                    MessageBox.Show("You can only choose 1 cards");
                }
                box.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
                checkCounter++;
            else
                checkCounter--;

            // prevent checking
            if (checkCounter == 3)
            {
                if (max_card == 3)
                {
                    MessageBox.Show("You can only choose 2 cards");
                }
                else
                {
                    MessageBox.Show("You can only choose 1 cards");
                }
                box.Checked = false;
            }
        }

        private void comfirm_b_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkboxes = new List<CheckBox>()
            {
                checkBox1, checkBox2, checkBox3, checkBox4 
            };

            List<string> checkedItems = new List<string>();

            foreach (CheckBox checkbox in checkboxes)
            {
                if (checkbox.Checked)
                {
                    checkedItems.Add(checkbox.Text);
                }
            }
            //
            if(ii > checkedItems.Count && ii ==2)
            {
                MessageBox.Show("Choose two cards");
                return;
            }
            else if(ii > checkedItems.Count && ii == 1)
            {
                MessageBox.Show("Choose a card");
                return;
            }
            //
            if ( ii == 2)
            {
                choosen_1 = checkedItems[0];
                choosen_2 = checkedItems[1];
            }
            else
            {
                choosen_1 = checkedItems[0];
            }
      
            this.Hide();
        }
    }
}
