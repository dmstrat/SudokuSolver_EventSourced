using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SudokuGameBoard.Helpers;

namespace SudokuGameBoard
{
  public class GameBoard
  {
    public ILogger? Logger { get; set; }

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
  }
}