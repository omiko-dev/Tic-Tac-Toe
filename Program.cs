using System;
using System.Diagnostics;

namespace ConsoleApp2
{
    public class TicTacToe
    {
        public char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public char currentPlayer = 'X';
        public bool gameWon = false;
        public bool gameDraw = false;
        public bool Bot = false;

        private bool botCheker = false;
        private int TurnCounte = -1;
        private bool LogoShow = true;

        public void PrintBoard()
        {
            if (LogoShow)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t╔═══════════════╗");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t║  Tic-Tac-Toe  ║");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t╚═══════════════╝");
                Console.ResetColor();
                LogoShow = false;
            }

            if (TurnCounte > -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"________________Move: {TurnCounte++}_________________ ");
                Console.ResetColor();    
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t _____ _____ _____");
            Console.WriteLine("\t|     |     |     |");
            Console.WriteLine($"\t|  {board[0]}  |  {board[1]}  |  {board[2]}  |");
            Console.WriteLine("\t|_____|_____|_____|");
            Console.WriteLine("\t|     |     |     |");
            Console.WriteLine($"\t|  {board[3]}  |  {board[4]}  |  {board[5]}  |");
            Console.WriteLine("\t|_____|_____|_____|");
            Console.WriteLine("\t|     |     |     |");
            Console.WriteLine($"\t|  {board[6]}  |  {board[7]}  |  {board[8]}  |");
            Console.WriteLine("\t|_____|_____|_____|");
            Console.ResetColor();

            if(botCheker == false)
            {
                Bot = GameType();
                TurnCounte++;
            }
            

            botCheker = true;

        }

        public bool GameType()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("[0]  Player VS PLayer");
            Console.WriteLine("[1]  Player vs Bot");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Choose Game Type: ");
            Console.ForegroundColor = ConsoleColor.Red;
            string gameType = Console.ReadLine()!;
            Console.ResetColor();

            while (gameType != "1" && gameType != "0")
            {
                Console.Write("Choose Correct Type: ");
                gameType = Console.ReadLine()!;
            }
            if (gameType == "0")
            {
                return false;
            }

            return true;
        }


        public bool CheckForWin()
        {
            if ((board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer) ||
                (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer) ||
                (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer) ||
                (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer) ||
                (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
                (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
                (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer) ||
                (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        public void ChangePlayers()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        public void MakeMove(int move)
        {
            board[move] = currentPlayer;
        }

        public bool Draw()
        {
            if (board[0] != '1' && board[1] != '2' && board[2] != '3' && board[3] != '4' && board[4] != '5' && board[5] != '6' && board[6] != '7' && board[7] != '8' && board[8] != '9')
            {
                return true;
            }
            return false;
        }




    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Stopwatch stopwatch = new Stopwatch();



            Console.WriteLine("Timer started. Press any key to exit.");

            Random rand = new Random();
            
            TicTacToe ticTacToe = new TicTacToe();
            bool terminate = true;
            char player1 = (new Random().Next(2) == 0) ? 'X' : 'O';
            char player2 = (player1 == 'X') ? 'O' : 'X';

            while (terminate)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.WriteLine($"Player 1: {player1}, Player 2: {player2}");
                Console.WriteLine("\n");
                ticTacToe.PrintBoard();
                Console.WriteLine("\n");

                while (!ticTacToe.gameWon)
                {
                    int move;
                    if (ticTacToe.Bot == true && ticTacToe.currentPlayer == player2) //bot checker
                    {
                        move = rand.Next(1, 9);
                        stopwatch.Start();
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        stopwatch.Stop();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{ticTacToe.currentPlayer} please make a move: ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        move = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();
                    }

                    if (move < 1 || move > 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid move. Enter a number between 1 and 9");
                        Console.ResetColor();
                        continue;
                    }

                    if (ticTacToe.board[move - 1] != 'X' && ticTacToe.board[move - 1] != 'O')
                    {
                        ticTacToe.MakeMove(move - 1);  // Move
                        ticTacToe.gameWon = ticTacToe.CheckForWin();  //Check win
                        ticTacToe.gameDraw = ticTacToe.Draw(); //Check draw
                        ticTacToe.PrintBoard();

                        if (ticTacToe.gameWon)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            Console.WriteLine($"\t\t\t\t\a{ticTacToe.currentPlayer} Has Won The Game!");
                            Console.WriteLine("--------------------------------------------------------------------------------");
                            break;
                        }

                        if (ticTacToe.gameDraw)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            Console.WriteLine("\t\t\t\t\aThis game is a draw!");
                            Console.WriteLine("-----------------------------------------------------------------------------");
                            break;
                        }

                        ticTacToe.ChangePlayers(); //Change player
                    }
                    else
                    {
                        if (ticTacToe.Bot == true && ticTacToe.currentPlayer == player2)
                        {
                           continue;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Square is already occupied Enter another move!");
                        Console.ResetColor();
                        continue;
                    }
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to play again, press 'y'. If not, press 'n'. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                string key = Console.ReadLine()!.ToLower();
                Console.ResetColor();

                if (key == "y")
                {
                    ticTacToe = new TicTacToe();
                }
                else if (key == "n")
                {
                    terminate = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have chosen an incorrect symbol. The program will terminat!!!");
                    Console.ResetColor();
                    terminate = false;
                }

            }

            Console.ReadLine();
        }
    }
}
