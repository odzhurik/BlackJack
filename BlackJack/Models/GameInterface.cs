using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    static class GameInterface
    {
       static HumanPlayer playerHuman;
       static PlayerComputer playerComputer;
        static IGame game;
       
        public static int BeginGame(HumanPlayer playerH, PlayerComputer playerC,IGame Game)
        {
            Console.WriteLine("Приветствую в игре Блэк Джек.|" +
                " Нажмите 1, чтобы сдать карты.| Нажмите 2, чтобы прекратить игру.");
            int number =Int32.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    {
                        Game.Init(playerC, playerH);
                        return 1;
                       // break;
                    }
                case 2:
                    {
                        System.Environment.Exit(0);
                        break;
                        
                    }
                default:
                    {
                        Console.WriteLine("Введите 1 или 2");
                        break;
                    }
            }
            return 0;
        }
        
        public static int PlayGame(HumanPlayer playerH, PlayerComputer playerC)
        {
            playerH.Play();
            playerC.Play();
            if(playerC.Win || playerH.Win)
            {
                return 1;
            }
            Console.WriteLine("\nНажмите 1, чтобы взять карту.| Нажмите 2, чтобы выйти");
            int number = Int32.Parse(Console.ReadLine());

            switch(number)
            {
                case 1:
                    {
                        playerH.AddCard();
                        playerH.Play();
                       
                        break;
                    }
                case 2:
                    {
                        System.Environment.Exit(0);
                        break;
                    }
            }
            if (playerH.Win || playerC.Win)
            {
                return 1;
            }
            return 0;
        }
    }
}
