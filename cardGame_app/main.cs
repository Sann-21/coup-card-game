using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace cardGame_app
{
    public partial class main : Form
    {
        
        public int curplayer = 1;
        challenge challengeForm = new challenge();
        cardToBlock card_to_block = new cardToBlock();

        List<string> cards = new List<string>();
        List<playerClass> players = new List<playerClass>();
        private int confirmNextplayer(int i, List<playerClass> p)
        {
            //i is cur player ... /this fun also check the winner

            MessageBox.Show("Ready next player!");
            bool flag = false;
            int check = 0;
            while (flag == false)
            {
                check += 1;
                if (i == 6)
                {
                    i = 1;
                    if (p[i - 1].Card > 0)
                    {
                        flag = true;

                        if (check == 6)
                        {
                            MessageBox.Show("Winner is " + i);
                        }
                        check = 0;
                    }
                }
                else
                {
                    i++;
                    if (p[i - 1].Card > 0)
                    {
                        flag = true;
                        if (check == 6)
                        {
                            MessageBox.Show("Winner is " + i);
                        }
                        check = 0;
                    }
                }
                card1.Text = p[i - 1].Cardtype[0];
                card2.Text = p[i - 1].Cardtype[1];
                //change back color of curplayer
                switch (i)
                {
                    case 1:
                        p1Panel.BackColor = Color.Turquoise;
                        p2Panel.BackColor = Color.Transparent;
                        p3Panel.BackColor = Color.Transparent;
                        p4Panel.BackColor = Color.Transparent;
                        p5Panel.BackColor = Color.Transparent;
                        p6Panel.BackColor = Color.Transparent;
                        break;
                    case 2:
                        p1Panel.BackColor = Color.Transparent;
                        p2Panel.BackColor = Color.Turquoise;
                        p3Panel.BackColor = Color.Transparent;
                        p4Panel.BackColor = Color.Transparent;
                        p5Panel.BackColor = Color.Transparent;
                        p6Panel.BackColor = Color.Transparent;
                        break;
                    case 3:
                        p1Panel.BackColor = Color.Transparent;
                        p2Panel.BackColor = Color.Transparent;
                        p3Panel.BackColor = Color.Turquoise;
                        p4Panel.BackColor = Color.Transparent;
                        p5Panel.BackColor = Color.Transparent;
                        p6Panel.BackColor = Color.Transparent;
                        break;
                    case 4:
                        p1Panel.BackColor = Color.Transparent;
                        p2Panel.BackColor = Color.Transparent;
                        p3Panel.BackColor = Color.Transparent;
                        p4Panel.BackColor = Color.Turquoise;
                        p5Panel.BackColor = Color.Transparent;
                        p6Panel.BackColor = Color.Transparent;
                        break;
                    case 5:
                        p1Panel.BackColor = Color.Transparent;
                        p2Panel.BackColor = Color.Transparent;
                        p3Panel.BackColor = Color.Transparent;
                        p4Panel.BackColor = Color.Transparent;
                        p5Panel.BackColor = Color.Turquoise;
                        p6Panel.BackColor = Color.Transparent;
                        break;
                    case 6:
                        p1Panel.BackColor = Color.Transparent;
                        p2Panel.BackColor = Color.Transparent;
                        p3Panel.BackColor = Color.Transparent;
                        p4Panel.BackColor = Color.Transparent;
                        p5Panel.BackColor = Color.Transparent;
                        p6Panel.BackColor = Color.Turquoise;
                        break;
                }

            }

            Debug.WriteLine("next player" + i);
            return i;
        }
        static void shuffle(List<string> cards)
        {

            Random random = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                string temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
        static bool objection(int pl, string action, List<playerClass> p)
        {
            string msg = p[pl - 1].Name + " want to " + action + ". Anyone want to object or disbelieve? ";
            DialogResult dr = MessageBox.Show(msg,
                      "Believe OR Not", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
            }
            return true;
        }
        static bool checkCard(string card, int toCheck, List<playerClass> p)
        {
            if (p[toCheck-1].Cardtype[0] == card || p[toCheck - 1].Cardtype[1] == card)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        static void drawCard(List<playerClass> p, List<string> cards, string toDiscard, int pl)
        {
            /*MessageBox.Show(p[pl - 1].Cardtype[0], p[pl - 1].Cardtype[1]);*/
            MessageBox.Show("Player " + pl + " redraw card.");

            if(p[pl-1].Cardtype[0] == toDiscard)
            {
                p[pl - 1].Cardtype[0] = cards[0];
                cards[0] = toDiscard;
            }
            else
            {
                p[pl - 1].Cardtype[1] = cards[0];
                cards[0] = toDiscard;
            }
            shuffle(cards);
            MessageBox.Show(p[pl - 1].Cardtype[0]+" , " + p[pl - 1].Cardtype[1], "New cards are" );
           /* for (int i = 0; i < 3; i++)
            {
                MessageBox.Show(cards[i]);
            }*/
        }
        static string loseCard(int losePl, List<playerClass> p)
        {
            string choosen;
            bool flag = false;
            int i = 0;
            string temp="";
            MessageBox.Show(p[losePl-1].Name + " lost the challange. Please discard a card.");
            LoseCard lc = new LoseCard(p[losePl - 1].Cardtype[0], p[losePl - 1].Cardtype[1]);
            lc.ShowDialog();
            choosen = lc.choosen_card;
            while(flag == false)
            {
                if(p[losePl - 1].Cardtype[i] == choosen)
                {
                    temp = p[losePl - 1].Cardtype[i];
                    p[losePl - 1].Cardtype[i] = "discarded";
                    p[losePl - 1].Card -= 1;
                    flag = true;
                }
                i++;
            }
            return temp;
        }
        private void changeCoinUI(int i)
        {
            //change coin UI
            switch (i)
            {
                case 1:
                    this.p1coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
                case 2:
                    this.p2coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
                case 3:
                    this.p3coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
                case 4:
                    this.p4coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
                case 5:
                    this.p5coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
                case 6:
                    this.p6coin.Text = players[i - 1].Coin.ToString(); ;
                    break;
            }

        }

        private void showDeadCard(int i,string temp)
        {
            switch (i)
            {
                case 1:
                    if (this.p1b1.Text == "unknown")
                    {
                        this.p1b1.Text = temp;
                    }
                    else
                    {
                        this.p1b2.Text = temp;
                    }
                    break;
                case 2:
                    if (this.p2b1.Text == "unknown")
                    {
                        this.p2b1.Text = temp;
                    }
                    else
                    {
                        this.p2b2.Text = temp;
                    }
                    break;
                case 3:
                    if (this.p3b1.Text == "unknown")
                    {
                        this.p3b1.Text = temp;
                    }
                    else
                    {
                        this.p3b2.Text = temp;
                    }
                    break;
                case 4:
                    if (this.p4b1.Text == "unknown")
                    {
                        this.p4b1.Text = temp;
                    }
                    else
                    {
                        this.p4b2.Text = temp;
                    }
                    break;
                case 5:
                    if (this.p5b1.Text == "unknown")
                    {
                        this.p5b1.Text = temp;
                    }
                    else
                    {
                        this.p5b2.Text = temp;
                    }
                    break;
                case 6:
                    if (this.p6b1.Text == "unknown")
                    {
                        this.p6b1.Text = temp;
                    }
                    else
                    {
                        this.p6b2.Text = temp;
                    }
                    break;
            }
        }

        private void amb_swap(string choosen_1 , string choosen_2)
        {
            string temp1 = " error " ;
            string temp2 = " error  ";
            
           /* Debug.WriteLine("ori deck :" + cards[0] + " " + cards[1] + " " + cards[2]);
            Debug.WriteLine("ori card :" + players[curplayer - 1].Cardtype[0] + " " + players[curplayer - 1].Cardtype[1]);
            Debug.WriteLine("choosen card :" + choosen_1 + " " + choosen_2);*/
            if(players[curplayer-1].Card == 1)
            {
                if(players[curplayer - 1].Cardtype[0] == choosen_1 || players[curplayer - 1].Cardtype[1] == choosen_1){
                    shuffle(cards);
                    //
                    Debug.WriteLine("");
                    Debug.WriteLine("new deck :" + cards[0] + " " + cards[1] + " " + cards[2]);
                    Debug.WriteLine("new card :" + players[curplayer - 1].Cardtype[0] + " " + players[curplayer - 1].Cardtype[1]);
                    return;
                }
                // storing original card and swapping
                if(players[curplayer - 1].Cardtype[0] == "discarded")
                {
                    temp1 = players[curplayer - 1].Cardtype[1];
                    players[curplayer - 1].Cardtype[1] = choosen_1;
                }
                else
                {
                    temp1 = players[curplayer - 1].Cardtype[0];
                    players[curplayer - 1].Cardtype[0] = choosen_1;

                }
                
                cards[0] = temp1;
            }
            else
            {
                // pick same cards
                if ((players[curplayer - 1].Cardtype[0] == choosen_1 && players[curplayer - 1].Cardtype[1] == choosen_2)
                    || (players[curplayer - 1].Cardtype[0] == choosen_2 && players[curplayer - 1].Cardtype[1] == choosen_1))
                {
                    shuffle(cards);
                    //
                    Debug.WriteLine("");
                    Debug.WriteLine("new deck :" + cards[0] + " " + cards[1] + " " + cards[2]);
                    Debug.WriteLine("new card :" + players[curplayer - 1].Cardtype[0] + " " + players[curplayer - 1].Cardtype[1]);
                    return;
                }
                // pick completely different cards
                else if (players[curplayer - 1].Cardtype[0] != choosen_1 && players[curplayer - 1].Cardtype[1] != choosen_2
                    && players[curplayer - 1].Cardtype[0] != choosen_2 && players[curplayer - 1].Cardtype[1] != choosen_1)
                {
                    temp1 = players[curplayer - 1].Cardtype[0];
                    temp2 = players[curplayer - 1].Cardtype[1];

                    players[curplayer - 1].Cardtype[0] = choosen_1;
                    players[curplayer - 1].Cardtype[1] = choosen_2;

                    cards[0] = temp1;
                    cards[1] = temp2;
                    
                }
                //1 same card
                else if(players[curplayer - 1].Cardtype[0] == choosen_1 && players[curplayer - 1].Cardtype[1] != choosen_2)
                {
                    temp2 = players[curplayer - 1].Cardtype[1];
 
                    players[curplayer - 1].Cardtype[1] = choosen_2;

                    if (cards[1] == choosen_2)
                    {
                        cards[1] = temp2;

                    }
                    else
                    {
                        cards[0] = temp2;
                    }
                }
                else if (players[curplayer - 1].Cardtype[0] != choosen_1 && players[curplayer - 1].Cardtype[1] == choosen_2)
                {
                    temp1 = players[curplayer - 1].Cardtype[0];

                    players[curplayer - 1].Cardtype[0] = choosen_1;

                    if (cards[0] == choosen_1)
                    {
                        cards[0] = temp1;
                    }
                    else
                    {
                        cards[1] = temp1;

                    }

                }
                else if (players[curplayer - 1].Cardtype[1] != choosen_1 && players[curplayer - 1].Cardtype[0] == choosen_2)
                {
                    temp1 = players[curplayer - 1].Cardtype[1];
                    players[curplayer - 1].Cardtype[1] = choosen_1;

                    if (cards[0] == choosen_1)
                    {
                        cards[0] = temp1;
                    }
                    else
                    {
                        cards[1] = temp1;

                    }

                }
                else if (players[curplayer - 1].Cardtype[0] != choosen_2 && players[curplayer - 1].Cardtype[1] == choosen_1)
                {
                    temp2 = players[curplayer - 1].Cardtype[0];
                    players[curplayer - 1].Cardtype[0] = choosen_2;

                    if(cards[1] == choosen_2)
                    {
                        cards[1] = temp2;

                    }
                    else
                    {
                        cards[0] = temp2;
                    }

                }

            }
            shuffle(cards);
            MessageBox.Show(" New cards are " + players[curplayer - 1].Cardtype[0] + " , " + players[curplayer - 1].Cardtype[1]);
           
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("All Players check thier cards, start from player 1");
            int k;
            int j = 1;
            for (k = 0; k < 6; k++)
            {
                MessageBox.Show(players[k].Cardtype[0] + " , " + players[k].Cardtype[1], "Player " + j);
                j++;
                if (j != 7)
                {
                    MessageBox.Show("Player " + j + " turn");
                }
            }
        }

        public main()
        {
            InitializeComponent();
            this.Shown += Form_Shown;
            this.Font = new Font("Arial", 11, FontStyle.Regular);

            //all playable cards
            for (int i = 0; i < 3; i++)
            {
                cards.Add("Duke");
                cards.Add("Captain");
                cards.Add("Ambassador");
                cards.Add("Assassin");
                cards.Add("Contessa");
            }

            shuffle(cards);

            playerClass player1 = new playerClass();
            playerClass player2 = new playerClass();
            playerClass player3 = new playerClass();
            playerClass player4 = new playerClass();
            playerClass player5 = new playerClass();
            playerClass player6 = new playerClass();

            player1.Name = "player1";
            player2.Name = "player2";
            player3.Name = "player3";
            player4.Name = "player4";
            player5.Name = "player5";
            player6.Name = "player6";

            /*player1.Card = 0;
            player6.Card = 0;
            player3.Card = 0;
            player4.Card = 0;
            player5.Card = 0;*/

            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            players.Add(player5);
            players.Add(player6);

            string lastElement;

            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player1.Cardtype[i] = lastElement;
                Debug.WriteLine(player1.Cardtype[i]);
            }
            Debug.WriteLine("");
            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player2.Cardtype[i] = lastElement;
                Debug.WriteLine(player2.Cardtype[i]);
            }
            Debug.WriteLine("");
            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player3.Cardtype[i] = lastElement;
                Debug.WriteLine(player3.Cardtype[i]);
            }
            Debug.WriteLine("");
            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player4.Cardtype[i] = lastElement;
                Debug.WriteLine(player4.Cardtype[i]);
            }
            Debug.WriteLine("");
            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player5.Cardtype[i] = lastElement;
                Debug.WriteLine(player5.Cardtype[i]);
            }
            Debug.WriteLine("");
            for (int i = 0; i <= 1; i++)
            {
                lastElement = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                player6.Cardtype[i] = lastElement;
                Debug.WriteLine(player6.Cardtype[i]);
            }
            Debug.WriteLine("end");

            //delete this
            /* foreach (var m in cards)
             {
                 Debug.WriteLine(m);
             }*/
            
            
        }

        private void b_income_Click(object sender, EventArgs e)
        {
            bool done = false;
            Debug.WriteLine("current player" + curplayer);

            Debug.WriteLine("coin is " + players[curplayer - 1].Coin);
            if (players[curplayer - 1].Coin >= 10)
            {
                MessageBox.Show("U already have 10 coins. Please choose other action");
            }
            else
            {
                players[curplayer - 1].Coin = players[curplayer - 1].Coin + 1;
                done = true;
            }
            Debug.WriteLine("new coin is " + players[curplayer - 1].Coin);

            changeCoinUI(curplayer);

            if (done == true)
            {
                int j = confirmNextplayer(curplayer, players);
                curplayer = j;
            }
        }

        private void b_aid_Click(object sender, EventArgs e)
        {
            if (players[curplayer - 1].Coin >= 10)
            {
                MessageBox.Show("U already have 10 coins. Please choose other action");
                return;
            }
            bool flag = objection(curplayer, "Foreign Aid", players);
            string temp;
           
            if (flag == false)
            {

                Debug.WriteLine("current player" + curplayer);

                Debug.WriteLine("coin is " + players[curplayer - 1].Coin);

                players[curplayer - 1].Coin = players[curplayer - 1].Coin + 2;
                
                Debug.WriteLine("new coin is " + players[curplayer - 1].Coin);

                //change coin UI
                changeCoinUI(curplayer);

                int j = confirmNextplayer(curplayer, players);
                curplayer = j;
            }
            else
            {
                bool cardCheck;
                challengeForm.ShowDialog();

                string msg = "Do you believe " + players[challengeForm.get_pl - 1].Name + " has 'Duke' to block you?";
                DialogResult dia = MessageBox.Show(msg,
                     "Believe OR Not", MessageBoxButtons.YesNo);

                switch (dia)
                {
                    case DialogResult.Yes:
                         int j = confirmNextplayer(curplayer, players);
                         curplayer = j;
                        
                        break;
                    case DialogResult.No:
                        
                        cardCheck = checkCard("Duke", challengeForm.get_pl ,players );
                        if(cardCheck == true)
                        {
                            temp = loseCard(curplayer,players);
                            //showing dead card
                            showDeadCard(curplayer, temp);
                            drawCard(players, cards, "Duke", challengeForm.get_pl);
                            
                            curplayer = confirmNextplayer(curplayer, players);

                        }
                        else
                        {
                            temp = loseCard(challengeForm.get_pl, players);
                            //showing dead card
                            showDeadCard(challengeForm.get_pl, temp);

                            //get coins as normal step;
                            players[curplayer - 1].Coin = players[curplayer - 1].Coin + 2;
                            
                            Debug.WriteLine("new coin is " + players[curplayer - 1].Coin);
                            //change coin UI
                            changeCoinUI(curplayer);

                            curplayer = confirmNextplayer(curplayer, players);

                        }
                        break;
                    
                }
            }
        }

        private void b_tax_Click(object sender, EventArgs e)
        {
            if (players[curplayer - 1].Coin >= 10)
            {
                MessageBox.Show("U already have 10 coins. Please choose other action");
                return;
            }
            bool flag = objection(curplayer, "Tax", players);
            string temp;

            if(flag == false)
            {
                Debug.WriteLine("current player" + curplayer);

                Debug.WriteLine("coin is " + players[curplayer - 1].Coin);
                
                players[curplayer - 1].Coin = players[curplayer - 1].Coin + 3;
                
                Debug.WriteLine("new coin is " + players[curplayer - 1].Coin);

                //change coin UI
                changeCoinUI(curplayer);
                int j = confirmNextplayer(curplayer, players);
                curplayer = j;
            }
            else
            {
                // check if player has Duke , if he has-challenger lose card , player get coins and redraw a card
                challengeForm.ShowDialog();
                MessageBox.Show(challengeForm.get_pl.ToString());
                bool cardCheck = checkCard("Duke", curplayer, players);
                if ( cardCheck == true)
                {
                    temp = loseCard(challengeForm.get_pl, players);
                    //show dead card
                    showDeadCard(challengeForm.get_pl, temp);

                    //add coin as normal
                    Debug.WriteLine("coin is " + players[curplayer - 1].Coin);
                    
                    players[curplayer - 1].Coin = players[curplayer - 1].Coin + 3;
                    
                    drawCard(players, cards, "Duke", curplayer);
                    
                    Debug.WriteLine("new coin is " + players[curplayer - 1].Coin);

                    //change coin UI
                    changeCoinUI(curplayer);

                    int j = confirmNextplayer(curplayer, players);
                    curplayer = j;
                    
                }
                else
                {
                    temp = loseCard(curplayer, players);
                    //showing dead card
                    showDeadCard(curplayer, temp);

                    int j = confirmNextplayer(curplayer, players);
                    curplayer = j;
                    
                }
            }
            
        }

        private void b_steal_Click(object sender, EventArgs e)
        {
            if (players[curplayer - 1].Coin >= 10)
            {
                MessageBox.Show("U already have 10 coins. Please choose other action");
                return;
            }
            
            challengeForm.ShowDialog();
            if (players[challengeForm.get_pl - 1].Card == 0 || curplayer == challengeForm.get_pl || players[challengeForm.get_pl - 1].Coin <= 0)
            {
                MessageBox.Show("You cannot choose this player");
                return;
            }
            if (players[challengeForm.get_pl - 1].Card == 0)
            {
                MessageBox.Show("You cannot choose dead player");
                return;
            }

            MessageBox.Show("Player " + curplayer + " want to steal from Player " + challengeForm.get_pl);
            string msg =  "Do player "+ challengeForm.get_pl + " believe " + "Player " + curplayer + " has 'Captain'";
            DialogResult dia_1 = MessageBox.Show(msg,
                 "Player " + curplayer + " want to steal from Player " + challengeForm.get_pl, MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);
            bool card_check;
            string temp;
            if (dia_1 == DialogResult.Yes)
            {
                DialogResult dia_2 = MessageBox.Show(
                "Do " + players[challengeForm.get_pl -1].Name + " want to block ?", " ", MessageBoxButtons.YesNo
                 );

                if (dia_2 == DialogResult.Yes)
                {
                    
                    card_to_block.ShowDialog();
                    if(card_to_block.get_choosenCard == "Captain")
                    {

                        DialogResult dia_3 = MessageBox.Show(
                        "Do player "+ curplayer +" believe  " + players[challengeForm.get_pl - 1].Name + " has 'Captain'.", " ", MessageBoxButtons.YesNo);
                        if (dia_3 == DialogResult.No)
                        {
                            card_check = checkCard("Captain", challengeForm.get_pl, players);
                            if (card_check == true)
                            {
                                temp = loseCard(curplayer, players);
                                //showing dead card
                                showDeadCard(curplayer, temp);
                                //
                                drawCard(players, cards, "Captain", challengeForm.get_pl);
                                curplayer = confirmNextplayer(curplayer, players);
                               
                            }
                            else
                            {
                                //if blocker doesn't have his card
                                temp = loseCard(challengeForm.get_pl, players);
                                //showing dead card
                                showDeadCard(challengeForm.get_pl, temp);
                                //get coin
                                players[curplayer - 1].Coin += 2;
                                players[challengeForm.get_pl - 1].Coin -= 2;
                               
                                changeCoinUI(curplayer);
                                changeCoinUI(challengeForm.get_pl);

                                curplayer = confirmNextplayer(curplayer, players);
                            }
                        }
                        else
                        {
                            curplayer = confirmNextplayer(curplayer, players); 
                        }
                    }
                    else
                    {
                        MessageBox.Show("am");
                        DialogResult dia_3 = MessageBox.Show(
                        "Do player " + curplayer + " believe  " + players[challengeForm.get_pl - 1].Name + " has 'Ambassador'.", " ", MessageBoxButtons.YesNo);
                        if (dia_3 == DialogResult.No)
                        {
                            card_check = checkCard("Ambassador", challengeForm.get_pl, players);
                            if (card_check == true)
                            {
                                temp = loseCard(curplayer, players);
                                //showing dead card
                                showDeadCard(curplayer, temp);
                                //
                                drawCard(players, cards, "Ambassador", challengeForm.get_pl);
                                curplayer = confirmNextplayer(curplayer, players);

                            }
                            else
                            {
                                //if blocker doesn't have his card
                                temp = loseCard(challengeForm.get_pl, players);
                                //showing dead card
                                showDeadCard(challengeForm.get_pl, temp);
                                //get coin
                                players[curplayer - 1].Coin += 2;
                                players[challengeForm.get_pl - 1].Coin -= 2;

                                changeCoinUI(curplayer);
                                changeCoinUI(challengeForm.get_pl);

                                curplayer = confirmNextplayer(curplayer, players);
                            }
                        }
                        else
                        {
                            curplayer = confirmNextplayer(curplayer, players);
                        }
                    }
                    

                }
                else
                {
                    players[curplayer - 1].Coin += 2;
                    players[challengeForm.get_pl - 1].Coin -= 2;

                    changeCoinUI(curplayer);
                    changeCoinUI(challengeForm.get_pl);
                }
                
            }
            else
            {
                //
                card_check = checkCard("Captain", curplayer, players);
                if (card_check == true)
                {
                    temp = loseCard(challengeForm.get_pl, players);
                    //showing dead card
                    showDeadCard(challengeForm.get_pl, temp);
                    //
                    //get coin
                    players[curplayer - 1].Coin += 2;
                    players[challengeForm.get_pl - 1].Coin -= 2;

                    changeCoinUI(curplayer);
                    changeCoinUI(challengeForm.get_pl);

                    drawCard(players, cards, "Captain", curplayer);
                    curplayer = confirmNextplayer(curplayer, players);

                }
                else
                {
                    //if curplayer doesn't have his card
                    temp = loseCard(curplayer, players);
                    //showing dead card
                    showDeadCard(curplayer, temp);
                   

                    curplayer = confirmNextplayer(curplayer, players);
                }
            }
        }

        private void b_coup_Click(object sender, EventArgs e)
        {
            if (players[curplayer - 1].Coin < 7)
            {
                MessageBox.Show("You don't have enough coins");
                return;
            }
            challengeForm.ShowDialog();
            if (players[challengeForm.get_pl - 1].Card == 0 || curplayer == challengeForm.get_pl || players[challengeForm.get_pl - 1].Coin <= 0)
            {
                MessageBox.Show("You cannot choose this player");
                return;
            }
            if (players[challengeForm.get_pl - 1].Card == 0)
            {
                MessageBox.Show("You cannot choose dead player");
                return;
            }
            string temp = loseCard(challengeForm.get_pl, players);
            //showing dead card
            showDeadCard(challengeForm.get_pl, temp);
            players[curplayer - 1].Coin -= 7;
            changeCoinUI(curplayer);
            curplayer = confirmNextplayer(curplayer, players);
            
        }

        private void b_assassinate_Click(object sender, EventArgs e)
        {
            bool cardCheck;
            string temp;
            if (players[curplayer - 1].Coin < 3)
            {
                MessageBox.Show("You don't have enough coins");
                return;
            }
            challengeForm.ShowDialog();
            if (players[challengeForm.get_pl-1].Card == 0 || curplayer == challengeForm.get_pl || players[challengeForm.get_pl - 1].Coin <= 0)
            {
                MessageBox.Show("You cannot choose this player");
                return;
            }

            DialogResult dia_believe_assassin = MessageBox.Show("Do player" + challengeForm.get_pl + " beleive player" + curplayer + " has Assassin", " " , MessageBoxButtons.YesNo);

            if(dia_believe_assassin == DialogResult.Yes)
            {
                //asking want to block
                DialogResult dia_block = MessageBox.Show("Do player" + challengeForm.get_pl + " want to block with Contessa", " ", MessageBoxButtons.YesNo);
                if(dia_block == DialogResult.Yes)
                {
                    //asking attacker
                    DialogResult dia_counter = MessageBox.Show("Do player" + curplayer + " believe player"+ challengeForm.get_pl +  " has Contessa", " ", MessageBoxButtons.YesNo);
                    //resolving
                    if (dia_counter == DialogResult.Yes)
                    {
                        players[curplayer - 1].Coin -= 3;
                        changeCoinUI(curplayer);

                        curplayer = confirmNextplayer(curplayer, players);
                    }
                    else
                    {
                        cardCheck = checkCard("Contessa", challengeForm.get_pl, players);
                        {
                            //he has card
                            if(cardCheck == true)
                            {
                                temp = loseCard(curplayer, players);
                                showDeadCard(curplayer, temp);

                                players[curplayer - 1].Coin -= 3;
                                changeCoinUI(curplayer);

                                drawCard(players, cards, "Contessa", challengeForm.get_pl);

                                curplayer = confirmNextplayer(curplayer, players);

                            }
                            else
                            {
                                temp = loseCard(challengeForm.get_pl, players);
                                //showing dead card
                                showDeadCard(challengeForm.get_pl, temp);

                                players[curplayer - 1].Coin -= 3;
                                changeCoinUI(curplayer);

                                if (players[challengeForm.get_pl-1].Card == 0)
                                {
                                    curplayer = confirmNextplayer(curplayer, players);
                                    return;
                                }
                                temp = loseCard(challengeForm.get_pl, players);
                                //showing dead card
                                showDeadCard(challengeForm.get_pl, temp);

                                curplayer = confirmNextplayer(curplayer, players);
                            }
                        }
                    }
                }
                else
                {
                    temp = loseCard(challengeForm.get_pl, players);
                    //showing dead card
                    showDeadCard(challengeForm.get_pl, temp);

                    //coin lose
                    players[curplayer - 1].Coin -= 3;
                    changeCoinUI(curplayer);

                    curplayer = confirmNextplayer(curplayer, players);
                }
                
            }
            else
            {
                //not believed
                cardCheck = checkCard("Assassin", curplayer, players);
                if(cardCheck == true)
                {
                    temp = loseCard(challengeForm.get_pl, players);
                    //showing dead card
                    showDeadCard(challengeForm.get_pl, temp);

                    //coin lose
                    players[curplayer - 1].Coin -= 3;
                    changeCoinUI(curplayer);

                    if (players[challengeForm.get_pl - 1].Card == 0)
                    {
                        drawCard(players, cards, "Assassin ", curplayer);
                        curplayer = confirmNextplayer(curplayer, players);
                        return;
                    }
                    // lose next card
                    temp = loseCard(challengeForm.get_pl, players);
                    //showing dead card
                    showDeadCard(challengeForm.get_pl, temp);
                    //drawcard
                    drawCard(players, cards, "Assassin ", curplayer);

                    //confirmNextplayer player
                    curplayer = confirmNextplayer(curplayer, players);

                }
                else
                {
                    temp = loseCard(curplayer, players);
                    //showing dead card
                    showDeadCard(curplayer, temp);
                    curplayer = confirmNextplayer(curplayer, players);
                }
            }
        }

        private void b_ambassador_Click(object sender, EventArgs e)
        {
            bool flag = objection(curplayer, " swap card with Ambassador action", players);
            string[] arr_cards = new string[2];
            arr_cards[0] = players[curplayer - 1].Cardtype[0];
            arr_cards[1] = players[curplayer - 1].Cardtype[1];
            ambassador_form amb_form = new ambassador_form(arr_cards, cards , players[curplayer - 1].Card);

           
            if (flag == false)
            {
                amb_form.ShowDialog();
                amb_swap(amb_form.get_choosen_1(), amb_form.get_choosen_2());
                curplayer = confirmNextplayer(curplayer, players);

            }
            else
            {
                challengeForm.ShowDialog();
                string temp;
                bool cardCheck;
                cardCheck = checkCard("Ambassador", curplayer, players);
                if(cardCheck == false)
                {
                    temp = loseCard(curplayer, players);
                    //showing dead card
                    showDeadCard(curplayer, temp);

                    curplayer = confirmNextplayer(curplayer, players);
                }
                else
                {
                    temp = loseCard(challengeForm.get_pl, players);
                    //showing dead card
                    showDeadCard(challengeForm.get_pl, temp);

                    amb_form.ShowDialog();
                    amb_swap(amb_form.get_choosen_1(), amb_form.get_choosen_2());
                    curplayer = confirmNextplayer(curplayer, players);
                }
            }
        }
    }
}

