using System;
using System.Runtime.Intrinsics.X86;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    public class Board
    {
        // class member incomplete
        // create data structure to store the board
        // this is only a dummy as a placeholder
        public string state { get; private set; }
        const string P1 = "X"; // symbol for p1
        const string P2 = "O"; // symbol for p2
        public const int MaxCol = 7; // column from 1 to MaxCol
        public const int MaxRow = 6; // column from 1 to MaxRow


        public Board()
        {
            state = "";
        }

        public int hasFinished() {
            // return 0 = draw, 1 = player1 won, 2 = player2 won, -1 = not finished
            return -1;
        }

        public bool Move (int player, int col)
        {
            // return true if play valid and completed
            return false;
        }

        public override string ToString()
        {
            // return print out of board as string
            // add a line for win or draw if hasFinished() != -1

            string printout = state;
            return printout;
        }

    }

    public class Player
    {
        public string name { get; private set; }
        public bool isHuman { get; private set; }
        public int playOrder { get; private set; }

        public Player(string name, bool isHuman, int playOrder)
        {
            this.name = name;
            this.isHuman = isHuman;
            this.playOrder = playOrder;
        }
    }

    public class compPlayer : Player
    {
        public compPlayer (int playOrder ): base ( "AI", false, playOrder)
        {

        }
        public string smartMove (int maxCol) 
        { 
            Random rnd = new Random ();
            return rnd.Next(1,maxCol+1).ToString(); 
        }

    }

    public class gameControl
    {
        public int num_player { get; private set; }
        private Player p1;
        private Player p2;

        public gameControl()
        {
            string input;
            do
            {
                Console.WriteLine("Type '1' for 1 player game. Type '2' for 2 player game. Or Type 'x' to exit.");
                input = Console.ReadLine();
                if (string.Equals(input, '1'))
                {
                    num_player = 1;
                    p1 = new Player("Player1", true,1);
                    p2 = new compPlayer(2);
                    Play();
                }
                else if (string.Equals(input, "2"))
                {
                    num_player = 2;
                    p1 = new Player("Player1", true, 1);
                    p2 = new Player("Player2", true, 2);
                    Play();
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
            while (string.Equals(input, 'x') || string.Equals(input, 'X'));
        }

        public void Play()
        {
            Board board = new Board();
            Player nextPlayer = p2;
            string playerInput;
            while (board.hasFinished() != -1)
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
                do
                {
                    if (nextPlayer.isHuman)
                    {
                        Console.Write(nextPlayer.name + ", ");
                        do
                        {
                            Console.WriteLine("Play a number from 1 to MaxCol to play a move in the column");
                            playerInput = Console.ReadLine();
                        }

                        while (Int32.Parse(playerInput) is not >= 1 or <= Board.MaxCol);
                    }
                    else
                    {
                        playerInput = ((compPlayer)nextPlayer).smartMove(Board.MaxCol);
                    }
                } while (!board.Move(nextPlayer.playOrder, Int32.Parse(playerInput)) );

                Console.WriteLine(board);
            }
        }
    }
                                                  

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a Connect 4 game!\n");
            gameControl game = new gameControl();
        }
    }
}
