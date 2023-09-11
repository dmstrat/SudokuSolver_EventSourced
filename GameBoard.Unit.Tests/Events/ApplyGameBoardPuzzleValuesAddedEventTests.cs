using Microsoft.Extensions.Logging;
using SudokuGameBoard.Events;
using SudokuGameBoard.Unit.Tests.GameBoards;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests.Events
{
  public class ApplyGameBoardPuzzleValuesAddedEventTests
  {
    private readonly ILogger _Logger;

    public ApplyGameBoardPuzzleValuesAddedEventTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<ApplyGameBoardPuzzleValuesAddedEventTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [TestCase(GameBoard01.Input_EmptyAsSpaces)]
    [TestCase(GameBoard01.Input_EmptyAsZeros)]
    public void ApplyGameBoardCreatedEventReturnsCorrectGameBoard(string gameBoardInput)
    {
      var gameBoard = GameBoardFactory.Create(_Logger);
      var gameBoardCreatedEvent = new GameBoardCreatedEvent();
      gameBoard.ApplyEvent(gameBoardCreatedEvent);
      var gameBoardPuzzleValuesAddedEvent = new GameBoardPuzzleValuesAddedEvent(gameBoardInput);
      gameBoard.ApplyEvent(gameBoardPuzzleValuesAddedEvent);


      var expectedCellCount = 81;
      var expectedHistoryCount = 2;

      Assert.Multiple(() =>
      {
        Assert.That(gameBoard, Is.TypeOf(typeof(GameBoard)));
        Assert.That(gameBoard.Cells, Has.Exactly(expectedCellCount).Items);
        Assert.That(gameBoard.EventHistory, Has.Exactly(expectedHistoryCount).Items);
      });

      for (var index = 0; index < expectedCellCount; index++)
      {
        var actualValue = gameBoard.Cells.ElementAt(index).Value.ToString();
        var expectedValue = gameBoardInput[index].ToString() is " " or "0" ? string.Empty : gameBoardInput[index].ToString();
        Assert.That(actualValue, Is.EqualTo(expectedValue));
      }
    }
  }
}