using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
   static class Game
    {
       public static void PlayGame()
        {
            int result = 0;
            do
            {
                GameSettings game = new GameSettings(52);
                Player comp = new Player("Computer", game);
                Player player = new Player("Human", game);
                comp.PlayerOp = player;
                player.PlayerOp = comp;
                result = GameInterface.BeginGame(player, comp, game);
                do
                {
                    result = GameInterface.PlayGame(player, comp);
                } while (result == 0);
            } while (result == 1);
        }
    }
}
