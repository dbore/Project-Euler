using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Sudoku_Solver_Pro
{
    class Program
    {
static int[,] sudoku = new int[9,9]; // sudoku board
static int[,] curr = new int[9,9];

static int sudoku_puzzle_total = 0;
static int sudoku_puzzle_solved = 0;

static Int64 sum = 0; //the sum needed to solve the problem 



static String filePath = Environment.CurrentDirectory + "\\p096_sudoku.txt";

static bool can_insert(int x, int y, int value) {
    for(int i = 0; i < 9; i++) {
        if (value == curr[x,i] || value == curr[i,y] ||
            value == curr[x/3*3+i%3,y/3*3+i/3]) return false;
    } return true;
}
 
static bool next(int x, int y) {
    if (x == 8 && y == 8) return true;
    else if (x == 8) return solve(0, y + 1);
    else return solve(x + 1, y);
}
 
static bool solve(int x, int y) {
    if (sudoku[x,y] == 0) {
        for(int i = 1; i <= 9; i++) {
            if (can_insert(x, y, i)) {
                curr[x,y] = i;
                if (next(x, y)) return true;
            }
        } curr[x,y] = 0; return false;
    } return next(x, y);
}

static void clearBoard(int[,] board)
{
 for (int i = 0; i < 9; i++)
        for (int j = 0; j < 9; j++)
            board[i, j] = 0;
}

static void printBoard()
{
    Console.WriteLine();

    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            Console.Write(sudoku[i, j] + " ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}


static void readSudokuFromFile(String filename)
{
    int line_count = 0;
    int countNine = 0;
    int i = 0;
    int j = 0;
  
    using (System.IO.StreamReader streamR = new StreamReader(filename)){

       while (streamR.EndOfStream == false)
       {
          
           String line = streamR.ReadLine();
           if (line_count != 0 && line_count % 10 !=0) // do not read the labels
            {
                countNine++;
                //get each integer value individually
                foreach (char c in line)
                {
               
                  String number_value_str = Convert.ToString(c);
                    int number_value_int;
                    bool result =  int.TryParse(number_value_str, out number_value_int);
                     
                  // is number
                    if (result)
                  {
                        sudoku[i, j] = number_value_int;

                        //update j index
                        if (j < 8)
                          j++;
                        else
                            j = 0;
                    }
                    


                }

                //update i index
                i++;

            }

           if (countNine == 9) // better approach (now all 50 puzzles are tested, there is no label on the end of file)
           {
               countNine = 0;

               //count sudoku puzzle for statistics
               sudoku_puzzle_total++;

               //print the sudoku to solve
               Console.WriteLine("------------------------------");
               Console.WriteLine("Sudoku puzzle to solve:");
               printBoard();

               //start solving sudoku
               StartSolving();

               //clear sudoku and be ready to insert new one
               j = 0;
               i = 0;
               clearBoard(sudoku);
               clearBoard(curr);

               //Console.ReadKey();
           }
            
          line_count++;

        }

    }


}


static void StartSolving()
{

     Console.WriteLine("Result:\n");
    for(int i=0; i<9; i++)
        for(int j=0; j<9; j++)
            curr[i,j] = sudoku[i,j];
    if (solve(0,0)) {
        for(int i=0; i<9; i++) {
            for(int j=0; j<9; j++) {
                Console.Write(curr[i, j] + " ");
            } Console.WriteLine();
        }
        //update solved puzzle value for statistics
        sudoku_puzzle_solved++;
    } else {
        Console.WriteLine("Impossible");
    }

    //get the 3 numbers before clearing sudoku board (add the number to sum)
    String number = curr[0, 0].ToString() + curr[0, 1].ToString() + curr[0, 2].ToString();
    sum = sum + Convert.ToInt64(number);

    Console.WriteLine("------------------------------\n");
    //Console.ReadKey();
 
}

    
        static void Main(string[] args)
        {

            Console.WriteLine("Sudoku Solver Pro");
            Console.WriteLine("\nRead sudoku puzzles from file:" + filePath + "\n");

            Stopwatch time = new Stopwatch();
            time.Start();
            readSudokuFromFile(filePath);
            time.Stop();

            Console.WriteLine("Total sudoku puzzles: " + sudoku_puzzle_total.ToString());
            Console.WriteLine("No. of solved sudoku puzzles: " + sudoku_puzzle_solved.ToString());
            Console.WriteLine("\nThe answer is: " + sum.ToString());
            Console.WriteLine("Time taken to calculate the answer: " + time.Elapsed.ToString() + " in milliseconds = " + time.ElapsedMilliseconds.ToString() );
            Console.WriteLine("finished ...");
            Console.ReadKey();

}

       

        }
    }

