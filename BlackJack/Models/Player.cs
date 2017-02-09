using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Player
    {
        public List<Card> playerCards;
        private Dealer dealer;
        private int _sum;
        private const int _winCondition = 21;
        public Player Opponent { get; set; }
        public PlayersName Name { get; set; }
        public Player(Dealer dealer)
        {
            playerCards = new List<Card>();
            this.dealer = dealer;
        }
        private void SumOfCards(List<Card> cards)
        {
            _sum = 0;

            foreach (Card card in cards)
            {
                _sum += card.CardValue;
            }
        }
        public void GameConditions(out Player winner)
        {
            winner = null;
            if (_sum == _winCondition)
            {
                winner = this;
            }
            if (_sum > _winCondition)
            {
                winner = Opponent;
            }

        }
        public void Play(out Player winner)
        {
            winner = null;
            SumOfCards(playerCards);
            if (Name == PlayersName.Computer)
            {
                if (_sum < _winCondition)
                {
                    AddCard(ref winner);
                }
                GameConditions(out winner);
            }
            if (Name == PlayersName.Human)
            {
                GameConditions(out winner);
            }
        }
        public void AddCard(ref Player winner)
        {
            playerCards.Add(dealer.CardsShuff.Pop());
            SumOfCards(playerCards);
            GameConditions(out winner);
        }
    }
}
