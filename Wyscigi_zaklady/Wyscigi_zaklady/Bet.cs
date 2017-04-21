using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wyscigi_zaklady
{
     public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Bettor.MyBet.Amount == 0)
            {
                return Bettor.Name + " nie zawarł zakładu.";
            }
            else
            {
                return Bettor.Name + " postawił " + Bettor.MyBet.Amount + " na psa numer " + Bettor.MyBet.Dog + ".";
            }
        }

        public int PayOut(int Winner)
        {
            if (Bettor.MyBet.Dog == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }

    }
}
