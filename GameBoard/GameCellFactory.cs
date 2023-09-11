using Microsoft.Extensions.Logging;

namespace SudokuGameBoard
{
  public static class GameCellFactory
  {
    public static GameCell Create(int cellIndex, ILogger? logger = null)
    {
      var newCell = new GameCell(cellIndex, logger);
      return newCell;
    }
  }
}
