using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class GameSettings
    {
        public List<Card> Cards { get; private set; }
        int _countOfCards;

        public Dictionary<string, int> DenominationList { get; private set; }
        public GameSettings(int countOfCards)
        {
            _countOfCards = countOfCards;

        }
        public Card CardCheck(Player player, Card card, Random rng)
        {

            if (player.PlayerCards.ContainsKey(card))
            {
                do
                {
                    card = Cards[rng.Next(0, _countOfCards)];
                }
                while (player.PlayerCards.ContainsKey(card));
            }
            return card;


        }
        public void Init(Player comp, Player player)
        {
            CardInit();

            comp.PlayerCards.Clear();
            player.PlayerCards.Clear();
            Random rng = new Random(Guid.NewGuid().GetHashCode());

            Cards = Shuffle(rng);
            foreach(Card card in Cards)
            {
                Console.WriteLine(card.CardDenomination.Name + " of " + card.Suit);
            }
            for (int i = 0; i < 2; i++)
            {

                Card card = Cards[rng.Next(0, _countOfCards)];
                card = CardCheck(comp, card, rng);
                comp.PlayerCards.Add(card, card);
                card = Cards[rng.Next(0, _countOfCards)];
                card = CardCheck(player, card, rng);
                player.PlayerCards.Add(card, card);

            }

        }
        void CardFill(List<Card> Cards, Dictionary<string, int> ListOfDenomination, Suit suit)
        {
            foreach (string denomination in ListOfDenomination.Keys)
            {
                Card card = new Card() { Suit = suit, CardDenomination = new Denomination() { Name = denomination, Value = ListOfDenomination[denomination] } };
                Cards.Add(card);
            }

        }
        public void CardInit()
        {
            Cards = new List<Card>();
            DenominationList = new Dictionary<string, int>() { { "Two", 2 }, { "Three", 3 }, { "Four", 4 }, { "Five", 5 }, { "Six", 6 }, { "Seven", 7 }, { "Eight", 8 }, { "Nine", 9 }, { "Ten", 10 }, { "Jack", 10 }, { "Queen", 10 }, { "King", 10 }, { "Ace", 11 } };
            CardFill(Cards, DenominationList, Suit.Clubs);
            CardFill(Cards, DenominationList, Suit.Diamonds);
            CardFill(Cards, DenominationList, Suit.Hearts);
            CardFill(Cards, DenominationList, Suit.Spades);

        }
        List<Card> Shuffle(Random rdn)
        {
            List<Card> shuffList = new List<Card>();
            
            do
            {
             
                int index;
                do
                {
                    index = rdn.Next(0, _countOfCards);
                    
                } while (shuffList.Contains(Cards[index]));
                shuffList.Add(Cards[index]);
            } while (shuffList.Count<_countOfCards);
            
            return shuffList;
        }
    }
}
