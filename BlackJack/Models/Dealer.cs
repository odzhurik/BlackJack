using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    static class Dealer
    {
        public static Stack<Card> CardsShuff { get; private set; }
        public static void DealCards(Player comp, Player player)
        {
            List<Card> Cards = CardInit();
            CardsShuff = Shuffle(Cards);
            for (int i = 0; i < 2; i++)
            {
                comp.PlayerCards.Add(CardsShuff.Pop());
                player.PlayerCards.Add(CardsShuff.Pop());
            }
        }
        public static List<Card> CardInit()
        {
            List<Card> Cards = new List<Card>();
            int MinValueLowerCard = 2;
            int MaxValueLowerCard = 10;
            int MaxValueHigherCard = 11;
            for (int i = 0; i < Enum.GetNames(typeof(Suit)).Length; i++)
            {
                for (int valueLowerCard = MinValueLowerCard; valueLowerCard <= MaxValueLowerCard; valueLowerCard++)
                {
                    Cards.Add(new Card { Suit = (Suit)i, NameOfCard = ((LowerCard)valueLowerCard).ToString(), ValueOfCard = valueLowerCard });
                }
                for (int higherCard = 0; higherCard < Enum.GetNames(typeof(HigherCard)).Length; higherCard++)
                {
                    if (((HigherCard)higherCard).ToString() == "Ace")
                    {
                        Cards.Add(new Card { Suit = (Suit)i, NameOfCard = ((HigherCard)higherCard).ToString(), ValueOfCard = MaxValueHigherCard });
                        break;
                    }
                    Cards.Add(new Card { Suit = (Suit)i, NameOfCard = ((HigherCard)higherCard).ToString(), ValueOfCard = MaxValueLowerCard });
                }
            }
            return Cards;
        }
        private static Stack<Card> Shuffle(List<Card> Cards)
        {
            Stack<Card> shuffCard = new Stack<Card>();
            while (shuffCard.Count < Cards.Count)
            {
                Random rdn = new Random();
                int index = rdn.Next(0, Cards.Count);
                if (!shuffCard.Contains(Cards[index]))
                {
                    shuffCard.Push(Cards[index]);
                }
            }
            return shuffCard;
        }
    }
}
