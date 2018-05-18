using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    ////////////////////////////////////////////////////////////
    // This Project is intended to solve Sudoku Puzzles
    // Utilizing the Template method, strategy Pattern and Factory Method
    // This program reads in a provided Sudoku Puzzle from a file provided either as command line arguments or through the UI
    // Once provided a valid Sudoku Puzzle, the program will attempt to solve it
    // Valid Puzzle must: Be square (4x4, 9x9, etc.)
    ////////////////////////////////////////////////////////////
    class MainClass
    {
        //Ensure that filename is correct incase extension is not provided
        public static string AppendExtension(string filename, string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                extension = string.Empty;

            if (string.IsNullOrWhiteSpace(filename))
                filename = string.Empty;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (!filename.EndsWith(extension))
                filename += extension;

            return filename;
        }


        public static void Main(string[] args)
        {
            string inputPuzzle = null;
            string outputPuzzle = null;
            if (args.Length == 0)
            {
                Console.Out.WriteLine("Please Enter an Unsolved Sudoku Puzzle ");
                inputPuzzle = Console.In.ReadLine();

            }
            else if (args.Length == 1){
                inputPuzzle = args[0];

            }
            else if(args.Length == 2){
                inputPuzzle = args[0];
                outputPuzzle = args[1];
            }
            else{
                Console.Out.WriteLine("Invalid Command Line Options\n Please Provide the following:\n 1) A Sudoku Input File\n 2) A Sudoku Output File (optional)");
            }

            inputPuzzle = AppendExtension(inputPuzzle, ".txt");

            Solver solver = new Solver(inputPuzzle);
           
        }
    }
}
