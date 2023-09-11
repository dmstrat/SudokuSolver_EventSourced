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
      Name = GameBoardGuides.GameBoardPuzzleValuesAddedEventName;
      EventId = GameBoardGuides.GameBoardPuzzleValuesAddedEventEventId;
      GamePuzzleValuesAsZeroOrSpaceString = puzzleValues;
    }

    public override void ApplyTo(GameBoard gameBoard)
    {
      gameBoard.SetPuzzleValues(GamePuzzleValuesAsZeroOrSpaceString);
    }
  }
}
