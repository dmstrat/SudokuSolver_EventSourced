using System.Globalization;
using Microsoft.Extensions.Logging;
using SudokuGameBoard.Events;
using SudokuGameBoard.Guides;
using SudokuGameBoard.Helpers;
using SudokuGameBoard.Loggers;

namespace SudokuGameBoard
{
  public class GameBoard
  {
    public ILogger? Logger { get; set; }
    public IEnumerable<GameCell> Cells { get; set; }

    public IEnumerable<GameBoardEvent> EventHistory { get; internal set; } = new List<GameBoardEvent>();

    private const string EMPTY_VALUE_AS_ZERO = " ";
    private const string EMPTY_VALUE_AS_SPACE = "0";

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

    public void SetPuzzleValues(string gamePuzzleValuesAsZeroOrSpaceString)
    {
      //EnsureStringIsLongEnough();
      //EnsureAllValuesAreValid();
      //PutAllValuesIntoGameBoard
      for (var index = 0; index < GameBoardGuides.GAME_BOARD_CELL_COUNT; index++)
      {
        var unparsedNextValue = gamePuzzleValuesAsZeroOrSpaceString[index].ToString();
        var isNotEmptyCellValue = unparsedNextValue is not (EMPTY_VALUE_AS_SPACE or EMPTY_VALUE_AS_ZERO);

        if (isNotEmptyCellValue)
        {
          _ = int.TryParse(unparsedNextValue, NumberStyles.Integer, null, out var cellValue);
          Cells.ElementAt(index).SetValue(cellValue);
        }
      }
    }
  }
}