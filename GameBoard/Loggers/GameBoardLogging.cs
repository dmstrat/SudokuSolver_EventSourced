using Microsoft.Extensions.Logging;

namespace SudokuGameBoard.Loggers
{
  internal static partial class GameBoardLogging
  {
    [LoggerMessage(
      EventId = 3,
      Message = "{eventId}|{eventName}|{message}",
      Level = LogLevel.Information)]
    internal static partial void LogEvent(
      this ILogger logger,
      Guid eventId,
      string eventName,
      string message);
  }
}
