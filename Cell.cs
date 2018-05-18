using System;
namespace SudokuSolver
{
    public class Cell
    {
        private string value { get; set; }
        private bool correctValue { get; set; }

        public Cell(string newvalue)
        {
            value = newvalue;
            correctValue = true;
        }

        public string getValue(){
            return value;
        }

        public bool getState(){
            return correctValue;
        }

        public void print(){
            Console.Out.Write(value);
        }
    }
}
