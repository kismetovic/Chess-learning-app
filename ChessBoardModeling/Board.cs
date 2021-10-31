using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModeling
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }
        public Board (int size)
        {
            Size = size;
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }
        public void MarkNextLegalMoves (Cell currentCell, string chessPiece)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            switch (chessPiece)
            {
                case "Knight":
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "King":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;
                case "Rook":
                    markForStraightLine(currentCell.RowNumber, currentCell.ColumnNumber);
                    break;
                case "Bishop":
                    markDiagonal(currentCell.RowNumber, currentCell.ColumnNumber);
                    break;
                case "Queen":
                    markDiagonal(currentCell.RowNumber, currentCell.ColumnNumber);
                    markForStraightLine(currentCell.RowNumber, currentCell.ColumnNumber);
                    break;
                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private void markDiagonal(int rowNumber, int columnNumber)
        {
            int tempoRow = rowNumber;
            int tempoCol = columnNumber;
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow + i, tempoCol + i))
                    theGrid[tempoRow + i, tempoCol + i].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow - i, tempoCol - i))
                    theGrid[tempoRow - i, tempoCol - i].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow - i, tempoCol + i))
                    theGrid[tempoRow - i, tempoCol + i].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow + i, tempoCol - i))
                    theGrid[tempoRow + i, tempoCol - i].LegalNextMove = true;
            }
        }

        private void markForStraightLine(int rowNumber, int columnNumber)
        {
            int tempoRow = rowNumber;
            int tempoCol = columnNumber;
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow + i, tempoCol))
                    theGrid[tempoRow + i, tempoCol].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow, tempoCol + i))
                    theGrid[tempoRow, tempoCol + i].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow, tempoCol - i))
                    theGrid[tempoRow, tempoCol - i].LegalNextMove = true;
            }
            for (int i = 1; i < 8; i++)
            {
                if (isSafe(tempoRow - i, tempoCol))
                    theGrid[tempoRow - i, tempoCol].LegalNextMove = true;
            }
        }

        private bool isSafe(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 8 || y >= 8)
                return false;
            return true;
        }
    }
}
