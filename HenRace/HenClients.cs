using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HenRace
{
    public class HenClients
    {
        public string ClientName; //the client's name
        public HenBet henBet; //an istance of Bet that has his bet
        public int Cashes; //how much cash he has

        //punter's control on the form

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdatingLabels()
        {
            MyRadioButton.Text = ClientName + " has " + Cashes + " quids";
            MyLabel.Text = ClientName + " hasn't place a bet";

            if (Cashes == 0)//Code When bettor has no money to bet then it gets destroy
            {
                MyLabel.Text = String.Format("BUSTED");
                MyLabel.ForeColor = System.Drawing.Color.Red;
                MyRadioButton.Enabled = false;
            }

        }

        public void ClearTheBet()
        {
            henBet.Amounts = 0;//Calling static methods
            henBet.hen = 0;//Calling static methods
            henBet.Punter = this;
        }

        public bool PlaceBet(int BetAmount, int HenToWin)
        {
            if (Cashes >= BetAmount)
            {
                henBet.Amounts = BetAmount;//Calling static methods
                henBet.hen = HenToWin;//Calling static methods
                henBet.Punter = this;
                return true;
            }
            else return false;
        }

        public void Collect(int winner)
        {
            Cashes += henBet.PayOut(winner);
            this.UpdatingLabels();
        }
    }
}
