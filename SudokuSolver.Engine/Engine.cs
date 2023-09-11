using Microsoft.Extensions.Logging;
using SudokuGameBoard;
using SudokuSolver.Engine.Helpers;

namespace SudokuSolver.Engine
{
  public class Engine
  {
    public ILogger? Logger { get; set; }

    public Engine()
    {
      Logger = LoggerHelper.CreateNullLogger(typeof(GameBoard));
    }

    public Engine(ILogger? logger) : this()
    {
      if (logger != null)
      {
        Logger = logger;
      }
    }
  }
}