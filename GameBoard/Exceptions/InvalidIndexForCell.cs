namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidIndexForCell : Exception
  {
    private const string DEFAULT_MESSAGE = "Value Provided is invalid for GameCell.";
    public InvalidIndexForCell() { }

    public InvalidIndexForCell(string message = DEFAULT_MESSAGE) : base(message) { }

    public InvalidIndexForCell(string message, Exception innerException) : base(message, innerException) { }

  }
}
