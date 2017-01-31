using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class Player
    {
        public List<Card> PlayerCards;
        int _sum;
        public Player PlayerOp { get; set; }
      
         public string Name { get; set; }   
        

        public Player()
        {
            PlayerCards = new List<Card>();
            
        }
        void SumOfCards(List<Card> Cards)
        {
            _sum = 0;

            foreach (Card card in Cards)
            {
                _sum += card.CardDenomination.Value;

            }
            
        }
        public Player GameConditions()
        {
            if (_sum == 21)
            {
                return this;
            }
            if (_sum > 21)
            {
                return PlayerOp;
            }
            return null;
        }
        public Player Play()
        {

            SumOfCards(PlayerCards);
            if (Name == "Computer")
            {
                if (_sum < 21)
                {
                   return AddCard();
                    
                }
                return GameConditions();
            }
            if(Name=="Human")
            {
               return GameConditions();
            }
            return null;
        }
        public Player AddCard()
        {
            PlayerCards.Add(Dealer.CardsShuff.Pop());
            SumOfCards(PlayerCards);
           return GameConditions();
        }
    }
}
