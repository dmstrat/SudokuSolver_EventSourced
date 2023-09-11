using Sudoku.GameBoard.Exceptions;
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
      Name = GameBoardGuides.GameBoardCreatedEventName;
      EventId = GameBoardGuides.GameBoardCreatedEventEventId;
    }

    public override void ApplyTo(GameBoard gameBoard)
    {
      ValidateEvent(gameBoard);
      var gameCells = new List<GameCell>();
      for (var cellIndex = 0; cellIndex < GameBoardGuides.GAME_BOARD_CELL_COUNT; cellIndex++)
      {
        var newCell = GameCellFactory.Create(cellIndex);
        gameCells.Add(newCell);
      }
      gameBoard.Cells = gameCells;
    }

    public override void ValidateEvent(GameBoard gameBoard)
    {
      var boardAlreadyInitialized = gameBoard.Cells?.Any() ?? false;
      if (boardAlreadyInitialized)
      {
        throw new GameBoardAlreadyHasGameCells("This event can only be applied once to an existing Game Board");
      }
    }
  }
}
