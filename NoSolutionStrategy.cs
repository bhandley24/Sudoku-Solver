using System;
namespace SudokuSolver
{
    public class NoSolutionStrategy : Strategy
    {
        public override string name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Puzzle puzzle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool Solve(Puzzle p)
        {
            bool solved = false;

            return solved;
        }
    }
}
