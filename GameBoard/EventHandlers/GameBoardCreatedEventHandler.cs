using SudokuGameBoard.Events;

namespace SudokuGameBoard.EventHandlers
{
  internal class GameBoardCreatedEventHandler : GameBoardEventHandler
  {
    public GameBoardCreatedEventHandler() { }
    public override void Handle(GameBoardEvent gameBoardEvent)
    {
      throw new NotImplementedException();
    }
  }
}
