using SudokuGameBoard.Events;

namespace SudokuGameBoard.Unit.Tests
{
  internal class GameBoardEventTests
  {
    [Test]
    public void EmptyGameBoardIdentifiedEventExists()
    {
      var actualEvent = new EmptyGameBoardIdentifiedEvent();
      Assert.That(actualEvent, Is.TypeOf(typeof(EmptyGameBoardIdentifiedEvent)));
    }

    [Test]
    public void GameBoardCreatedEventExists()
    {
      var actualEvent = new GameBoardCreatedEvent();
      Assert.That(actualEvent, Is.TypeOf(typeof(GameBoardCreatedEvent)));
    }

  }
}
