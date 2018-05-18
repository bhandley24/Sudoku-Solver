using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    ////////////////////////////////////////////////////////////
    // This class contains a list of cell objects.
    // This is an individual column in a Sudoku puzzle
    // Able to print individual column as needed using print function
    ////////////////////////////////////////////////////////////

    public class Column
    {
        private List<Cell> col { get; set; }
        public int cellsRem { get; set; }

        public Column(Cell[,] p, int colIndex, int colLength)
        {
            col = new List<Cell>();
            for (int i = 0; i < colLength; i++)
            {
                col.Add(p[i, colIndex]);
                if (p[i, colIndex].getValue() == "-")
                    cellsRem++;
            }
        }

        public void printColumns(){
            foreach (Cell c in col)
            {
                Console.Out.Write(c.getValue() + " ");
            }
        }

    }
}
