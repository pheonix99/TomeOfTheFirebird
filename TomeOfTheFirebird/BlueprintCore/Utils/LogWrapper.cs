using System;
using System.Collections.Generic;
using Owlcat.Runtime.Core.Logging;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Wrapper around <see cref="LogChannel"/> which supports dynamically enabling or disabling verbose logging.
  /// </summary>
  /// 
  /// <remarks>
  /// These log events print to the same output as Wrath's game log events using the Mods channel. They can be viewed
  /// using <see href="https://github.com/OwlcatOpenSource/RemoteConsole/releases">RemoteConsole</see> or by appending
  /// <c>logging</c> to the executable startup arguments and reading
  /// <c>AppData\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLog*.txt</c>.
  /// </remarks>
  /// 
  /// <remarks>
  /// BlueprintCore internal logs are prefixed with "BlueprintCore.AssemblyName".
  /// </remarks>
  public class LogWrapper
  {
    /// <summary>
    /// Controls whether calls to <see cref="Verbose(string)"/> are logged. Defaults to false.
    /// </summary>
    /// 
    /// <remarks>
    /// Set this to true while developing or debugging. Consider making this a setting in your modification so users can
    /// capture detailed logs when reporting a problem.
    /// </remarks>
    public bool EnableVerboseLogs = false;


    /// <summary>
    /// Call this if you want verbose internal logs for BlueprintCore. Recommended before filing a bug report, as I may
    /// need to see those logs.
    /// </summary>
    public static void EnableInternalVerboseLogs(bool enable = true)
    {
      InternalLogWrappers.ForEach(logger => logger.EnableVerboseLogs = enable);
    }

    internal static string PrefixRoot = $"BlueprintCore";
    internal static List<LogWrapper> InternalLogWrappers = new();

    internal static LogWrapper GetInternal(string prefix)
    {
      var logWrapper = Get($"{PrefixRoot}.{prefix}");
      InternalLogWrappers.Add(logWrapper);
      return logWrapper;
    }

    /// <summary>
    /// Returns a <see cref="LogWrapper"/> which appends the prefix to all log events.
    /// </summary>
    /// 
    /// <remarks>Uses the Mods logging channel which can be viewed in RemoteConsole.</remarks>
    /// 
    /// <remarks>Output is in %APPDATA%\..\LocalLow\Owlcat Games\Pathfinder Wrath Of The Righteous\GameLogFull.txt</remarks>
    public static LogWrapper Get(string prefix)
    {
      LogChannel logChannel = LogChannelFactory.GetOrCreate("Mods");
      logChannel.SetSeverity(LogSeverity.Message);
      return new LogWrapper(logChannel, prefix);
    }

    private readonly LogChannel Logger;
    private readonly string Prefix;

    protected LogWrapper(LogChannel logger, string prefix)
    {
      Logger = logger;
      Prefix = prefix;
    }

    /// <summary>
    /// Logs an error with a stack trace as well as an exception, if provided.
    /// </summary>
    public virtual void Error(string msg, Exception? e = null)
    {
      Logger.Error($"{Prefix}: {msg}");
      if (e != null) { Logger.Exception(e); }
    }
    
    public virtual void Info(string msg)
    {
      Logger.Log($"{Prefix}: {msg}");
    }

    /// <summary>
    /// Logs a warning with a stack trace.
    /// </summary>
    public virtual void Warn(string msg)
    {
      Logger.Warning($"{Prefix}: {msg}");
    }

    /// <summary>
    /// If <see cref="EnableVerboseLogs"/> is false these log are ignored.
    /// </summary>
    public virtual void Verbose(string msg)
    {
      if (EnableVerboseLogs) { Logger.Log($"{Prefix}: {msg}"); }
    }
  }
}