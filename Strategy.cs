using System;
namespace SudokuSolver
{
    // Super Class for a given Strategy
    // A Strategy is expected to solve a Sudoku puzzle if it is possible
    public abstract class Strategy
    {
        public abstract string name { get; set; }
        public abstract Puzzle puzzle { get; set; }
        public abstract bool Solve(Puzzle p);
    }
}
