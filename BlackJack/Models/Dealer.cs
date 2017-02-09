using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Dealer
    {
        public  Stack<Card> CardsShuff { get; private set; }
        public  void DealCards(Player computer, Player player)
        {
            List<Card> Cards = CardInit();
            CardsShuff = Shuffle(Cards);
            for (int i = 0; i < 2; i++)
            {
                computer.playerCards.Add(CardsShuff.Pop());
                player.playerCards.Add(CardsShuff.Pop());
            }
        }
        public  List<Card> CardInit()
        {
            List<Card> Cards = new List<Card>();
            int minValueCard = 2;
            int minValueHigherCard = 10;
            int maxValueCard = 11;
          
            for (int i = 0; i < Enum.GetNames(typeof(Suit)).Length; i++)
            {
                for (int cardName = 0, cardValue = minValueCard; cardName < Enum.GetNames(typeof(CardName)).Length; cardName++, cardValue++)
                {
                    if ((CardName)cardName == CardName.Jack || (CardName)cardName == CardName.King || (CardName)cardName == CardName.Queen)
                    {
                        Cards.Add(new Card { Suit = (Suit)i, CardName = (CardName)cardName, CardValue = minValueHigherCard });
                    }
                    if ((CardName)cardName == CardName.Ace)
                    {
                        Cards.Add(new Card { Suit = (Suit)i, CardName = (CardName)cardName, CardValue = maxValueCard });
                        break;
                    }
                    if ((CardName)cardName <=CardName.Ten )
                    {
                        Cards.Add(new Card { Suit = (Suit)i, CardName = (CardName)cardName, CardValue = cardValue });
                    }
                    
                }
            }
            return Cards;
        }
        private  Stack<Card> Shuffle(List<Card> cards)
        {
            Stack<Card> shuffCard = new Stack<Card>();
            while (shuffCard.Count < cards.Count)
            {
                Random rdn = new Random();
                int index = rdn.Next(0, cards.Count);
                if (!shuffCard.Contains(cards[index]))
                {
                    shuffCard.Push(cards[index]);
                }
            }
            return shuffCard;
        }
    }
}
