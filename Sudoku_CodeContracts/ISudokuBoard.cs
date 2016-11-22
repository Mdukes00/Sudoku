using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Sudoku_CodeContracts
{
    //M1: Matrix[9, 9] of Integers
    [ContractClass(typeof(SudokuBoardContract))]
    public interface ISudokuBoard
    {
        //Pre: IsBoardEmpty = true
        //Post: M1 containes at least 22 cells with numbers between 1 and 9
        void GenerateNumbers();

        void InputNumber(int number, int x, int y);

        bool CheckResults();

        void ResetBoard();

        bool IsBoardFull();

        bool IsBoardEmpty();

        List<int> BoardToList();
    }
}
