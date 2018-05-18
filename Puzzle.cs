using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SudokuSolver
{
    ////////////////////////////////////////////////////////////
    // Puzzle is a Sudoku Puzzle object.
    // It contains representations of the puzzle in the form of rows, columns, and blocks
    // A Puzzle must be a square (4x4, 9x9, etc.)
    // A Puzzle is a collection of Cell objects.
    // Cells contain information regarding the values of a piece of a Sudoku puzzle
    // Functionality includes: 
    // being able to read a puzzle provied a file
    // Print the Sudoku Puzzle
    ////////////////////////////////////////////////////////////
    
    public class Puzzle
    {
        public int size { get; set; }
        public List<string> possible { get; set; }
        public Cell[,] puzzle {get; set;}
        private List<Row> rows { get; set; }
        private List<Column> columns { get; set; }
        private List<Block> blocks { get; set; }
        public bool solvable { get; set; }
 


        public List<Cell> Read(string fileName)
        {
            List<Cell> input = new List<Cell>();

            string path = "../../SamplePuzzles/Input/" + fileName;
            try
            {
                var fileStream = File.ReadAllLines(path);

                foreach (string x in fileStream)
                {
                    if(size == 0)
                    {
                        size = int.Parse(x);
                        continue;
                    }
                    foreach (char y in x)
                    {
                        if (y == ' ')
                            continue;
                        else
                            input.Add(new Cell(y.ToString()));
                    }
                }

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Export File Not Found : {e.Message}");
                Environment.Exit(0);
            }


            return input;
        }


        public Puzzle(string fileName)
        {
            size = 0;
            List<Cell> values = Read(fileName);
            puzzle = new Cell[size,size];
            possible = new List<string>();

            for (int x = 0; x < size; x++){
                possible.Add(values[0].getValue());
                values.RemoveAt(0);
            }

            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    puzzle[i, j] = values[count];
                    count++;
                }
            }
            getRows();
            getColumns();
            getBlocks();
        }

        private void getRows()
        {
            rows = new List<Row>();
            for (int i = 0; i < size; i++)
            {
                rows.Add(new Row(puzzle, i, size));
            }
        }

        private void getColumns(){
            columns = new List<Column>();
            for (int i = 0; i < size; i++)
            {
                columns.Add(new Column(puzzle, i, size));
            }
        }

        private void getBlocks(){
            blocks = new List<Block>();
            int step = (int)Math.Sqrt(size);
            List<Row> temp = new List<Row>();
            int start = 0;
            int end = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                temp.Add(rows[i]);
                if (i != 0 && ((i + 1) % step  == 0))
                {
                    start = 0;
                    end = step - 1;
                    for (int j = 0; j < temp.Count(); j++)
                    {
                        blocks.Add(new Block(this, temp, start, end, step));
                        start = end + 1;
                        end += step;
                    }
                    start = step - 1;
                    temp.Clear();
                    temp = new List<Row>(); 
                }
                    
            }
        }

        public void printRows(){
            foreach(Row r in rows)
            {
                r.printRow();
                Console.Out.Write("\n");
            }
        }

        public void printBlocks()
        {
            foreach (Block b in blocks)
            {
                b.printBlock();
                Console.Out.Write("\n");
            }
        }

        public void setSolvable(bool value){
            solvable = value;
        }

        public bool getSolvable()
        {
            return solvable;
        }

        public void PrintBoard(){
            Console.Out.Write("\n");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    puzzle[i, j].print();
                    Console.Out.Write(" ");
                }
                Console.Out.Write("\n");
            }
        }
    }
}
