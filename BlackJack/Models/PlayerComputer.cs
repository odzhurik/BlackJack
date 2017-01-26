using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class PlayerComputer:Player
    {
        
        public PlayerComputer(IGame Game):base(Game)
        {
            
        }
        public override void Play()
        {
            
            base.Play();
            if(sum< 21)
            {
                AddCard();
                base.Play();
            }
            if(sum==21)
            {
                Win = true;
                Console.WriteLine("\n"+"Компьютер выиграл!");
                
            }
            if(sum>21)
            {
                Console.WriteLine("\n"+"Перебор.Компьютер проиграл");
                PlayerOp.Win = true;
                
            }
           
        }
       
    }
}
