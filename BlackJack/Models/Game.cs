using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class Game:IGame
    {
        public Dictionary<int, Card> cards { get; private set; }
         public List<Denomination> DenominationList { get; private set; }
        public Card CardCheck(Player player,Card card, Random rng)
        {
           
            if (player.Cards.ContainsKey(card))
            {
                do
                {
                    card = cards[rng.Next(0, 51)];
                }
                while (player.Cards.ContainsKey(card));
            }
            return card;


        }
        public  void Init(Player comp,Player player)
        {
            CardInit();
            comp.Cards.Clear();
            player.Cards.Clear();
           Random rng = new Random(Guid.NewGuid().GetHashCode());
            for(int i=0;i<2;i++)
            {
               
                Card card = cards[rng.Next(0, 51)];
               card= CardCheck(comp,card,rng);
                comp.Cards.Add(card, card);
                card= cards[rng.Next(0, 51)];
                card = CardCheck(player,card,rng);
                player.Cards.Add(card, card);
               
            }

        }
     public  void CardInit()
        {
            cards = new Dictionary<int, Card>();
             DenominationList = new List<Denomination>() {Denomination.Two, Denomination.Three,Denomination.Four, Denomination.Five, Denomination.Six, Denomination.Seven, Denomination.Eight, Denomination.Nine, Denomination.Ten, Denomination.Jack,Denomination.Queen, Denomination.King,Denomination.Ace };
            for(int i=0;i<13;i++)
            {
                Card card= new Card(DenominationList[i], Suit.Clubs);
                cards[i] = card;
            }
            for(int i=13;i<26;i++)
            {
                Card card = new Card(DenominationList[i-13], Suit.Diamonds);
                cards[i] = card;
            }
            for (int i = 26; i < 39; i++)
            {
                Card card = new Card(DenominationList[i - 26], Suit.Hearts);
                cards[i] = card;
            }
            for (int i = 39; i < 52; i++)
            {
                Card card = new Card(DenominationList[i - 39], Suit.Spades);
                cards[i] = card;
            }
        }
    }
}
