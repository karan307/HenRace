using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenRace
{
    public class HenBet 
    {
        public int Amounts; //The amount of cash that was bet
        public int hen; //The number of the hen the bet is on
        public HenClients Punter; //the guy who placed the bet

        public string GetTheDescription()
        {
            string description = "";
            description = this.Punter.ClientName + " bets " + Amounts + " dollars on Hen #" + hen;
            return description;
        }

        public int PayOut(int winner)
        {
            if (hen == winner)
            {
                return Amounts;
            }
            else
            {
                return -Amounts;
            }
        }
    }
}
