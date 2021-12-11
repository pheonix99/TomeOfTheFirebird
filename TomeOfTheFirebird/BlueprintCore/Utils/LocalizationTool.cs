using Kingmaker.Localization;
using System.Collections.Generic;
using System;

#nullable enable
namespace BlueprintCore.Utils
{
  // TODO: Improve this tool. Consider using TTT's localization.

  /// <summary>
  /// Utilities for working with <see cref="LocalizedString"/>.
  /// </summary>
  /// 
  /// <remarks>Based on code from <see href="https://github.com/Vek17/WrathMods-TabletopTweaks"/>TabletopTweaks</remarks>
  public class LocalizationTool
  {
    private static readonly LogWrapper Logger = LogWrapper.GetInternal("LocalizationTool");
    private static readonly Dictionary<string, LocalString> keyToLocalString = new();

    /// <summary>
    /// Creates a localized string with the provided key and value.
    /// </summary>
    public static LocalizedString CreateString(string key, string value)
    {
      if (keyToLocalString.ContainsKey(key))
      {
        var localString = keyToLocalString[key];
        if (!localString.Value.Equals(value))
        {
          throw new InvalidOperationException($"String with key {key} already exists with a different value.");
        }
        return localString.KmLocalString;
      }

      var localizedString = new LocalizedString() { m_Key = key };
      var stringsPack = LocalizationManager.CurrentPack.Strings;
      if (stringsPack.ContainsKey(key))
      {
        if (stringsPack[key].Equals(value))
        {
          Logger.Info($"Localized string already exists with key {key} and matching value.");
        }
        else
        {
          throw new InvalidOperationException($"String with key {key} already exists with a different value.");
        }
      }
      else
      {
        stringsPack.Add(key, value);
      }

      keyToLocalString.Add(key, new(localizedString, value));
      return localizedString;
    }

    /// <summary>
    /// Returns a localized string for the provided key. You must create the string using
    /// <see cref="CreateString(string, string)"/> before calling this.
    /// </summary>
    public static LocalizedString GetString(string key)
    {
      if (keyToLocalString.ContainsKey(key))
      {
        return keyToLocalString[key].KmLocalString;
      }
      throw new InvalidOperationException($"No string exists with key {key}");
    }

    private class LocalString
    {
      public readonly LocalizedString KmLocalString;
      public readonly string Value;

      public LocalString(LocalizedString kmLocalString, string value)
      {
        KmLocalString = kmLocalString;
        Value = value;
      }
    }
  }
}
