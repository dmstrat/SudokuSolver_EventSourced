namespace Sudoku.GameBoard.Exceptions
{
  public class GameBoardAlreadyHasGameCells : Exception
  {
    private const string DEFAULT_MESSAGE = "Game Board can only have the GameCells added once.";
    public GameBoardAlreadyHasGameCells() { }

    public GameBoardAlreadyHasGameCells(string message = DEFAULT_MESSAGE) : base(message) { }

    public GameBoardAlreadyHasGameCells(string message, Exception innerException) : base(message, innerException) { }

  }
}
