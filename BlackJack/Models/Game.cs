using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
   static class Game
    {
        static Player _playerH;
        static Player _playerC;
        public static void NewGameStart()
        {
             
            _playerC = new Player() { Name = "Computer" };
            _playerH = new Player() { Name = "Human" };
            _playerC.PlayerOp = _playerH;
            _playerH.PlayerOp = _playerC;
            GameInterface.BeginGame(_playerH,_playerC);
        }
        public static void Round()
        {
            GameInterface.PlayGame(_playerH, _playerC);
        }
       public static void PlayGame()
        {
                       
               NewGameStart();

                Round();
            
        }
    }
}
