using Microsoft.Extensions.Logging;
using Sudoku.GameBoard.Exceptions;
using SudokuGameBoard.Events;
using SudokuGameBoard.Unit.Tests.Loggers;

namespace SudokuGameBoard.Unit.Tests.Events
{
  public class ApplyGameBoardCreatedEventTests
  {
    private readonly ILogger _Logger;

    public ApplyGameBoardCreatedEventTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<ApplyGameBoardCreatedEventTests>();
    }

    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void ApplyGameBoardCreatedEventReturnsCorrectGameBoard()
    {
      var gameBoard = GameBoardFactory.Create(_Logger);
      var gameBoardCreatedEvent = new GameBoardCreatedEvent();


      gameBoard.ApplyEvent(gameBoardCreatedEvent);

      var expectedCellCount = 81;
      var expectedHistoryCount = 1;

      Assert.Multiple(() =>
      {
        Assert.That(gameBoard, Is.TypeOf(typeof(GameBoard)));
        Assert.That(gameBoard.Cells, Has.Exactly(expectedCellCount).Items);
        Assert.That(gameBoard.EventHistory, Has.Exactly(expectedHistoryCount).Items);
      });
    }

    [Test]
    public void ApplyGameBoardCreatedEventMoreThanOnceThrowsException()
    {
      var gameBoard = GameBoardFactory.Create(_Logger);
      var gameBoardCreatedEvent = new GameBoardCreatedEvent();

      gameBoard.ApplyEvent(gameBoardCreatedEvent);

      Assert.Throws<GameBoardAlreadyHasGameCells>(() => gameBoard.ApplyEvent(gameBoardCreatedEvent));
    }
  }
} 