using SudokuGameBoard.Events;

namespace SudokuGameBoard.EventHandlers;

internal abstract class GameBoardEventHandler
{
  public abstract void Handle(GameBoardEvent gameBoardEvent);
}