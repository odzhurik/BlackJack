using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Card
    {
        public CardName NameOfCard { get; set; }
        public int ValueOfCard { get; set; }
        public Suit Suit { get; set; }
    }
}
