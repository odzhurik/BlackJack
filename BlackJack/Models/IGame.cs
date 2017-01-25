using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    interface IGame
    {
        Dictionary<int, Card> cards { get; }
        void Init(Player comp, Player player);
        void CardInit();
    }
}
