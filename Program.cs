using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Player
    {
        public int Number { get; set; }
        public bool IsWinner { get; set; } = false;
    }
    public class AIPlayer : Player
    {
        //
    }
    public class Connect4Board
    {
        public string[,] board = new string[6, 8];
        public string[] columns = { "   1 ", " 2 ", " 3 ", " 4 ", " 5 ", " 6 ", " 7   " };
        public void NewBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1) - 1; j++)
                {
                    board[i, j] = "#";
                }
            }
            this.DisplayBoard();
        }
        public void DisplayBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("|  ");
                for (int k = 0; k < board.GetLength(1) - 1; k++)
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
        public void updateBoard(int x, Player player) //(int column, Player player)
        {
            //string player = "player";
            // Manage Player 1s inputs
            if (player.Number == 1)
            {
                int col = x - 1;
                //player = "one";

                if (board[5, col] == "#")
                {
                    board[5, col] = "X";
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
                                board[k, col] = "X";
                                num++;
                                break;
                            }
                        }
                    }
                }
            }

            // Manage Player 2s inputs
            else if (player.Number == 2)
            {
                int col = x - 1;
                //player = "two";

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
        private void CheckWin(Player player)
        {
            // player one conditions
            if (player.Number == 1)
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
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                            // These check what player won diagonally from the bottom left to the top right
                            if (board[i, k] == board[i - 1, k + 1] && board[i, k] == board[i - 2, k + 2] && board[i, k] == board[i - 3, k + 3])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < board.GetLength(0) - 3; i++)
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "X")
                        {
                            // These check what player won vertically
                            if (board[i, k] == board[i + 1, k] && board[i, k] == board[i + 2, k] && board[i, k] == board[i + 3, k])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                        }
                    }
                    for (int k = 0; k < board.GetLength(1) - 3; k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "X")
                        {
                            // These check what player won diagonally from top-left to bottom-right
                            if (board[i, k] == board[i + 1, k + 1] && board[i, k] == board[i + 2, k + 2] && board[i, k] == board[i + 3, k + 3])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                        }
                    }
                }

            }
            // player two conditions
            else if (player.Number == 2)
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
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                            // These check what player won diagonally from the bottom left to the top right
                            if (board[i, k] == board[i - 1, k + 1] && board[i, k] == board[i - 2, k + 2] && board[i, k] == board[i - 3, k + 3])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < board.GetLength(0) - 3; i++)
                {
                    for (int k = 0; k < board.GetLength(1); k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "O")
                        {
                            // These check what player won vertically
                            if (board[i, k] == board[i + 1, k] && board[i, k] == board[i + 2, k] && board[i, k] == board[i + 3, k])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
                            }
                        }
                    }
                    for (int k = 0; k < board.GetLength(1) - 3; k++)
                    {
                        if (board[i, k] != "#" && board[i, k] == "O")
                        {
                            // These check what player won diagonally from top-left to bottom-right
                            if (board[i, k] == board[i + 1, k + 1] && board[i, k] == board[i + 2, k + 2] && board[i, k] == board[i + 3, k + 3])
                            {
                                Console.WriteLine("player " + player.Number + " wins");
                                player.IsWinner = true;
                                break;
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
            string repeat = "Y";
            do //do-while loop for repeat playthroughs
            {
                Console.WriteLine("Play against another person[1] or against the computer[2]?");
                int mode = int.Parse(Console.ReadLine());

                Connect4Board board = new Connect4Board();
                board.NewBoard();

                if (mode == 1)
                {
                    Player player1 = new Player();
                    player1.Number = 1;
                    Player player2 = new Player();
                    player2.Number = 2;

                    int Turn = 0;
                    int status = 0;

                    while (status == 0)
                    {
                        while (Turn == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player Ones Turn.");
                            Console.Write("Enter Column: ");
                            int Col = int.Parse(Console.ReadLine());

                            if (Col > 0 && Col < 8) //validate if input is correct
                            {
                                board.updateBoard(Col, player1);
                                if (player1.IsWinner)
                                {
                                    status = 1;
                                    break;
                                }
                                Turn = 1;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please select a column from 1 to 7.");
                            }
                        }
                        while (Turn == 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player Twos Turn.");
                            Console.Write("Enter Column: ");
                            int Col = int.Parse(Console.ReadLine());
                            if (Col > 0 && Col < 8) //validate if input is correct
                            {
                                board.updateBoard(Col, player2);
                                if (player2.IsWinner)
                                {
                                    status = 1;
                                    break;
                                }
                                Turn = 0;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input! Please select a column from 1 to 7.");
                            }
                        }
                    }
                    Console.WriteLine("Do you want to play again? [Y/N]");
                    repeat = Console.ReadLine();
                }
            } while (repeat == "Y");

        }
    }
}
