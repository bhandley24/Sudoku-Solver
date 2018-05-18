using System.Collections.Generic;
using System;

namespace SudokuSolver
{
    public class OneLeftStrategy : Strategy
    {
        private bool Solved { get; set; }
        public override string name { get; set; }
        public override Puzzle puzzle { get; set; }

        private void setName(string n)
        {
            name = n;
        }

        public string getName()
        {
            return name;
        }

        public OneLeftStrategy(){
            setName("One Left Strategy");
        }


        private Cell findMissing(Row r, Puzzle p)
        {
            foreach(string c in p.possible)
            {
                Cell temp = new Cell(c);
                if (!r.values.Contains(c))
                    return temp;
            }
            return null;
        }


        private void fillRow(Row r, Cell c){
            for (int i = 0; i < r.row.Count; i++){
                if (r.row[i].getValue() == "-")
                {
                    r.row[i] = c;
                    break;
                }
                    
            }
        }
        public override bool Solve(Puzzle p)
        {
            Solved = false;

            foreach (Row r in p.rows)
            {
                if (r.cellsRem != 1) {
                    Solved = false;
                }

                else
                {
                    Cell missing = findMissing(r, p);
                    fillRow(r, missing);
                    Solved = true;
                }
            }
            return Solved;
        }

    }
}
