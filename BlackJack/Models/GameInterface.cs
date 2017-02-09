using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal static class GameInterface
    {
        private static Game _game;
        public static void BeginGame(Player playerHuman, Player playerComputer, Dealer dealer, Game game)
        {
            _game = game;
            Console.WriteLine("Приветствую в игре Блэк Джек.|" +
                " Нажмите 1, чтобы сдать карты.| Нажмите 2, чтобы прекратить игру.");
            int number = Int32.Parse(Console.ReadLine());
            if (number == 1)
            {
                dealer.DealCards(playerComputer, playerHuman);
                game.Round();
            }
            if (number == 2)
            {
                System.Environment.Exit(0);
            }
            if (number != 1 && number != 2)
            {
                Console.WriteLine("Введите 1 или 2");
            }
        }
        private static void PlayerTurn(Player player, out Player playerWinner)
        {
            player.Play(out playerWinner);
            if (playerWinner != null)
            {
                Console.WriteLine("\n" + playerWinner.Name + " выиграл!");
                _game.NewGameStart();
            }
        }
        public static void PlayGame(Player playerHuman, Player playerComputer)
        {
            Player playerWinner;
            Console.Write("\n" + "Ваши карты: ");
            foreach (Card card in playerHuman.playerCards)
            {
                Console.Write("Масть: " + card.Suit + " Достоинство: " + card.CardName + ", ");
            }
            PlayerTurn(playerComputer, out playerWinner);
            PlayerTurn(playerHuman, out playerWinner);
            Console.WriteLine("\n" + "Нажмите 1, чтобы взять карту.| Нажмите 2, чтобы выйти");
            int number = Int32.Parse(Console.ReadLine());
            if (number == 1)
            {
                playerHuman.AddCard(ref playerWinner);
            }
            if (number == 2)
            {
                System.Environment.Exit(0);
            }
            if (playerWinner == null)
            {
                _game.Round();
            }
            if (playerWinner != null)
            {
                Console.WriteLine("\n" + playerWinner.Name + " выиграл!");
                _game.NewGameStart();
            }
        }
    }
}
