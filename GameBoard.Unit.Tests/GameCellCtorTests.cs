using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests
{
  public class GameCellCtorTests
  {
    private readonly ILogger _Logger;

    public GameCellCtorTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameCellCtorTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void GameCellCtorReturnsTypeofGameCell()
    {
      var gameCell = new GameCell();
      Assert.That(gameCell, Is.TypeOf(typeof(GameCell)));
    }

    [Test]
    public void GameCellFactoryReturnsTypeofGameCell()
    {
      var expectedIndex = 0;
      var gameCell = GameCellFactory.Create(expectedIndex);
      Assert.That(gameCell, Is.TypeOf(typeof(GameCell)));
      Assert.That(gameCell.Logger, Is.Not.Null);
      Assert.That(gameCell.Logger, Is.TypeOf(typeof(NullLogger)));
    }

    [Test]
    public void GameCellFactoryHandlesOptionalLoggerReturnsTypeofGameCell()
    {
      var expectedIndex = 0;
      var gameCell = GameCellFactory.Create(expectedIndex, _Logger);
      Assert.That(gameCell, Is.TypeOf(typeof(GameCell)));
      Assert.That(gameCell.Index, Is.EqualTo(expectedIndex));
      Assert.That(gameCell.Logger, Is.Not.Null);
      Assert.That(gameCell.Logger, Is.TypeOf(typeof(Logger<GameCellCtorTests>)));
    }
  }
}