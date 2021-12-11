using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Validation;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.ElementsSystem;

#nullable enable
namespace BlueprintCore.Utils
{
  /// <summary>
  /// Validates the configuration of objects.
  /// </summary>
  /// 
  /// <remarks>
  /// Any API implemented in BlueprintCore calls this for all relevant object types. If you instantiate objects outside
  /// of BlueprintCore you can call <see cref="Check"/> to get validation warnings.
  /// </remarks>
  public static class Validator
  {
    private static readonly ValidationContext Context = new();

    /// <summary>Checks the object and returns a list of validation warnings</summary>
    /// 
    /// <remarks>
    /// Uses a combination of Wrath validation logic and custom logic validating that implicit object constraints are
    /// met. The exact validation run varies by type.
    /// <list type="bullet">
    /// <item>
    ///   <term>All Objects</term>
    ///   <description><see cref="ValidationContext.ValidateFieldAttributes(object, string)"/></description>
    /// </item>
    /// <item>
    ///   <term><see cref="Element"/> types</term>
    ///   <description>Verifies that <see cref="Element.name"/> is set.</description>
    /// </item>
    /// <item>
    ///   <term><see cref="BlueprintComponent"/> types</term>
    ///   <description><see cref="BlueprintComponent.ApplyValidation(ValidationContext)"/></description>
    /// </item>
    /// <item>
    ///   <term><see cref="IValidated"/> types</term>
    ///   <description><see cref="IValidated.Validate"/></description>
    /// </item>
    /// </list>
    /// There are some special cases as well, such as <see cref="DealStatDamage"/>.
    /// </remarks>
    public static List<string> Check(object? obj)
    {
      List<string> errors = new();
      if (obj == null) { return errors; }

      var name = obj is Element element ? element.name : obj.GetType().ToString();
      Check(obj, name);

      if (obj is Element && string.IsNullOrEmpty(name))
      {
        errors.Add(
            $"Element name missing: {obj.GetType()}. Create using ElementTool.Create().");
      }
      else if (obj is BlueprintComponent component) { component.ApplyValidation(Context); }

      errors.AddRange(Context.Errors);
      Context.Clear();
      return errors;
    }

    private static void Check(object obj, string name)
    {
      Context.ValidateFieldAttributes(obj, name);

      if (obj is IValidated validated)
      {
        validated.Validate(Context, name ?? obj.GetType().ToString());
      }
      else if (obj is DealStatDamage damage)
      {
        // DealStatDamage implements Validate but not IValidated
        damage.Validate(Context, name ?? obj.GetType().ToString());
      }
    }
  }
}