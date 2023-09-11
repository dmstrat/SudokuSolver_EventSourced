using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SudokuSolver.Engine.Unit.Tests.Loggers;

namespace SudokuSolver.Engine.Unit.Tests
{
  public class EngineCtorTests
  {
    private readonly ILogger _Logger;

    public EngineCtorTests()
    {
      var loggerFactory = LoggerFactory.Create(config =>
      {
        config.AddProvider(new NUnitLoggerProvider())
          .SetMinimumLevel(LogLevel.Trace);
      });
      _Logger = loggerFactory.CreateLogger<EngineCtorTests>();
    }


    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EngineCtorIsOfTypeEngine()
    {
      var engine = new Engine();
      Assert.That(engine, Is.TypeOf(typeof(Engine)));
      Assert.That(engine.Logger, Is.Not.Null);
      Assert.That(engine.Logger, Is.TypeOf(typeof(NullLogger)));

    }

    [Test]
    public void EngineCtorHandlesOptionalLogger()
    {
      var engine = new Engine(_Logger);
      Assert.That(engine, Is.TypeOf(typeof(Engine)));
      Assert.That(engine.Logger, Is.Not.Null);
      Assert.That(engine.Logger, Is.TypeOf(typeof(Logger<EngineCtorTests>)));
    }

    [Test]
    public void EngineCtorHandlesOptionalLoggerWhenSetAfterCtor()
    {
      var engine = new Engine()
      {
        Logger = _Logger
      };
      Assert.That(engine, Is.TypeOf(typeof(Engine)));
      Assert.That(engine.Logger, Is.Not.Null);
      Assert.That(engine.Logger, Is.TypeOf(typeof(Logger<EngineCtorTests>)));
    }
  }
}