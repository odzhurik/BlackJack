using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class Player
    {
        public Dictionary<Card, Card> PlayerCards;

        int _sum;
        string _name;
        public Player PlayerOp { get; set; }
        GameSettings _gameSettings;
        public bool Win { get; set; }

        public Player(string Name, GameSettings Game)
        {
            _name = Name;
            PlayerCards = new Dictionary<Card, Card>();
            _gameSettings = Game;
        }
        void SumOfCards(Dictionary<Card, Card> Cards)
        {
            _sum = 0;

            foreach (Card card in Cards.Values)
            {
                _sum += Convert.ToInt32(card.CardDenomination.Value);

            }
            
        }
        public virtual void Play()
        {

            SumOfCards(PlayerCards);
            if (_name == "Computer")
            {
                if (_sum < 21)
                {
                    AddCard();
                    
                }
                if (_sum == 21)
                {
                    Win = true;
                }
                if (_sum > 21)
                {
                    PlayerOp.Win = true;
                }
            }
            if(_name=="Human")
            {
                if(_sum==21)
                {
                    Win = true;
                }
                if(_sum>21)
                {
                    PlayerOp.Win = true;
                }
            }
        }
        public void AddCard()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            Card card = _gameSettings.Cards[rng.Next(0, _gameSettings.Cards.Count)];
            card = _gameSettings.CardCheck(this, card, rng);
            PlayerCards.Add(card, card);
            SumOfCards(PlayerCards);
            if(_sum==21)
            {
                Win = true;
            }
        }
    }
}
