using Microsoft.Extensions.Logging;

namespace SudokuGameBoard
{
  public static class GameBoardFactory
  {
    public static GameBoard Create(ILogger? logger = null)
    {
      var newGameBoard = new GameBoard(logger);
      return newGameBoard;
    }
  }
}
