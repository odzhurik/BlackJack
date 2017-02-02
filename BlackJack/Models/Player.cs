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
        private int _sum;
        private const int _winCondition = 21;
        public Player Opponent { get; set; }
        public string Name { get; set; }
        public Player()
        {
            PlayerCards = new List<Card>();
        }
        private void SumOfCards(List<Card> Cards)
        {
            _sum = 0;

            foreach (Card card in Cards)
            {
                _sum += card.ValueOfCard;

            }

        }
        public void GameConditions(ref Player Winner)
        {
            if (_sum == _winCondition)
            {
                Winner = this;
            }
            if (_sum > _winCondition)
            {
                Winner = Opponent;
            }
            
        }
        public void Play(out Player Winner)
        {
            Winner = null;
            SumOfCards(PlayerCards);
            if (Name == "Computer")
            {
                if (_sum < _winCondition)
                {
                    AddCard(ref Winner);

                }
                 GameConditions(ref Winner);
            }
            if (Name == "Human")
            {
                 GameConditions(ref Winner);
            }
            
        }
        public void AddCard( ref Player Winner)
        {
            PlayerCards.Add(Dealer.CardsShuff.Pop());
            SumOfCards(PlayerCards);
             GameConditions(ref Winner);
        }
    }
}
