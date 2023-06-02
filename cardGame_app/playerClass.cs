using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame_app
{
    class playerClass
    {
        string name = "";
        int card = 2;
        string[] cardtype = new string[] { "1", "2" };
        int coin = 2;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Card
        {
            get { return card; }
            set { card = value; }
        }
        public int Coin
        {
            get { return coin; }
            set { coin = value; }
        }

        public string[] Cardtype
        {
            get { return cardtype; }
            set { cardtype = value; }
        }
    }
}
