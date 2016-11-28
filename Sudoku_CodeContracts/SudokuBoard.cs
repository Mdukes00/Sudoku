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

        public List<int> BoardToList()
        {
            throw new NotImplementedException();
        }

        public bool CheckResults()
        {
            bool correct = true;
            int R = 0;
            int C = 0;
            if (!IsBoardFull())
                correct = false;
            else
            {
                while (!correct && R < 9)
                {
                    correct = CheckRows(R);
                    R++;
                }
                while (!correct && C < 9)
                {
                    correct = CheckColums(C);
                    C++;
                }

            }
            return correct;
        }

        private bool CheckRows(int R)
        {
            int n = 1;
            int aux = 0;
            int C = 0;

            for (C = 0; C < 9; C++)
            {
                aux = 0;
                for (n = 1; n < 10; n++)
                {
                    if (Board[R, C] == n)
                        aux++;
                    if (aux > 1)
                        return false;
                }
            }
            return true;
        }

        private bool CheckColums(int C)
        {
            int n = 1;
            int aux = 0;
            int R = 0;

            for (R = 0; R < 9; R++)
            {
                aux = 0;
                for (n = 1; n < 10; n++)
                {
                    if (Board[R, C] == n)
                        aux++;
                    if (aux > 1)
                        return false;
                }
            }
            return true;
        }
        public void GenerateNumbers()
        {
            throw new NotImplementedException();
        }

        public void InputNumber(int number, int x, int y)
        {
            throw new NotImplementedException();
        }

        public bool IsBoardEmpty()
        {
            throw new NotImplementedException();
        }

        public bool IsBoardFull()
        {
            throw new NotImplementedException();
        }

        public void ResetBoard()
        {
            throw new NotImplementedException();
        }
    }
}
