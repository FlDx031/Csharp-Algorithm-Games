using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    public static void Main(string[] args)
    {
        int moves = 0;

        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine("Player X goes first.");

        while (true)
        {
            PrintBoard();
            Console.WriteLine($"Player {currentPlayer}'s turn. Enter a position (1-9):");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
            {
                if (MakeMove(position))
                {
                    moves++;
                    if (CheckWinner())
                    {
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }

                    if (moves == 9)
                    {
                        PrintBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }

                    // Switch player
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Invalid move! The cell is already occupied.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
            }
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine($"  {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine(" ---------");
        Console.WriteLine($"  {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine(" ---------");
        Console.WriteLine($"  {board[6]} | {board[7]} | {board[8]} ");
    }

    static bool MakeMove(int position)
    {
        int index = position - 1;
        if (board[index] != 'X' && board[index] != 'O')
        {
            board[index] = currentPlayer;
            return true;
        }
        return false;
    }

    static bool CheckWinner()
    {
        // Winning combinations
        int[,] winningPositions = {
            { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, // Rows
            { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, // Columns
            { 0, 4, 8 }, { 2, 4, 6 }              // Diagonals
        };

        for (int i = 0; i < winningPositions.GetLength(0); i++)
        {
            if (board[winningPositions[i, 0]] == currentPlayer &&
                board[winningPositions[i, 1]] == currentPlayer &&
                board[winningPositions[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }
}
