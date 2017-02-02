using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    static class Game
    {
        private static Player _playerHuman;
        private static Player _playerComputer;
        public static void NewGameStart()
        {
            _playerComputer = new Player() { Name = PlayersName.Computer.ToString() };
            _playerHuman = new Player() { Name = PlayersName.Human.ToString() };
            _playerComputer.Opponent = _playerHuman;
            _playerHuman.Opponent = _playerComputer;
            GameInterface.BeginGame(_playerHuman, _playerComputer);
        }
        public static void Round()
        {
            GameInterface.PlayGame(_playerHuman, _playerComputer);
        }
       
        public static void PlayGame()
        {
            NewGameStart();
            Round();
        }
    }
}
