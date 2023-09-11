using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests
{
  public class GameCellValueTests
  {
    private readonly ILogger _Logger;

    public GameCellValueTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameCellValueTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [TestCase(0, 1)]
    [TestCase(0, 2)]
    [TestCase(0, 3)]
    [TestCase(0, 4)]
    [TestCase(0, 5)]
    [TestCase(0, 6)]
    [TestCase(0, 7)]
    [TestCase(0, 8)]
    [TestCase(0, 9)]
    public void GameCellSetValueKeepsValue(int cellIndex, int initialValue)
    {
      var gameCell = GameCellFactory.Create(cellIndex);
      gameCell.SetValue(initialValue);
      Assert.Multiple(() =>
      {
        Assert.That(gameCell, Is.TypeOf(typeof(GameCell)));
        Assert.That(gameCell.Value, Is.EqualTo(initialValue));
      });
    }

    [TestCase(0, 0)]
    [TestCase(0, 10)]
    public void GameCellSetInvalidValueWillException(int cellIndex, int invalidInitialValue)
    {
      var gameCell = GameCellFactory.Create(cellIndex);
      Assert.Throws<InvalidValueForCell>(() => gameCell.SetValue(invalidInitialValue));
    }
  }
}