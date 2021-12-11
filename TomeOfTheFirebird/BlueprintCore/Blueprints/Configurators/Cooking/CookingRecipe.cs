using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Controllers.Rest.Cooking;
using Kingmaker.Localization;
using System.Linq;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators.Cooking
{
  /// <summary>
  /// Configurator for <see cref="BlueprintCookingRecipe"/>.
  /// </summary>
  /// <inheritdoc/>
  [Configures(typeof(BlueprintCookingRecipe))]
  public class CookingRecipeConfigurator : BaseBlueprintConfigurator<BlueprintCookingRecipe, CookingRecipeConfigurator>
  {
    private CookingRecipeConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static CookingRecipeConfigurator For(string name)
    {
      return new CookingRecipeConfigurator(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static CookingRecipeConfigurator New(string name, string guid)
    {
      BlueprintTool.Create<BlueprintCookingRecipe>(name, guid);
      return For(name);
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.Name"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetName(LocalizedString? name)
    {
      ValidateParam(name);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Name = name ?? Constants.Empty.String;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetIngredients(BlueprintCookingRecipe.ItemEntry[]? ingredients)
    {
      ValidateParam(ingredients);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = ingredients;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCookingRecipe.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator AddToIngredients(params BlueprintCookingRecipe.ItemEntry[] ingredients)
    {
      ValidateParam(ingredients);
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = CommonTool.Append(bp.Ingredients, ingredients ?? new BlueprintCookingRecipe.ItemEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCookingRecipe.Ingredients"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator RemoveFromIngredients(params BlueprintCookingRecipe.ItemEntry[] ingredients)
    {
      ValidateParam(ingredients);
      return OnConfigureInternal(
          bp =>
          {
            bp.Ingredients = bp.Ingredients.Where(item => !ingredients.Contains(item)).ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.CookingDC"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetCookingDC(int cookingDC)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.CookingDC = cookingDC;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.BuffDurationHours"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetBuffDurationHours(int buffDurationHours)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.BuffDurationHours = buffDurationHours;
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="partyBuffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public CookingRecipeConfigurator SetPartyBuffs(string[]? partyBuffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PartyBuffs = partyBuffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray();
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="partyBuffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public CookingRecipeConfigurator AddToPartyBuffs(params string[] partyBuffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            bp.m_PartyBuffs = CommonTool.Append(bp.m_PartyBuffs, partyBuffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name)).ToArray());
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCookingRecipe.m_PartyBuffs"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="partyBuffs"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    public CookingRecipeConfigurator RemoveFromPartyBuffs(params string[] partyBuffs)
    {
      return OnConfigureInternal(
          bp =>
          {
            var excludeRefs = partyBuffs.Select(name => BlueprintTool.GetRef<BlueprintBuffReference>(name));
            bp.m_PartyBuffs =
                bp.m_PartyBuffs
                    .Where(
                        bpRef => !excludeRefs.ToList().Exists(exclude => bpRef.deserializedGuid == exclude.deserializedGuid))
                    .ToArray();
          });
    }

    /// <summary>
    /// Sets <see cref="BlueprintCookingRecipe.UnitBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator SetUnitBuffs(BlueprintCookingRecipe.UnitBuffEntry[]? unitBuffs)
    {
      ValidateParam(unitBuffs);
    
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitBuffs = unitBuffs;
          });
    }

    /// <summary>
    /// Adds to <see cref="BlueprintCookingRecipe.UnitBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator AddToUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] unitBuffs)
    {
      ValidateParam(unitBuffs);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitBuffs = CommonTool.Append(bp.UnitBuffs, unitBuffs ?? new BlueprintCookingRecipe.UnitBuffEntry[0]);
          });
    }

    /// <summary>
    /// Removes from <see cref="BlueprintCookingRecipe.UnitBuffs"/> (Auto Generated)
    /// </summary>
    [Generated]
    public CookingRecipeConfigurator RemoveFromUnitBuffs(params BlueprintCookingRecipe.UnitBuffEntry[] unitBuffs)
    {
      ValidateParam(unitBuffs);
      return OnConfigureInternal(
          bp =>
          {
            bp.UnitBuffs = bp.UnitBuffs.Where(item => !unitBuffs.Contains(item)).ToArray();
          });
    }
  }
}
