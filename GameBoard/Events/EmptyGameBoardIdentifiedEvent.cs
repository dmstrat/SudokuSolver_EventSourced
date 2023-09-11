using System.ComponentModel;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace SudokuGameBoard.Events
{
  public class EmptyGameBoardIdentifiedEvent : GameBoardEvent
  {
    public EmptyGameBoardIdentifiedEvent()
    {
      Name = "Empty GameBoard Identified";
      EventId = new Guid("{3F17C91D-759D-4D7E-AF26-7358502C8CF0}");
    }

    public override void ApplyTo(GameBoard gameBoard)
    {
      throw new NotImplementedException();
    }
  }
}
