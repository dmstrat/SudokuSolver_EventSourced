using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests
{
  public class GameCellChangeTests
  {
    private readonly ILogger _Logger;

    public GameCellChangeTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<GameCellChangeTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [TestCase(0, null, new[] { 1 })]
    [TestCase(1, 0, new[] { 1, 2 })]
    [TestCase(8, 1, new[] { 1, 3 })]
    [TestCase(9, 2, new[] { 4 })]
    [TestCase(15, 3, new[] { 1, 2, 3 })]
    [TestCase(16, 4, new[] { 5 })]
    [TestCase(35, 5, new[] { 5, 6, 7 })]
    [TestCase(36, 6, new[] { 7 })]
    [TestCase(79, 7, new[] { 7, 8 })]
    [TestCase(80, 8, new[] { 8, 9 })]
    [TestCase(56, 9, new[] { 8, 9 })]
    public void GameCellChangeCtorKeepsValues(int cellIndex, int? value, int[] pencilMarksEffected)
    {
      var expectedPencilMarks = pencilMarksEffected.ToList();
      var gameCell = GameCellChangeFactory.Create(cellIndex, value, expectedPencilMarks);
      Assert.Multiple(() =>
      {
        Assert.That(gameCell, Is.TypeOf(typeof(GameCellChange)));
        Assert.That(gameCell.CellIndex, Is.EqualTo(cellIndex));
        Assert.That(gameCell.Value, Is.EqualTo(value));
        Assert.That(gameCell.PencilMarksEffected, Is.EquivalentTo(expectedPencilMarks));
      });
    }

    [TestCase(-99, null, new[] { 1 })]
    [TestCase(-1, null, new[] { 1 })]
    [TestCase(81, null, new[] { 1 })]
    [TestCase(99, null, new[] { 1 })]
    public void GameCellChangeCtorWithInvalidCellIndexThrowsException(int cellIndex, int? value,
      int[] pencilMarksEffected)
    {
      var expectedPencilMarks = pencilMarksEffected.ToList();
      Assert.Throws<InvalidIndexForCell>(() =>
      {
        _ = GameCellChangeFactory.Create(cellIndex, value, expectedPencilMarks);
      });
    }

    [TestCase(0, null, new[] { 0 })]
    [TestCase(0, null, new[] { 10 })]
    [TestCase(0, null, new[] { 99 })]
    [TestCase(0, null, new[] { -1 })]
    public void GameCellChangeCtorWithInvalidPencilMarksThrowsException(int cellIndex, int? value,
      int[] pencilMarksEffected)
    {
      var expectedPencilMarks = pencilMarksEffected.ToList();
      Assert.Throws<InvalidValueForCell>(() =>
      {
        _ = GameCellChangeFactory.Create(cellIndex, value, expectedPencilMarks);
      });
    }

    [TestCase(0, -1, new[] { 1 })]
    [TestCase(0, 10, new[] { 1 })]
    [TestCase(0, -99, new[] { 1 })]
    [TestCase(0, 99, new[] { 1 })]
    public void GameCellChangeCtorWithInvalidValuesThrowsException(int cellIndex, int? value,
      int[] pencilMarksEffected)
    {
      var expectedPencilMarks = pencilMarksEffected.ToList();
      Assert.Throws<InvalidValueForCell>(() =>
      {
        _ = GameCellChangeFactory.Create(cellIndex, value, expectedPencilMarks);
      });
    }
  }
}