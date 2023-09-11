﻿using System.Globalization;
using System.Text;
using Microsoft.Extensions.Logging;

namespace SudokuSolver.Engine.Unit.Tests.Loggers;

public class NUnitLogger : ILogger
{
  private static readonly string[] NewLineChars = new[] { Environment.NewLine };
  private readonly string _Category;
  private readonly LogLevel _MinLogLevel;
  private readonly DateTimeOffset? _LogStart;

  public NUnitLogger(string category, LogLevel minLogLevel, DateTimeOffset? logStart)
  {
    _MinLogLevel = minLogLevel;
    _Category = category;
    _LogStart = logStart;
  }

  public void Log<TState>(
    LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
  {
    if (!IsEnabled(logLevel))
    {
      return;
    }

    // Buffer the message into a single string in order to avoid shearing the message when running across multiple threads.
    var messageBuilder = new StringBuilder();

    var timestamp = _LogStart.HasValue ?
      $"{(DateTimeOffset.UtcNow - _LogStart.Value).TotalSeconds.ToString("N3", CultureInfo.InvariantCulture)}s" :
      DateTimeOffset.UtcNow.ToString("s", CultureInfo.InvariantCulture);

    var firstLinePrefix = $"| [{timestamp}] {_Category} {logLevel}: ";
    var lines = formatter(state, arg2: exception).Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
    messageBuilder.AppendLine(firstLinePrefix + lines.FirstOrDefault() ?? string.Empty);

    var additionalLinePrefix = "|" + new string(' ', firstLinePrefix.Length - 1);
    foreach (var line in lines.Skip(1))
    {
      messageBuilder.AppendLine(additionalLinePrefix + line);
    }

    if (exception != null)
    {
      lines = exception.ToString().Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
      additionalLinePrefix = "| ";
      foreach (var line in lines)
      {
        messageBuilder.AppendLine(additionalLinePrefix + line);
      }
    }

    // Remove the last line-break, because ITestOutputHelper only has WriteLine.
    var message = messageBuilder.ToString();
    if (message.EndsWith(Environment.NewLine, StringComparison.Ordinal))
    {
      message = message[..^Environment.NewLine.Length];
    }

    try
    {
      TestContext.WriteLine(message);
    }
    catch (Exception)
    {
      // We could fail because we're on a background thread and our captured ITestOutputHelper is
      // busted (if the test "completed" before the background thread fired).
      // So, ignore this. There isn't really anything we can do but hope the
      // caller has additional loggers registered
    }
  }

  public bool IsEnabled(LogLevel logLevel)
    => logLevel >= _MinLogLevel;

  public IDisposable BeginScope<TState>(TState state)
    => new NullScope();

  private class NullScope : IDisposable
  {
    public void Dispose()
    {
    }
  }
}