/* solve Sudoku problem by
using c#*/
using System;
 
class GFG           
{
 
    public static bool isSafe(int[, ] board,
                              int row, int col,
                              int num)
    {
         
        // Row has the unique (row-clash)
        for (int d = 0; d < board.GetLength(0); d++)
        {                
             
            // Check if the number,
            //we are assuming number
            // is already present in
            // that row, return false;
            if (board[row, d] == num)
            {
                return false;
            }
        }
 
        // Column has the unique numbers (column-clash)
        for (int r = 0; r < board.GetLength(0); r++)
        {
             
            // Check if the number
            // we are assuming number 
            // place is already present in
            // that column, return false;
            if (board[r, col] == num)
            {
                return false;
            }
        }
 
        // chech in block the number 
        //corresponding square has
        // unique number (box-clash)
        int sqrt = (int)Math.Sqrt(board.GetLength(0));
        int boxRowStart = row - row % sqrt;
        int boxColStart = col - col % sqrt;
 
        for (int r = boxRowStart;
             r < boxRowStart + sqrt; r++)
        {
            for (int d = boxColStart;
                 d < boxColStart + sqrt; d++)
            {
                if (board[r, d] == num)
                {
                    return false;
                }
            }
        }
 
        // if there is no clash, it's safe
        return true;
    }
 
    public static bool solveSudoku(int[, ] board,
                                           int n)
    {
        int row = -1;
        int col = -1;
        bool isEmpty = true;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i, j] == 0)
                {
                    row = i;
                    col = j;
 
                    // We still have some remaining
                    // missing values in Sudoku
                    isEmpty = false;
                    break;
                }
            }
            if (!isEmpty)
            {
                break;
            }
        }
 
        // no empty cell left
        if (isEmpty)
        {
            return true;
        }
 
        // backtracking for each-row backtrack
        for (int num = 1; num <= n; num++)
        {
            if (isSafe(board, row, col, num))
            {
                board[row, col] = num;
                if (solveSudoku(board, n))
                {
                     
                    // Print(board, n);
                    return true;
                }
                else
                {
                     
                    // Replace it
                    board[row, col] = 0;
                }
            }
        }
        return false;
    }
 
    public static void print(int[, ] board, int N)
    {
         
        // We got the solution, just print it
        for (int r = 0; r < N; r++)
        {
            for (int d = 0; d < N; d++)
            {
                Console.Write(board[r, d]);
                Console.Write(" ");
            }
            Console.Write("\n");
 
            if ((r + 1) % (int)Math.Sqrt(N) == 0)
            {
                Console.Write("");
            }
        }
    }
 
    // given board
    public static void Main(String[] args)
    {
 
        int[, ] board = new int[, ] {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };
        int N = board.GetLength(0);
 
        if (solveSudoku(board, N))
        {
             
            // print solution
            print(board, N);
        }
        else {
            Console.Write("No solution");
        }
    }
}
