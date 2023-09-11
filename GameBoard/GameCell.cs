using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using SudokuGameBoard.Helpers;

namespace SudokuGameBoard;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class GameCell
{
  private const string EMPTY_VALUE_AS_STRING = " ";

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
  private string DebuggerDisplay
  {
    get
    {
      var cellValue = Value.HasValue ? Value.Value.ToString() : EMPTY_VALUE_AS_STRING;
      var debuggerString =
        $"<{Index}>[{cellValue}]:";// {string.Join(",", PencilMarks)} / group: {GroupIndex} / row: {RowIndex} / column: {ColumnIndex} /";
      return debuggerString;
    }
  }

}