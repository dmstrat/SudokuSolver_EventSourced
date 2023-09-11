namespace SudokuGameBoard.Guides
{
  internal static class GameBoardGuides
  {
    public const int GAME_BOARD_CELL_COUNT = 81;
    public static Guid GameBoardEventEventIdDefault = new("00000000-0000-0000-0000-000000000001");
    public static string GameBoardEventNameDefault = "UNNAMED EVENT";

    //GameBoardCreatedEvent
    public static Guid GameBoardCreatedEventEventId = new("73B211DE-21C3-4FC9-8E52-ECB4A06B1024");
    public static string GameBoardCreatedEventName = "Board Created";

    //GameBoardPuzzleValuesAddedEvent
    public static Guid GameBoardPuzzleValuesAddedEventEventId = new("43A289A1-B405-4584-A19A-4325C9AFDCBB");
    public static string GameBoardPuzzleValuesAddedEventName = "Puzzle Values Added";


  }
}
