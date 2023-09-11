using Microsoft.Extensions.Logging;
using SudokuGameBoard.Events;
using SudokuGameBoard.Helpers;
using SudokuGameBoard.Loggers;

namespace SudokuGameBoard
{
  public class GameBoard
  {
    public ILogger? Logger { get; set; }
    public IEnumerable<GameCell> Cells { get; set; }

    public IEnumerable<GameBoardEvent> EventHistory { get; internal set; } = new List<GameBoardEvent>();

    public GameBoard()
    {
      Logger = LoggerHelper.CreateNullLogger(typeof(GameBoard));
    }

    public GameBoard(ILogger? logger) : this()
    {
      if (logger != null)
      {
        Logger = logger;
      }
    }

    public void ApplyEvent(GameBoardEvent gameBoardEvent)
    {
      //apply the event
      gameBoardEvent.ApplyTo(this);
      //add to event history
      AddEventToHistory(gameBoardEvent);
      Logger!.LogEvent(gameBoardEvent.EventId, gameBoardEvent.Name, "---no message--");
    }

    private void AddEventToHistory(GameBoardEvent gameBoardEvent)
    {
      var incomingEvent = new List<GameBoardEvent>() { gameBoardEvent };
      EventHistory = EventHistory.Concat(incomingEvent);
    }
  }
}