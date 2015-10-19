using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class EvenPlayerWinStrategy : IWinStrategy
    {
        public bool IsDealerWinner(Dealer a_dealer, Player a_player)
        {
            if (a_player.CalcScore() > a_dealer.GetMaxScore())
            {
                return true;
            }
            else if (a_dealer.CalcScore() > a_dealer.GetMaxScore())
            {
                return false;
            }

            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
