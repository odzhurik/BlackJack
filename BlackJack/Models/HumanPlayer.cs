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
            Console.Write("Ваши карты: ");
            foreach(Card card in Cards.Values)
            {
                Console.Write("Масть: "+card.suit+", Достоинство: "+card.denomination+", ");
            }
            base.Play();
           // Console.WriteLine("\n Сумма: " + sum);
            if (sum==21)
            {
                
                Win = true;
                Console.WriteLine("\nВы выиграли!");
                

            }
            if(sum>21)
            {

                Console.WriteLine("/nВы проиграли!Компьютер выиграл.");
                PlayerOp.Win = true;
                
            }

        }
    }
}
