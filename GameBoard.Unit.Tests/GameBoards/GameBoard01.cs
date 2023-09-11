namespace SudokuGameBoard.Unit.Tests.GameBoards
{
  public static class GameBoard01
  {
    public const string Solved = "123456789" +
                                 "456789123" +
                                 "789123456" +
                                 "234567891" +
                                 "567891234" +
                                 "891234567" +
                                 "345678912" + 
                                 "678912345" +
                                 "912345678";

    public const string Input_EmptyAsZeros = "123456780" + 
                                             "456789123" + 
                                             "789123056" +
                                             "234567891" +
                                             "567891234" +
                                             "891204567" +
                                             "345678912" +
                                             "678912345" +
                                             "912045678";

    public const string Input_EmptyAsSpaces = "12345678 " +
                                              "456789123" +
                                              "789123 56" +
                                              "234567891" +
                                              "567891234" +
                                              "8912 4567" +
                                              "345678912" +
                                              "678912345" +
                                              "912 45678";
  }
}
