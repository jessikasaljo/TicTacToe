using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        //Fields
        private char[,] board;
        private char currentPlayer;


        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }


        //Starts new game
        private void InitializeGame()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            UpdateButton();
        }


        //Event handling for clicking one of the buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            if (board[row, column] == '\0')
            {
                board[row, column] = currentPlayer;
                char winner = CheckForWin();

                if (CheckForWin() != '\0')
                {
                    UpdateButton();
                    MessageBox.Show("Player " + winner + " won!");
                    InitializeGame();
                    return;
                }
                else if (CheckForDraw())
                {
                    UpdateButton();
                    MessageBox.Show("It's a draw!");
                    InitializeGame();
                    return;
                }

                if (currentPlayer == 'X')
                {
                    currentPlayer = 'O';
                }
                else
                {
                    currentPlayer = 'X';
                }

                UpdateButton();
            }
        }


        //Checks if there is a winner
        private char CheckForWin()
        {
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != '\0' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                {
                    return board[row, 0];
                }
            }

            for (int column = 0; column < 3; column++)
            {
                if (board[0, column] != '\0' && board[0, column] == board[1, column] && board[1, column] == board[2, column])
                {
                    return board[0, column];
                }
            }

            if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }

            if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            return '\0';
        }


        //Checks if there is a draw
        private bool CheckForDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '\0')
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        //Updates button with correct symbol
        private void UpdateButton()
        {
            Button1.Content = GetSymbol(0, 0);
            Button2.Content = GetSymbol(0, 1);
            Button3.Content = GetSymbol(0, 2);
            Button4.Content = GetSymbol(1, 0);
            Button5.Content = GetSymbol(1, 1);
            Button6.Content = GetSymbol(1, 2);
            Button7.Content = GetSymbol(2, 0);
            Button8.Content = GetSymbol(2, 1);
            Button9.Content = GetSymbol(2, 2);
        }


        //Gets the symbol from a specific button
        private string GetSymbol(int row, int column)
        {
            return (board[row, column] == '\0') ? "" : board[row, column].ToString();
        }

    }
}