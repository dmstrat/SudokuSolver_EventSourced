namespace SudokuGameBoard.Events;

public abstract class GameBoardEvent
{
  public string Name { get; internal set; } = "UNNAMED EVENT";
  public Guid EventId { get; internal set; } = new ("00000000-0000-0000-0000-000000000001");

  public abstract void ApplyTo(GameBoard gameBoard);
}