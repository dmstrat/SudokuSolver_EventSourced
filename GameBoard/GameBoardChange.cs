namespace SudokuGameBoard
{
  /// <summary>
  /// This represents ALL changes to a GameBoard for a specific EVENT.
  /// Needs to include any side effect changes.
  /// Ex. Setting the value of a cell in this change should include
  ///   removing the pencil marks no longer valid
  /// </summary>
  public class GameBoardChange
  {
    public readonly Guid ChangeId = Guid.NewGuid();
    public IEnumerable<GameCellChange> CellChanges { get; set; } = new List<GameCellChange>();

    public void AddChange(GameCellChange change)
    {
      var changes = new List<GameCellChange>() { change };
      CellChanges = CellChanges.Concat(changes);
    }
  }
}
