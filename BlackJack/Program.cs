using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int result = 0;
            do
            {
                Game game = new Game();
                PlayerComputer comp = new PlayerComputer(game);
                HumanPlayer player = new HumanPlayer(game);
                comp.PlayerOp = player;
                player.PlayerOp = comp;
                result =GameInterface.BeginGame(player, comp,game);
                do
                {
                    result = GameInterface.PlayGame(player, comp);
                } while (result == 0);
            } while (result==1);
            Console.ReadLine();
        }
    }
}
