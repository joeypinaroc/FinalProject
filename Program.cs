using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SODV1202
{

    public class Connect4board
    {
        public string[,] board = new string[6, 8];
        public string[] columns = { "   1 "," 2 "," 3 "," 4 "," 5 "," 6 "," 7   " };

        public void NewBoard() 
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for(int j = 0; j < board.GetLength(1)-1; j++)
                {
                    board[i,j] = "#";
                }
            }
            this.DisplayBoard();
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("|  ");
                for (int k = 0; k < board.GetLength(1)-1; k++)
                {
                    Console.Write(board[i, k] + "  ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int i = 0; i < columns.GetLength(0); i++)
            {
                Console.Write(columns[i]);
            }
            Console.WriteLine();
        }

        public void updateBoard(int x , int y)
        {
            string player = "player";
            // Manage Player 1s inputs
            if (y == 1)
            {
                int col = x - 1;
                player = "one";

                if (board[5, col] == "#")
                {
                    board[5, col] = "X";
                }
                else if (board[5, col] != "#")
                {
                    int num = 0;
                    while (num == 0)
                    {
                        for (int k = board.GetLength(0)-1 ; 0 <= k; k--)
                        {
                            if (board[k, col] == "#")
                            {
                                board[k, col] = "X";
                                num++;
                                break;
                            }
                        }
                    }
                }
            }

            // Manage Player 2s inputs
            else if (y == 2)
            {
                int col = x - 1;
                player = "two";

                if (board[5, col] == "#")
                {
                    board[5, col] = "O";
                }
                else if (board[5, col] != "#")
                {
                    int num = 0;
                    while (num == 0)
                    {
                        for (int k = board.GetLength(0) - 1; 0 <= k; k--)
                        {
                            if (board[k, col] == "#")
                            {
                                board[k, col] = "O";
                                num++;
                                break;
                            }
                        }
                    }
                }
            }
            this.DisplayBoard();

            this.CheckWin(player);
        }

        private void CheckWin(string player)
        {
            // player one conditions
            if (player == "one")
            {
                for (int i = board.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "X")
                        {
                            // These check what player won horizontally
                            if (board[i, k] == board[i, k + 1] && board[i, k] == board[i, k + 2] && board[i, k] == board[i, k + 3])
                            {
                                Console.WriteLine("player " + player + " wins");
                            }
                            // These check what player won diagonally from the bottom left to the top right
                            if (board[i, k] == board[i - 1, k + 1] && board[i, k] == board[i - 2, k + 2] && board[i, k] == board[i - 3, k + 3])
                            {
                                Console.WriteLine("player " + player + " wins");
                            }
                        }
                    }
                }
            }
            // player two conditions
            else if (player == "two")
            {
                for (int i = board.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "O")
                        {
                            // These check what player won horizontally
                            if (board[i, k] == board[i, k + 1] && board[i, k] == board[i, k + 2] && board[i, k] == board[i, k + 3])
                            {
                                Console.WriteLine("player " + player + " wins");
                            }
                            // These check what player won diagonally from the bottom left to the top right
                            if (board[i, k] == board[i - 1, k + 1] && board[i, k] == board[i - 2, k + 2] && board[i, k] == board[i - 3, k + 3])
                            {
                                Console.WriteLine("player " + player + " wins");
                            }
                        }
                    }
                }
            }
        }
    }


    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connect4 Game");
            Connect4board board = new Connect4board();
            Console.WriteLine();
            int Player1 = 1;
            int Player2 = 2;
            int Turn = 0;
            int status = 0;

            board.NewBoard();

            while (status == 0)
            {
                if ( Turn == 0 )
                {
                    //Remember you need to add conditions to check if the value entered is acceptable !!DO NOT REMOVE UNTIL DONE!!
                    // IF THE VALUE IS NOT IN THE RANGE OF 1 AND 7 REPEAT TURN
                    Console.WriteLine();
                    Console.WriteLine("Player Ones Turn.");
                    Console.Write("Enter Column: ");
                    int Col = int.Parse(Console.ReadLine());
                    board.updateBoard(Col, Player1);
                    Turn = 1;
                }
                if ( Turn == 1 )
                {
                    //Remember you need to add conditions to check if the value entered is acceptable !!DO NOT REMOVE UNTIL DONE!!
                    // IF THE VALUE IS NOT IN THE RANGE OF 1 AND 7 REPEAT TURN
                    Console.WriteLine();
                    Console.WriteLine("Player Twos Turn.");
                    Console.Write("Enter Column: ");
                    int Col = int.Parse(Console.ReadLine());
                    board.updateBoard(Col, Player2);
                    Turn = 0;
                }
            }

        }
    }
}
