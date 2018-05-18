using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    ////////////////////////////////////////////////////////////
    // This class contains a list of cell objects.
    // This is an individual row in a Sudoku puzzle
    // Able to print individual rows as needed using print function
    ////////////////////////////////////////////////////////////
    public class Row
    {
        public List<Cell> row { get; set; }
        public List<string> values { get; set; }
        public int cellsRem { get; set; }

        public Row(Cell[,] p, int rowIndex, int rowLength)
        {
            row = new List<Cell>();
            values = new List<string>();
            for (int i = 0; i < rowLength; i++)
            {
                row.Add(p[rowIndex,i]);
                values.Add(p[rowIndex, i].getValue());
                if (p[rowIndex, i].getValue() == "-")
                    cellsRem++;
            }
        }

        public void printRow(){
            foreach(Cell c in row){
                Console.Out.Write(c.getValue() + " ");
            }
        }
    }
}
