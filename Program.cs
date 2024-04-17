/*
 * link to Github repository: https://github.com/joeypinaroc/SODV1202-FinalProject
 */

using System;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Intrinsics.X86;
using System.Text;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class Board
    {
        private string[] playerSym = {"#", "X", "O"};// symbol for empty, p1 & p2

        public const int MaxCol = 7; // column from 1 to MaxCol
        public const int MaxRow = 6; // column from 1 to MaxRow
        private const int EMPTY = 0;
        public const int PLAYER1 = 1;
        public const int PLAYER2 = 2;
        private int[,] board = new int[MaxCol, MaxRow]; // p1=1, p2=2, empty=0
        public string state { get; private set; }// potential info to computer player

        public Board()
        {
            // board is array of int and default value 0;
            state = "";
        }
        

        public int hasFinished()
        {
            // return 0 = tie,  PLAYER1= player1 won,  PLAYER2= player2 won, -1 = not finished
            int isFinished;

            // check for a tie
            isFinished = 0;
            foreach (int i in board)
            {
                // if there is any space for more move, game is not finished yet
                if (i == EMPTY) 
                {
                    isFinished = -1;
                }
            }

            // check for horizontal win
            for (int y = 0; y < MaxRow; y++)
            {
                if (isFinished == PLAYER1 || isFinished == PLAYER2)
                {
                    break;
                }
                for (int x = 0; x < MaxCol-3; x++)
                {
                    if (board[x,y] != 0 && board[x, y]== board[x+1, y] &&
                        board[x, y] == board[x + 2, y] && board[x, y] == board[x + 3, y])
                    {
                        isFinished = board[x, y];
                        break;
                    }
                }
            }

            // check for vertical win
            for (int x = 0; x < MaxCol; x++)
            {
                if (isFinished == PLAYER1 || isFinished == PLAYER2)
                {
                    break;
                }
                for (int y = 0;y < MaxRow-3; y++)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x, y+1] &&
                        board[x, y] == board[x, y+2] && board[x, y] == board[x, y+3])
                    {
                        isFinished = board[x, y];
                        break;
                    }
                }
            }

            // check for diagonal (point top left)
            for (int x =  MaxCol-4; x < MaxCol; x++ )
            {
                if (isFinished == PLAYER1 || isFinished == PLAYER2)
                {
                    break;
                }
                for (int y = 0; y < MaxRow-4; y++ )
                {
                    if (board[x, y] != 0 && board[x, y] == board[x-1, y+1] &&
                        board[x, y] == board[x-2, y+2] && board[x, y] == board[x-3, y+3])
                    {
                        isFinished = board[x, y];
                        break;
                    }
                }
            }

            // check for diagonal (point top right)
            for (int x = 0; x < MaxCol-4; x++)
            {
                if (isFinished == PLAYER1 || isFinished == PLAYER2)
                {
                    break;
                }
                for (int y = 0; y < MaxRow - 4; y++)
                {
                    if (board[x, y] != 0 && board[x, y] == board[x +1, y + 1] &&
                        board[x, y] == board[x + 2, y + 2] && board[x, y] == board[x + 3, y + 3])
                    {
                        isFinished = board[x, y];
                        break;
                    }
                }
            }
            return isFinished;
        }

        public bool Move(int player, int col)
        {
            // try playing move at col (i.e. col-1 for array)
            // return true if success, false if failed (col full)

            // user input is from 1 to MaxCol, board is 0 to MaxCol-1
            --col;
            bool isSuccess = false;

            // update array board
            for (int y = 0; y < MaxRow; y++)
            {
                if (board[col, y] == 0)
                {
                    board[col, y] = player;
                    isSuccess = true;
                    break;
                }
            }
            return isSuccess;
        }

        public override string ToString()
        {
            // return print out of board as string

            string printout = "";


            for (int y = MaxRow-1; y >= 0; y--)
            {
                printout += "\n| ";
                for (int x = 0; x < MaxCol; x++)
                {
                    printout += playerSym[board[x, y]] + " ";
                }
                printout += "|\n";
            }
            printout += "  1 2 3 4 5 6 7  \n";

            return printout;
        }

    }

    public class Player
    {
        public string name { get; protected set; }
        public bool isHuman { get; protected set; }
        public int playOrder { get; protected set; }

        public Player(string name, bool isHuman, int playOrder)
        {
            this.name = name;
            this.isHuman = isHuman;
            this.playOrder = playOrder;
        }
    }

    public class compPlayer : Player
    {
        private Random rnd;
        public compPlayer(int playOrder) : base("AI", false, playOrder)
        {
            rnd = new Random();
        }
        public string smartMove(int maxCol)
        {
            return rnd.Next(1, maxCol + 1).ToString();
        }

    }

    public class gameControl
    {
        private Player p1;
        private Player p2;

        public gameControl()
        {
            string input;
            Console.WriteLine("Play a Connect 4 game!\n\n");
            do
            {
                Console.WriteLine("Type '1' for 1 player game (Play against computer). \nType '2' for 2 player game. \nOr Type 'x' to exit.");
                input = Console.ReadLine();
                input = input.ToLower();

                if (string.Equals(input, "1"))
                {
                    Console.WriteLine("What is your name?");
                    p1 = new Player(Console.ReadLine(), true, Board.PLAYER1);
                    p2 = new compPlayer(Board.PLAYER2);
                    Console.WriteLine($"\nConnect 4 game begin! {p1.name} v.s. {p2.name} (computer)!");
                    Console.WriteLine(p1.name +", you are playing first\n");
                    Play();
                    Console.WriteLine("\nPlay again!\n");
                }
                else if (string.Equals(input, "2"))
                {
                    Console.WriteLine("Player 1, what is your name?");
                    p1 = new Player(Console.ReadLine(), true, Board.PLAYER1);
                    Console.WriteLine("Player 2, what is your name?");
                    p2 = new Player(Console.ReadLine(), true, Board.PLAYER2);
                    Console.WriteLine($"\nConnect 4 game begin! {p1.name} v.s. {p2.name}!");
                    Console.WriteLine(p1.name + ", you are playing first\n");
                    Play();
                    Console.WriteLine("\nPlay again!\n");
                }
                else if (string.Equals(input, "x") )
                {
                    Console.WriteLine("Exiting game...\n");
                }
                else
                {
                    Console.WriteLine("Incorrect input\n");
                }
            }
            while (!string.Equals(input, "x") );
        }

        public void Play()
        {
            Board board = new Board();
            Player nextPlayer = p2;
            string playerInput;
            while (board.hasFinished() == -1)
            {
                // Get nextPlayer to play a move, repeat if false, move to next player
                if (nextPlayer == p1)
                {
                    nextPlayer = p2;
                }
                else
                {
                    nextPlayer = p1;
                }
                bool isMoveValid = true;
                do
                {
                    if (nextPlayer.isHuman)
                    {
                        Console.Write(nextPlayer.name + ", ");
                        int playCol = -1;
                        do
                        {
                            if (playCol != -1)
                            {
                                Console.WriteLine("\nIncorrect input. Try again.");
                            }
                            else if (isMoveValid == false)
                            {
                                Console.WriteLine("The column chosen is full. Try another column.");
                            }
                            Console.WriteLine("Type a number from 1 to " + Board.MaxCol + " to play a move in the column");
                            playerInput = Console.ReadLine();
                            playCol = int.TryParse(playerInput, out playCol)? playCol : 0;
                        }
                        while ( playCol < 1 || playCol > Board.MaxCol );
                    }
                    else
                    {
                        if (isMoveValid == false)
                        {
                            Console.WriteLine("Oops! The last move cannot be made because column is full.");
                        }
                        playerInput = ((compPlayer)nextPlayer).smartMove(Board.MaxCol);
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine(nextPlayer.name + " (computer) play at column " + playerInput);
                    }
                    isMoveValid = false;

                } while (!board.Move(nextPlayer.playOrder, Int32.Parse(playerInput)));

                Console.WriteLine(board);
                int who_win = board.hasFinished();
                if (who_win == 0 )
                {
                    Console.WriteLine("It's a tie!");
                }
                else if (who_win == Board.PLAYER1 )
                {
                    Console.WriteLine($"It's a connect 4! {p1.name} wins!");
                }
                else if( who_win == Board.PLAYER2)
                {
                    Console.WriteLine($"It's a connect 4! {p2.name} wins!");
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            gameControl game = new gameControl();
        }
    }
}
