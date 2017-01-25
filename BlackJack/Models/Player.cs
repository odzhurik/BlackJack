using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
   abstract class Player
    {
       public Dictionary<Card,Card> Cards;

        protected int sum;
        private Player playerOp;
        IGame game;
        public bool Win;

        public Player PlayerOp
        {
            get
            {
                return playerOp;
            }

            set
            {
                playerOp = value;
            }
        }

        public Player(IGame Game)
        {
            Cards = new Dictionary<Card, Card>();
            game = Game;
        }
        public virtual void Play()
        {
            
            sum = 0;
           
            foreach(Card card in Cards.Values)
            {
                sum += Convert.ToInt32(card.denomination);

            }

            

        }
        public void AddCard()
        {
            Random rng = new Random(Guid.NewGuid().GetHashCode());
            Card card = game.cards[rng.Next(0, 51)];
            if(Cards.ContainsKey(card))
            {
                do
                {
                     card = game.cards[rng.Next(0, 51)];
                }
                while (Cards.ContainsKey(card));
            }
            Cards.Add(card,card);
        }
    }
}
