﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    static class GameInterface
    {
            
        public static void  BeginGame(Player playerH, Player playerC)
        {
            Console.WriteLine("Приветствую в игре Блэк Джек.|" +
                " Нажмите 1, чтобы сдать карты.| Нажмите 2, чтобы прекратить игру.");
            int number =Int32.Parse(Console.ReadLine());
            
            
                if(number==1)
                    {
                        Dealer.DealCards(playerC, playerH);
                Game.Round();
                    }                    
                if(number==2)
                    {
                        System.Environment.Exit(0);
                        
                        
                    }
                if(number!=1 && number!=2)
                    {
                        Console.WriteLine("Введите 1 или 2");
                        
                    }
            
            
        }
        
        public static void PlayGame(Player playerH, Player playerC)
        {
            Console.Write("\n" + "Ваши карты: ");
            foreach(Card card in playerH.PlayerCards)
            {
                Console.Write("Масть: " + card.Suit + " Достоинство: " + card.CardDenomination.Name + ", ");
            }

           Player player1= playerH.Play();

            
            if(player1!=null)
            {
                Console.WriteLine("\n"+player1.Name+" выиграл!");
                Game.NewGameStart();
            }
            player1 = playerC.Play();
            if (player1!=null)
            {
                Console.WriteLine("\n" + player1.Name+" выиграл!");
                Game.NewGameStart();
            }
            Console.WriteLine("\n"+"Нажмите 1, чтобы взять карту.| Нажмите 2, чтобы выйти");
            int number = Int32.Parse(Console.ReadLine());

                if(number==1)
                    {
                       player1= playerH.AddCard();
                                                            
                    }
                if(number==2)
                    {
                        System.Environment.Exit(0);
                        
                    }
            if(player1==null)
            {
                Game.Round();
            }
            if (player1!=null)
            {
                Console.WriteLine("\n" +player1.Name+ " выиграл!");
                Game.NewGameStart();
            }
           
            
        }
    }
}
