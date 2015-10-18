using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(Player a_dealer)
        {
            List<Card> hand = a_dealer.GetHand().ToList();

            bool hasAce = hand.Exists(c => c.GetValue() == Card.Value.Ace);

            if (hasAce)
            {
                
            }
            


            throw new NotImplementedException();
        }
    }
}
