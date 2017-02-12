using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Game
    {
        private static Player _playerHuman;
        private static Player _playerComputer;
        public  void NewGameStart()
        {
            Dealer dealer = new Dealer();
            _playerComputer = new Player(dealer);
             _playerComputer.Name=PlayersName.Computer;
            _playerHuman = new Player(dealer);
            _playerHuman.Name=PlayersName.Human;
            _playerComputer.Opponent = _playerHuman;
            _playerHuman.Opponent = _playerComputer;
            GameInterface.BeginGame(_playerHuman, _playerComputer,dealer,this);
        }
        public  void Round()
        {
            GameInterface.PlayGame(_playerHuman, _playerComputer);
        }
       
        public  void PlayGame()
        {
            NewGameStart();
            Round();
        }
    }
}
