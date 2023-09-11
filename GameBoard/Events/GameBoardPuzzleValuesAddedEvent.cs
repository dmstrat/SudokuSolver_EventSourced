using SudokuGameBoard.Guides;

namespace SudokuGameBoard.Events
{
  /// <summary>
  /// Adds the required GameCells to the GameBoard
  /// First Event to be applied to overall game
  /// </summary>
  public class GameBoardPuzzleValuesAddedEvent : GameBoardEvent
  {
    public string GamePuzzleValuesAsZeroOrSpaceString { get; set; }
    public GameBoardPuzzleValuesAddedEvent(string puzzleValues)
    {
      Name = "Puzzle Values Added";
      EventId = new Guid("43A289A1-B405-4584-A19A-4325C9AFDCBB");
      GamePuzzleValuesAsZeroOrSpaceString = puzzleValues;
    }

    public override void ApplyTo(GameBoard gameBoard)
    {
      gameBoard.SetPuzzleValues(GamePuzzleValuesAsZeroOrSpaceString);
    }
  }
}
