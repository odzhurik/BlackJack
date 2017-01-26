using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    abstract class Player
    {
        public Dictionary<Card, Card> Cards;

        protected int sum;
        public Player PlayerOp { get; set; }
        IGame game;
        public bool Win;

        public Player(IGame Game)
        {
            Cards = new Dictionary<Card, Card>();
            game = Game;
        }
        public virtual void Play()
        {

            sum = 0;

            foreach (Card card in Cards.Values)
            {
                sum += Convert.ToInt32(card.denomination);

            }
        }
        public void AddCard()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            Card card = game.cards[rng.Next(0, 51)];
            card = game.CardCheck(this, card, rng);
            Cards.Add(card, card);
        }
    }
}
