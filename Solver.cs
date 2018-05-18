using System;

namespace SudokuSolver
{
    
    ////////////////////////////////////////////////////////////
    // This class is the brains behind the Sudoku Solver
    // This holds strategy objects that, provided a Sudoku Puzzle, will solve a Sudoku Puzzle
    ////////////////////////////////////////////////////////////

    public class Solver
    {
        public Puzzle puzzle;
        private Strategy OLF = new OneLeftStrategy();
        private bool useOLF { get; set; }

        private bool UseOLF(){
            foreach (Row r in puzzle.rows)
            {
                if (r.cellsRem != 1)
                {
                    useOLF = false;
                }
            }

            foreach(Column c in puzzle.columns)
            {
                if(c.cellsRem != 1)
                {
                    useOLF = false;
                }
            }

            foreach(Block b in puzzle.blocks)
            {
                if (b.cellsRem != 1)
                {
                    useOLF = false;
                }
            }
            return useOLF;
        }
        public Solver(string file){
            puzzle = new Puzzle(file);
            Console.Out.WriteLine("New Puzzle:");
            puzzle.PrintBoard();

            useOLF = true;
            UseOLF();


            if (OLF.Solve(puzzle))
            {
                Console.Out.Write("Solved Using: " + OLF.name + "\n");
                puzzle.printRows();
            }

            else
            {
                Console.Out.Write("Not Solved");
            }
        }
    }
}
