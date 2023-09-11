using Microsoft.Extensions.Logging;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests
{
  public class GameBoardChangeTests
  {
    private readonly ILogger _Logger;

    public GameBoardChangeTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameBoardChangeTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    private static readonly object[] ValidGameBoardChange01 = 
    {
      new GameCellChange[]{
        new GameCellChange(0)
        {
          PencilMarksEffected = new List<int>() { 1 },
          Value = null
        },
        new GameCellChange(1)
        {
          PencilMarksEffected = new List<int>() { 2, 3 },
          Value = null
        }
      }
    };

    [TestCaseSource(nameof(ValidGameBoardChange01))]
    public void GameBoardChangeCtorKeepsValues(GameCellChange[] cellChanges)
    {
      //assemble 
      var gameBoardChange = GameBoardChangeFactory.Create();

      //act 
      foreach (var cellChange in cellChanges)
      {
        gameBoardChange.AddChange(cellChange);
      }

      //assert 
      //CollectionAssert.
      Assert.That(gameBoardChange.CellChanges, Is.Not.Null);
      Assert.That(gameBoardChange.CellChanges, Is.All.InstanceOf<GameCellChange>());
      Assert.That(gameBoardChange.CellChanges, Has.Exactly(2).Items);
      Assert.That(gameBoardChange.CellChanges, Has.One.With.Property("CellIndex").EqualTo(0));
      Assert.That(gameBoardChange.CellChanges, Has.One.With.Property("CellIndex").EqualTo(1));
      Assert.That(gameBoardChange.CellChanges, Has.All.With.Property("Value").Null);
      Assert.That(gameBoardChange.CellChanges, Has.One.With.Property("PencilMarksEffected").Count.EqualTo(1));
      Assert.That(gameBoardChange.CellChanges, Has.One.With.Property("PencilMarksEffected").Count.EqualTo(2));
    }
  }
}