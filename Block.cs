using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    public class Block
    {
        public List<Cell> block { get; set; }
        public List<string> values { get; set; }
        public int cellsRem { get; set; }
        private int step { get; set; }

        public Block(Puzzle p, List<Row> row, int start, int end, int s)
        {
            step = s;
            block = new List<Cell>();
            cellsRem = 0;

            foreach(Row r in row)
            {
                for (int i = start; i < s+start; i++)
                {
                    if (r.row[i].getValue() == "-")
                        cellsRem++;
                    block.Add(r.row[i]);
                }
            }
        }

        public void printBlock()
        {
            for (int i = 0; i < block.Count; i++)
            {
                Console.Out.Write(block[i].getValue() + " ");
            }
        }
    }
}
