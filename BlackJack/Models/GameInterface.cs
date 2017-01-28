using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    static class GameInterface
    {
            
        public static int BeginGame(Player playerH, Player playerC,GameSettings Game)
        {
            Console.WriteLine("Приветствую в игре Блэк Джек.|" +
                " Нажмите 1, чтобы сдать карты.| Нажмите 2, чтобы прекратить игру.");
            int number =Int32.Parse(Console.ReadLine());
            
            
                if(number==1)
                    {
                        Game.Init(playerC, playerH);
                        return 1;
                    }                    
                if(number==2)
                    {
                        System.Environment.Exit(0);
                        
                        
                    }
                if(number!=1 && number!=2)
                    {
                        Console.WriteLine("Введите 1 или 2");
                        
                    }
            
            return 0;
        }
        
        public static int PlayGame(Player playerH, Player playerC)
        {
            Console.Write("\n" + "Ваши карты: ");
            foreach(Card card in playerH.PlayerCards.Values)
            {
                Console.Write("Масть: " + card.Suit + " Достоинство: " + card.CardDenomination.Name + ", ");
            }

            playerH.Play();

            playerC.Play();
            if(playerC.Win)
            {
                Console.WriteLine("\n"+"Компьютер выиграл!");
                return 1;
            }
            if(playerH.Win)
            {
                Console.WriteLine("\n" + "Вы выиграли!");
                return 1;
            }
            Console.WriteLine("\n"+"Нажмите 1, чтобы взять карту.| Нажмите 2, чтобы выйти");
            int number = Int32.Parse(Console.ReadLine());

                if(number==1)
                    {
                        playerH.AddCard();
                        playerH.Play();
                       
                        
                    }
                if(number==2)
                    {
                        System.Environment.Exit(0);
                        
                    }
            
            if (playerC.Win)
            {
                Console.WriteLine("\n" + "Компьютер выиграл!");
                return 1;
            }
            if (playerH.Win)
            {
                Console.WriteLine("\n" + "Вы выиграли!");
                return 1;
            }
            return 0;
        }
    }
}
