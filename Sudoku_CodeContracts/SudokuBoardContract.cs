using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Sudoku_CodeContracts
{
    [ContractClassFor(typeof(ISudokuBoard))]
    internal abstract class SudokuBoardContract : ISudokuBoard
    {
        public int[,] Board;

        protected SudokuBoardContract()
        {
            Board = new int[9, 9];
        }

        public void GenerateNumbers()
        {
            Contract.Requires(IsBoardEmpty());
            Contract.Ensures(BoardToList().Count(i => i != 0) > 23);
        }

        public void InputNumber(int number, int x, int y)
        {
            Contract.Requires(0 < number && number < 10);
            Contract.Requires(Board[x, y] != 0);
            Contract.Ensures(Board[x, y] == number);
        }

        public bool CheckResults()
        {
            Contract.Requires(IsBoardFull());
            Contract.Ensures(Contract.ForAll(0, 9, i =>
                {
                    var rows = new List<int>();
                    var columns = new List<int>();
                    return Contract.ForAll(0, 9, j =>
                    {
                        if (rows.Contains(Board[i, j]))
                            return false;
                        if (columns.Contains(Board[j, i]))
                            return false;
                        rows.Add(Board[i, j]);
                        columns.Add(Board[j, i]);
                        return true;
                    });
                }));

            Contract.Ensures(Contract.ForAll(0, 9, i =>
            {
                var Boxes = new List<List<List<int>>>();
                return Contract.ForAll(0, 9, j =>
                {
                    var index1 = Math.Abs(i / 3);
                    var index2 = Math.Abs(j / 3);
                    if (Boxes[index1][index2].Contains(Board[i, j]))
                        return false;
                    Boxes[index1][index2].Add(Board[i, j]);
                    return true;
                });
            }));

            return default(bool);
        }

        public void ResetBoard()
        {
            Contract.Requires(BoardToList().Count(i => i != 0) > 0);
            Contract.Ensures(BoardToList().Count(i => i != 0) == 0);
        }

        public bool IsBoardFull()
        {
            Contract.Ensures(Contract.Result<bool>() == !BoardToList().Contains(0));
            return default(bool);
        }

        public bool IsBoardEmpty()
        {
            Contract.Ensures(
                Contract.Result<bool>()
                == BoardToList().Count(i => i != 0) > 23);
            return default(bool);
        }

        public List<int> BoardToList()
        {
            return Board.OfType<int>().ToList();
        }
    }
}
