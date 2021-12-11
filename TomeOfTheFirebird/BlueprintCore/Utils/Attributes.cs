using System;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Identifies which game type is implemented by the method.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public class ImplementsAttribute : Attribute
  {
#pragma warning disable IDE0060 // Remove unused parameter
    public ImplementsAttribute(Type type) { }
#pragma warning restore IDE0060 // Remove unused parameter
  }

  /// <summary>
  /// Identifies which blueprint type is configured by the class.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class ConfiguresAttribute : Attribute
  {
#pragma warning disable IDE0060 // Remove unused parameter
    public ConfiguresAttribute(Type type) { }
#pragma warning restore IDE0060 // Remove unused parameter
  }

  /// <summary>
  /// Identifies automatically generated classes and methods.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
  public class GeneratedAttribute : Attribute { }
}
