using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
    public static class GameLogic
    {
        static private int[,] _gameField =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

        static private int _currentPlayer = 1;

        static private int _num = 0;

        static private List<Button> _buttons = new List<Button>();

        static public void MakeAMove(Button btn)
        {
            _buttons.Add(btn);

            int rowIndex = Grid.GetRow(btn);
            int columnIndex = Grid.GetColumn(btn);

            _gameField[rowIndex, columnIndex] += _currentPlayer;

            changeTheSignOfField(btn, _currentPlayer);

            _num++;

            var checker = checkTheGameResult(_currentPlayer);

            if (_num == 9 && !checker)
            {
                MessageBox.Show("Draw!");
                resetGame();
            }
        }

        static private bool checkTheGameResult(int player)
        {
            if (_gameField[0, 0] == player && _gameField[0, 1] == player && _gameField[0, 2] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[1, 0] == player && _gameField[1, 1] == player && _gameField[1, 2] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[2, 0] == player && _gameField[2, 1] == player && _gameField[2, 2] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[0, 0] == player && _gameField[1, 1] == player && _gameField[2, 2] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[1, 2] == player && _gameField[1, 1] == player && _gameField[2, 1] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[0, 0] == player && _gameField[1, 0] == player && _gameField[2, 0] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[0, 1] == player && _gameField[1, 1] == player && _gameField[2, 1] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else if (_gameField[0, 2] == player && _gameField[1, 2] == player && _gameField[2, 2] == player)
            {
                writeWhoWon(player);
                resetGame();
                return true;
            }
            else
            {
                _currentPlayer = _currentPlayer * -1;
                return false;
            }
        }

        static private void changeTheSignOfField(Button btn, int currentPlayer)
        {
            if (currentPlayer == 1)
            {
                btn.Content = "O";
            }
            else
            {
                btn.Content = "X";
            }
            
            btn.IsEnabled = false;
        }

        static private void resetGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _gameField[i, j] = 0;
                }
            }

            foreach (var btn in _buttons)
            {
                btn.IsEnabled = true;
                btn.Content = "";
            }

            _buttons.Clear();

            _currentPlayer = 1;

            _num = 0;
        }

        static private void writeWhoWon(int player)
        {
            string winner(int player) => player == 1 ? "O" : "X";
            MessageBox.Show($"Player {winner(player)} won!");
        }
    }
}
