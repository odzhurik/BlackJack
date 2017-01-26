using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    class HumanPlayer:Player
    {
       
        public HumanPlayer(IGame Game) :base(Game)
        {
            
        }
        public override void Play()
        {
            Console.Write("\n"+"Ваши карты: ");
            foreach(Card card in Cards.Values)
            {
                Console.Write("Масть: "+card.suit+", Достоинство: "+card.denomination+", ");
            }
            base.Play();
            if (sum==21)
            {
                
                Win = true;
                Console.WriteLine("\n"+"Вы выиграли!");
                

            }
            if(sum>21)
            {

                Console.WriteLine("\n"+"Вы проиграли!Компьютер выиграл.");
                PlayerOp.Win = true;
                
            }

        }
    }
}
