using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_CodeContracts
{
    class SudokuBoard : ISudokuBoard
    {
        public int[,] Board;

        protected SudokuBoard()
        {
            Board = new int[9, 9];
            
        }

        public void GenerateNumbers()
        {
            IsBoardEmpty();
        }

        public void InputNumber(int number, int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool CheckResults()
        {
            throw new NotImplementedException();
        }

        public void ResetBoard()
        {
            throw new NotImplementedException();
        }

        public bool IsBoardFull()
        {
            throw new NotImplementedException();
        }

        public bool IsBoardEmpty()
        {
            Random ran = new Random();
            int gen;
            gen = ran.Next(1, 9 + 1);
            if (BoardToList().Count > 23)
            {
                return true;
                
            }
            else
            {
                while (BoardToList().Count() < 23)
                {

                    BoardToList().Add(gen);
                    if (BoardToList().Count() > 23)
                    {
                        return true;
                    }
                }
                return true;
            }
       }
        

        public List<int> BoardToList()
        {
            return Board.OfType<int>().ToList();
        }
    }
}
