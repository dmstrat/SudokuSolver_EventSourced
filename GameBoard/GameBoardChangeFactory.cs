using Sudoku.GameBoard.Exceptions;

namespace SudokuGameBoard
{
  public static class GameBoardChangeFactory
  {
    public static GameBoardChange Create()
    {
      return new GameBoardChange();
    }
  }
}
