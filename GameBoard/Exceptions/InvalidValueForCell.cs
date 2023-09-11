namespace Sudoku.GameBoard.Exceptions
{
  public class InvalidValueForCell : Exception
  {
    private const string DEFAULT_MESSAGE = "Value Provided is invalid for GameCell.";
    public InvalidValueForCell() { }

    public InvalidValueForCell(string message = DEFAULT_MESSAGE) : base(message) { }

    public InvalidValueForCell(string message, Exception innerException) : base(message, innerException) { }

  }
}
