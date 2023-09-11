using Sudoku.GameBoard.Exceptions;

namespace SudokuGameBoard
{
  public static class GameCellChangeFactory
  {
    public static GameCellChange Create(int cellIndex, int? value, IEnumerable<int> pencilMarksEffected)
    {
      ValidateCellIndexValue(cellIndex);
      ValidatePencilMarkValues(pencilMarksEffected);
      ValidateCellValue(value);

      var newGameCellChange = new GameCellChange(cellIndex)
      {
        PencilMarksEffected = pencilMarksEffected,
        Value = value
      };

      return newGameCellChange;
    }

    private static void ValidateCellValue(int? value)
    {
      var isInvalidValue = value is (< 0 or > 9);
      if (isInvalidValue)
      {
        throw new InvalidValueForCell("Value can NOT be out of range.");
      }
    }

    private static void ValidatePencilMarkValues(IEnumerable<int> pencilMarksEffected)
    {
      var hasInvalidValues = pencilMarksEffected.Any(x => x is (< 1 or > 9));
      if (hasInvalidValues)
      {
        throw new InvalidValueForCell("Pencil Marks can NOT be out of range.");
      }
    }

    private static void ValidateCellIndexValue(int cellIndex)
    {
      var isInvalidValue = cellIndex is(< 0 or > 80);
      if (isInvalidValue)
      {
        throw new InvalidIndexForCell("Cell Index can NOT be out of range.");
      }
    }
  }
}
