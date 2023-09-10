using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests
{
  public class GameBoardCtorTests
  {
    private readonly ILogger _Logger;

    public GameBoardCtorTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardCtorTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void GameBoardCtorReturnsTypeofGameBoard()
    {
      var gameBoard = new GameBoard();
      Assert.That(gameBoard, Is.TypeOf(typeof(GameBoard)));
    }

    [Test]
    public void GameBoardFactoryReturnsTypeofGameBoard()
    {
      var gameBoard = GameBoardFactory.Create();
      Assert.That(gameBoard, Is.TypeOf(typeof(GameBoard)));
      Assert.That(gameBoard.Logger, Is.Not.Null);
      Assert.That(gameBoard.Logger, Is.TypeOf(typeof(NullLogger)));
    }

    [Test]
    public void GameBoardFactoryHandlesOptionalLoggerReturnsTypeofGameBoard()
    {
      var gameBoard = GameBoardFactory.Create(_Logger);
      Assert.That(gameBoard, Is.TypeOf(typeof(GameBoard)));
      Assert.That(gameBoard.Logger, Is.Not.Null);
      Assert.That(gameBoard.Logger, Is.TypeOf(typeof(Logger<GameBoardCtorTests>)));
    }
  }
}