using SudokuGameBoard.Guides;

namespace SudokuGameBoard.Events;

public abstract class GameBoardEvent
{
  public string Name { get; internal set; } = GameBoardGuides.GameBoardEventNameDefault;
  public Guid EventId { get; internal set; } = GameBoardGuides.GameBoardEventEventIdDefault;

  public abstract void ApplyTo(GameBoard gameBoard);

  public virtual void ValidateEvent(GameBoard gameBoard)
  {
    //intentional no-op
  }
}