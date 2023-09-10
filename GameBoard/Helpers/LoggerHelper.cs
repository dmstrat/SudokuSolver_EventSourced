using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SudokuGameBoard.Helpers
{
  internal static class LoggerHelper
  {
    public static ILogger CreateNullLogger(Type typeForLogger)
    {
      var loggerFactory = new NullLoggerFactory();
      var logger = loggerFactory.CreateLogger(typeForLogger);
      return logger;
    }
  }
}
