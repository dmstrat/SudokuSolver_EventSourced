using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using SudokuGameBoard.Helpers;

namespace SudokuGameBoard;

public class GameCell
{
  public int Index { get; set; }
  public ILogger? Logger { get; set; }

  [Range(1,9, ErrorMessage= "Value for {0} must be between {1} and {2}.")]
  public int? Value { get; private set; }

  public GameCell()
  {
    Logger = LoggerHelper.CreateNullLogger(typeof(GameCell));
  }

  public GameCell(int index, ILogger? logger) : this()
  {
    Index = index;

    if (logger != null)
    {
      Logger = logger;
    }
  }

  public void SetValue(int newValue)
  {
    var valueIsInvalid = newValue is < 1 or > 9;
    if (valueIsInvalid)
    {
      throw new InvalidValueForCell($"value:{newValue} is INVALID");
    }
    Value = newValue;
  }
}