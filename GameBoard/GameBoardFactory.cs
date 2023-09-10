using Microsoft.Extensions.Logging;

namespace SudokuGameBoard
{
  public static class GameBoardFactory
  {
    public static GameBoard Create(ILogger? logger = null)
    {
      return new GameBoard(logger);
    }
  }
}
