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
        static List<Denomination> _denominationList;
             
        public static void DealCards(Player comp, Player player)
        {
            List<Card> Cards= CardInit();                  

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
            _denominationList = new List<Denomination>() {new Denomination {Name="Two",Value=2 }, new Denomination{Name="Three", Value=3 },new Denomination {Name="Four",Value=4 },new Denomination {Name="Five",Value=5 }, new Denomination{Name="Six",Value=6 },new Denomination {Name="Seven",Value=7 }, new Denomination{Name="Eight",Value=8 },new Denomination {Name="Nine",Value=9 },new Denomination {Name="Ten", Value=10 }, new Denomination{Name="Jack", Value=10 }, new Denomination{ Name="Queen", Value=10 },new Denomination { Name="King", Value=10 },new Denomination {Name="Ace", Value=11 } };
            for(int i=0;i< Enum.GetNames(typeof(Suit)).Length; i++)
            {
                for(int j=0;j<_denominationList.Count;j++)
                {
                    Cards.Add(new Card { Suit = (Suit)i, CardDenomination=_denominationList[j] });
                }
            }
            
            return Cards;
        }
     static Stack<Card> Shuffle(List<Card>Cards)
        {
             Stack<Card> shuffCard = new Stack<Card>();
            
            do
            {
             
                int index;
                do
                {
                    Random rdn = new Random();
                    index = rdn.Next(0, Cards.Count);
                    
                } while (shuffCard.Contains(Cards[index]));
                shuffCard.Push(Cards[index]);
            } while (shuffCard.Count<Cards.Count);
            
            return shuffCard;
        }
    }
}
