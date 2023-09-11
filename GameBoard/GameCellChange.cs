using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SudokuGameBoard;

[DebuggerDisplay("{DebuggerDisplay,nq}")]
public class GameCellChange
{
  //remove pencil mark(s)
  //set value 
  //should we exception if we find that the 'set value' doesn't have all the associated pencil mark removals 
  //because we would not be able to 'undo' if asked because we won't have a record of those
  // OR should we generate a side effect event????
  //
  //Can we interpret this shape into BOTH: apply and undo? 

  private const int INVALID_CELLINDEX = -1;
  private const string EMPTY_VALUE_AS_STRING = " ";

  /// <summary>
  /// MUST have a cellIndex to know which cell to apply these changes
  /// </summary>
  [Required, Range(0, 80)]
  public int CellIndex { get; set; } = INVALID_CELLINDEX;
  /// <summary>
  /// The Pencil Marks, if supplied, to be removed from the GameCell when applied
  /// </summary>
  public IEnumerable<int> PencilMarksEffected { get; set; } = new List<int>();
  /// <summary>
  /// The Value, if supplied, to apply to the GameCell
  /// </summary>
  public int? Value { get; set; } = null;

  public GameCellChange() { }

  public GameCellChange(int cellIndex) : this()
  {
    CellIndex = cellIndex;
  }

  private string DebuggerDisplay
  {
    get
    {
      var cellValue = Value.HasValue ? Value.Value.ToString() : EMPTY_VALUE_AS_STRING;
      var debuggerString =
        $"<{CellIndex}>[{cellValue}]: {string.Join(",", PencilMarksEffected)} |";
      return debuggerString;
    }
  }
}