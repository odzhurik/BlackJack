using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class Card
    {
       public Denomination denomination { get; private set; }
       public Suit suit { get; private set; }
        public Card(Denomination denomination, Suit suit)
        {
            this.denomination = denomination;
            this.suit = suit; 
        }
    }
}
