using Microsoft.Extensions.Logging;
using SudokuGameBoard.Helpers;

namespace SudokuGameBoard;

public class GameCell
{
  public int Index { get; set; }
  public ILogger? Logger { get; set; }

  public GameCell()
  {
    Logger = LoggerHelper.CreateNullLogger(typeof(GameCell));
  }

  public GameCell(int index, ILogger? logger) : this()
  {
    Index = index;

    if (logger != null)
    {
      Logger = logger;
    }
  }
}