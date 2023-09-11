using SudokuGameBoard.Guides;

namespace SudokuGameBoard.Events
{
  /// <summary>
  /// Adds the required GameCells to the GameBoard
  /// First Event to be applied to overall game
  /// </summary>
  public class GameBoardCreatedEvent : GameBoardEvent
  {
    public GameBoardCreatedEvent()
    {
      Name = "Board Created";
      EventId = new Guid("73B211DE-21C3-4FC9-8E52-ECB4A06B1024");
    }

    public override void ApplyTo(GameBoard gameBoard)
    {
      var gameCells = new List<GameCell>();
      for (var cellIndex = 0; cellIndex < GameBoardGuides.GAME_BOARD_CELL_COUNT; cellIndex++)
      {
        var newCell = GameCellFactory.Create(cellIndex);
        gameCells.Add(newCell);
      }
      gameBoard.Cells = gameCells;
    }
  }
}
