using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Utils;
using Kingmaker.AreaLogic.Etudes;
using Kingmaker.Armies.Blueprints;
using Kingmaker.Armies.Components;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Validation;
using Kingmaker.Controllers.Rest;
using Kingmaker.Corruption;
using Kingmaker.Designers.EventConditionActionSystem.Events;
using Kingmaker.Designers.Mechanics.Enums;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.DLC;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.Globalmap.Blueprints;
using Kingmaker.Kingdom.Armies;
using Kingmaker.Kingdom.Blueprints;
using Kingmaker.Kingdom.Buffs;
using Kingmaker.Kingdom.Flags;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.UnitLogic.Mechanics.Properties;
using Kingmaker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable enable
namespace BlueprintCore.Blueprints.Configurators
{
  /// <summary>Fluent API for creating and modifying blueprints.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Implementation is done using the
  /// <see href="https://en.wikipedia.org/wiki/Curiously_recurring_template_pattern">Curiously Recurring Template Pattern</see>.
  /// </para>
  /// 
  /// <list type="table">
  /// <listheader>Key Features</listheader>
  /// <item>
  ///   <term>Blueprint Creation</term>
  ///   <description>
  ///     Each configurator provides a function to create a new blueprint and register it in the game library.
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Component Type Safety</term>
  ///   <description>
  ///     <para>
  ///     Blueprints are very permissive; any <see cref="BlueprintComponent"/> can be added to any blueprint type. In
  ///     reality many component types are only functional on certain types of blueprints, defined using attributes.
  ///     </para>
  ///     <para>
  ///     The configurator API mimics the inheritance structure of blueprint types in the game to restrict the available
  ///     types of components. The API does not perfectly implement these restrictions because inheritance cannot
  ///     represent the restrictions completely. In those cases type safety is provided through validation.
  ///     </para>
  ///     <para>
  ///     See <see href="https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/%5BWrath%5D-Blueprints">Wrath Blueprints</see>
  ///     for more information on component and blueprint type safety.
  ///     </para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Validation</term>
  ///   <description>
  ///     <para>
  ///     When <see cref="Configure"/> is called a combination of Owlcat provided and custom validation logic checks the
  ///     blueprint for errors. All errors are then logged. This validates the blueprint only contains supported
  ///     component types as well as checking for some implicit usage errors, such as
  ///     <see href="https://github.com/TylerGoeringer/OwlcatModdingWiki/wiki/[Wrath]-Abilities">AbilityEffects</see>
  ///     usage.
  ///     </para>
  ///     <para>See <see cref="Validator"/> for more details on how validation works.</para>
  ///   </description>
  /// </item>
  /// <item>
  ///   <term>Fluent API</term>
  ///   <description>
  ///     <para>
  ///     The API is designed to minimize boilerplate required to modify blueprints and create components. Configurators
  ///     work with the <see cref="ActionsBuilder"/> and
  ///     <see cref="Conditions.Builder.ConditionsBuilder">ConditionsBuilder</see> APIs as well.
  ///     </para>
  ///     <para>
  ///     Complicated components such as
  ///     <see cref="Kingmaker.UnitLogic.Mechanics.Components.ContextRankConfig">ContextRankConfig</see> which do not
  ///     work well with the configurator API have their own helper classes.
  ///     e.g. <see cref="Components.ContextRankConfigs">ContextRankConfigs</see>
  ///     </para>
  ///   </description>
  /// </item>
  /// </list>
  /// 
  /// <example>
  /// Add the Skald's Vigor and Greater Skald's Vigor feats (minus UI icons):
  /// <code>
  /// var skaldClass = "WW-SkaldClass";
  /// var inspiredRageFeature = "WW-InspiredRageFeature";
  /// var inspiredRageBuff = "WW-InspiredRageBuff";
  /// var skaldsVigorBuff = "WW-SkaldsVigorBuff";
  /// var skaldsVigorFeat = "WW-SkaldsVigorFeat";
  /// var greaterSkaldsVigorFeat = "WW-GreaterSkaldsVigorFeat";
  ///   
  /// // Register the names
  /// BlueprintTool.AddGuidsByName(
  ///     (skaldClass, "6afa347d804838b48bda16acb0573dc0"),
  ///     (inspiredRageFeature, "1a639eadc2c3ed546bc4bb236864cd0c"),
  ///     (inspiredRageBuff, "75b3978757908d24aaaecaf2dc209b89"),
  ///     // New blueprints and guids
  ///     (skaldsVigorBuff, "35fa838eb545491fbe73d593a3c456ed"),
  ///     (skaldsVigorFeat, "59f825ec85744ac29e7d49201561638d"),
  ///     (greaterSkaldsVigorFeat, "b97fa348973a4c5a916d78e9ed029e1f"));
  ///  
  /// // Load the icons and strings (not provided by library)
  /// var skaldsVigorIcon = LoadSkaldsVigorIcon();
  /// var greaterSkaldsVigorIcon = LoadGreaterSkaldsVigorIcon();
  /// var skaldsVigorName = LoadSkaldsVigorName();
  /// var greaterSkaldsVigorName = LoadGreaterSkaldsVigorName();
  /// var skaldsVigorDescription = LoadSkaldsVigorDescription();
  /// var greaterSkaldsVigorDescription = LoadGreaterSkaldsVigorDescription();
  /// 
  /// // Create the buff
  /// BuffConfigurator.New(skaldsVigorBuff)
  ///     .ContextRankConfig(
  ///         // Sets a context rank value to 1 + 2 * (SkaldLevels / 8).
  ///         ContextRankConfigs.ClassLevel(new string[] { skaldClass }).DivideByThenDoubleThenAdd1(8))
  ///     // Adds fast healing to the buff. The base value is 1 and the context rank value is added. Before level 8
  ///     // it provides 2; at level 8 it increases to 4; at level 16 it increases to 6.
  ///     .FastHealing(1, bonusValue: ContextValues.Rank())
  ///     .Configure();
  ///   
  /// // Creates an action to apply the buff. Permanent duration is used because it stays active as long as Inspired
  /// // Rage is active.
  /// var applyBuff = ActionsBuilder.New().ApplyBuff(skaldsVigorBuff, permanent: true, dispellable: false);
  /// BuffConfigurator.For(inspiredRageBuff)
  ///     .FactContextActions(
  ///         onActivated:
  ///             ActionsBuilder.New()
  ///                 // When the Inspired Rage buff is applied to the caster, Skald's Vigor is applied if they have
  ///                 // the feat.
  ///                 .Conditional(
  ///                     ConditionsBuilder.New().TargetIsYourself().HasFact(skaldsVigorFeat),
  ///                     ifTrue: applyBuff)
  ///                 // For characters other than the caster, Skald's Vigor is only applied if the caster has the
  ///                 // greater feat. Note: Technically this will apply the buff to the caster twice, but by default
  ///                 // buffs do not stack so it has no effect.
  ///                 .Conditional(
  ///                     ConditionsBuilder.New().CasterHasFact(greaterSkaldsVigorFeat), ifTrue: applyBuff),
  ///         onDeactivated:
  ///             // Removes Skald's Vigor when Inspired Rage ends.
  ///             // There is actually a bug with this implementation; Lingering Song will extend the duration of
  ///             // Skald's Vigor when it should not. The fix for this is beyond the scope of this example.
  ///             ActionsBuilder.New().RemoveBuff(skaldsVigorBuff))
  ///     .Configure();
  /// </code>
  /// </example>
  /// </remarks>
  [Configures(typeof(BlueprintScriptableObject))]
  public abstract class BaseBlueprintConfigurator<T, TBuilder>
      where T : BlueprintScriptableObject
      where TBuilder : BaseBlueprintConfigurator<T, TBuilder>
  {
    /// <summary>Describes how to resolve conflicts when multiple unique components are added to a blueprint.</summary>
    /// 
    /// <remarks>
    /// When adding a component that is unique, the function accepts a <see cref="ComponentMerge"/> and
    /// <see cref="Action"/> argument to resolve the conflict. Whenever possible, a reasonable default behavior is
    /// provided. Usually this is in the form of concatenating two components that represent lists or combining flags.
    /// </remarks>
    public enum ComponentMerge
    {
      /// <summary>Default. Throws an exception.</summary>
      Fail = 0,
      /// <summary>Skips the new component. Useful for components without per-instance behavior.</summary>
      Skip,
      /// <summary>The new component is used and the existing component is removed.</summary>
      Replace,
      /// <summary>The two components are merged into one. Requires an <see cref="Action"/> to define merge behavior.</summary>
      Merge
    }

    protected static readonly LogWrapper Logger = LogWrapper.GetInternal("BlueprintConfigurator");

    private readonly List<BlueprintComponent> Components = new();
    private readonly HashSet<UniqueComponent> UniqueComponents = new();
    private readonly List<BlueprintComponent> ComponentsToRemove = new();
    private readonly List<Action<T>> InternalOnConfigure = new();
    private readonly List<Action<T>> ExternalOnConfigure = new();
    private readonly ValidationContext Context = new();

    private bool Configured = false;
    private readonly StringBuilder ValidationWarnings = new();

    protected readonly TBuilder Self;
    protected readonly string Name;
    protected readonly T Blueprint;

    protected BaseBlueprintConfigurator(string name)
    {
      Self = (TBuilder)this;
      Name = name;
      Blueprint = BlueprintTool.Get<T>(name);
    }

    /// <summary>Commits the configuration changes to the blueprint.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// After commiting the changes the blueprint is validated and any errors are logged as a warning.
    /// </para>
    /// Throws <see cref="InvalidOperationException"/> if called twice on the same configurator.
    /// </remarks>
    public T Configure()
    {
      if (Configured)
      {
        throw new InvalidOperationException($"{Name} has already been configured.");
      }

      Configured = true;
      Logger.Verbose($"Configuring {Name}.");
      ConfigureInternal();

      ConfigureComponents();
      OnConfigure();
      Blueprint.OnEnable();

      Logger.Verbose($"Validating configuration for {Name}.");
      ValidateBase();
      ValidateInternal();

      if (ValidationWarnings.Length > 0)
      {
        ValidationWarnings.Insert(
            /* index= */ 0,
            $"{Name} - {typeof(T)} has warnings:{Environment.NewLine}");
        Logger.Warn(ValidationWarnings.ToString());
      }
      return Blueprint;
    }

    /// <summary>Adds the specified <see cref="BlueprintComponent"/> to the blueprint.</summary>
    /// 
    /// <remarks>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </remarks>
    public TBuilder AddComponent(BlueprintComponent component)
    {
      Components.Add(component);
      return Self;
    }

    /// <summary>
    /// Adds a <see cref="BlueprintComponent"/> of the specified type to the blueprint.
    /// </summary>
    /// 
    /// <remarks>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </remarks>
    /// 
    /// <param name="init">Optional initialization <see cref="Action"/> run on the component.</param>
    public TBuilder AddComponent<C>(Action<C> init) where C : BlueprintComponent, new()
    {
      var component = new C();
      init?.Invoke(component);
      return AddComponent(component);
    }

    /// <summary>
    /// Edits the first <see cref="BlueprintComponent"/> of the specified type in the blueprint.
    /// </summary>
    /// 
    /// <param name="edit">Action invoked with the component as an input argument. Run when <see cref="Configure"/> is called.</param>
    public TBuilder EditComponent<C>(Action<C> edit) where C : BlueprintComponent
    {
      return OnConfigureInternal(
          bp =>
          {
            var component = bp.GetComponent<C>();
            if (component is not null) { edit.Invoke(component); }
          });
    }

    /// <summary>Executes the specified actions when <see cref="Configure"/> is called.</summary>
    /// 
    /// <remarks>
    /// Runs as the last step of configuration, after all components are added and all other changes are applied.
    /// </remarks>
    public TBuilder OnConfigure(params Action<T>[] actions)
    {
      ExternalOnConfigure.AddRange(actions);
      return Self;
    }

    /// <summary>Internal function comparable to <see cref="OnConfigure(Action{T}[])"/>.</summary>
    /// 
    /// <remarks>
    /// Runs after all configuration is done but before <see cref="OnConfigure(Action{T}[])"/>. Configurator functions
    /// should use this to ensure the blueprint is configured before user configuration actions are run.
    /// </remarks>
    protected TBuilder OnConfigureInternal(params Action<T>[] actions)
    {
      InternalOnConfigure.AddRange(actions);
      return Self;
    }

    /// <summary>Adds the specified <see cref="BlueprintComponent"/> to the blueprint with merge handling.</summary>
    /// 
    /// <remarks>
    /// <para>
    /// It is recommended to only call this from within a configurator class or when adding a component type not
    /// supported by the configurator.
    /// </para>
    /// <para>
    /// Use this for types without the <see cref="AllowMultipleComponentsAttribute"/>.
    /// </para>
    /// </remarks>
    public TBuilder AddUniqueComponent(
        BlueprintComponent component,
        ComponentMerge behavior = ComponentMerge.Fail,
        Action<BlueprintComponent, BlueprintComponent>? merge = null)
    {
      UniqueComponents.Add(new UniqueComponent(component, behavior, merge));
      return Self;
    }

    /// <summary>Removed components from the blueprint matching the specified predicate.</summary>
    /// 
    /// <remarks>Has no effect on components added with the configurator.</remarks>
    public TBuilder RemoveComponents(Func<BlueprintComponent, bool> predicate)
    {
      ComponentsToRemove.AddRange(Blueprint.Components.Where(predicate));
      return Self;
    }


    /// <summary>
    /// Adds <see cref="DlcCondition"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="dlcReward"><see cref="Kingmaker.DLC.BlueprintDlcReward"/></param>
    [Generated]
    [Implements(typeof(DlcCondition))]
    public TBuilder AddDlcCondition(
        string? dlcReward = null,
        bool hideInstead = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcCondition();
      component.m_DlcReward = BlueprintTool.GetRef<BlueprintDlcRewardReference>(dlcReward);
      component.m_HideInstead = hideInstead;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreCheat"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreCheat))]
    public TBuilder AddDlcStoreCheat(
        bool isAvailableInEditor = default,
        bool isAvailableInDevBuild = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreCheat();
      component.m_IsAvailableInEditor = isAvailableInEditor;
      component.m_IsAvailableInDevBuild = isAvailableInDevBuild;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreEpic"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreEpic))]
    public TBuilder AddDlcStoreEpic(
        string epicId,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreEpic();
      component.m_EpicId = epicId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreGog"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreGog))]
    public TBuilder AddDlcStoreGog(
        ulong gogId = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreGog();
      component.m_GogId = gogId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="DlcStoreSteam"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DlcStoreSteam))]
    public TBuilder AddDlcStoreSteam(
        uint steamId = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new DlcStoreSteam();
      component.m_SteamId = steamId;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddBuffOnCorruptionClear"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="buff"><see cref="Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff"/></param>
    [Generated]
    [Implements(typeof(AddBuffOnCorruptionClear))]
    public TBuilder AddBuffOnCorruptionClear(
        string? buff = null,
        int targetBuffRank = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddBuffOnCorruptionClear();
      component.m_Buff = BlueprintTool.GetRef<BlueprintBuffReference>(buff);
      component.m_TargetBuffRank = targetBuffRank;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddPlayerLeaveCombatTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddPlayerLeaveCombatTrigger))]
    public TBuilder AddPlayerLeaveCombatTrigger(
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddPlayerLeaveCombatTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ReplaceDamageDice"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(ReplaceDamageDice))]
    public TBuilder AddReplaceDamageDice(
        string? weaponType = null,
        ReplaceDamageDice.Progression[]? progressions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(progressions);
    
      var component = new ReplaceDamageDice();
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.Progressions = progressions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnitPropertyComponent"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UnitPropertyComponent))]
    public TBuilder AddUnitPropertyComponent(
        string name,
        PropertySettings settings,
        int baseValue = default,
        UnitPropertyComponent.ExternalProperty[]? addExternalProperties = null,
        string[]? addLocalProperties = null)
    {
      ValidateParam(settings);
      ValidateParam(addExternalProperties);
    
      var component = new UnitPropertyComponent();
      component.Name = name;
      component.m_Settings = settings;
      component.m_BaseValue = baseValue;
      component.m_AddExternalProperties = addExternalProperties;
      component.m_AddLocalProperties = addLocalProperties;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddInitiatorAttackRollTrigger))]
    public TBuilder AddInitiatorAttackRollTrigger(
        bool onlyHit = default,
        bool criticalHit = default,
        bool sneakAttack = default,
        bool onOwner = default,
        bool checkWeapon = default,
        WeaponCategory weaponCategory = default,
        bool affectFriendlyTouchSpells = default,
        ActionsBuilder? action = null)
    {
      var component = new AddInitiatorAttackRollTrigger();
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.SneakAttack = sneakAttack;
      component.OnOwner = onOwner;
      component.CheckWeapon = checkWeapon;
      component.WeaponCategory = weaponCategory;
      component.AffectFriendlyTouchSpells = affectFriendlyTouchSpells;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddInitiatorAttackWithWeaponTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AddInitiatorAttackWithWeaponTrigger))]
    public TBuilder AddInitiatorAttackWithWeaponTrigger(
        Feet distanceLessEqual,
        bool waitForAttackResolve = default,
        bool onlyHit = default,
        bool onMiss = default,
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool onlyOnFirstHit = default,
        bool criticalHit = default,
        bool onAttackOfOpportunity = default,
        bool notCriticalHit = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        string? weaponType = null,
        bool checkWeaponCategory = default,
        WeaponCategory category = default,
        bool checkWeaponGroup = default,
        WeaponFighterGroup group = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType rangeType = default,
        bool actionsOnInitiator = default,
        bool reduceHPToZero = default,
        bool damageMoreTargetMaxHP = default,
        bool checkDistance = default,
        bool allNaturalAndUnarmed = default,
        bool duelistWeapon = default,
        bool notExtraAttack = default,
        bool onCharge = default,
        bool ignoreAutoHit = default,
        ActionsBuilder? action = null)
    {
      var component = new AddInitiatorAttackWithWeaponTrigger();
      component.WaitForAttackResolve = waitForAttackResolve;
      component.OnlyHit = onlyHit;
      component.OnMiss = onMiss;
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.OnlyOnFirstHit = onlyOnFirstHit;
      component.CriticalHit = criticalHit;
      component.OnAttackOfOpportunity = onAttackOfOpportunity;
      component.NotCriticalHit = notCriticalHit;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckWeaponCategory = checkWeaponCategory;
      component.Category = category;
      component.CheckWeaponGroup = checkWeaponGroup;
      component.Group = group;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.RangeType = rangeType;
      component.ActionsOnInitiator = actionsOnInitiator;
      component.ReduceHPToZero = reduceHPToZero;
      component.DamageMoreTargetMaxHP = damageMoreTargetMaxHP;
      component.CheckDistance = checkDistance;
      component.DistanceLessEqual = distanceLessEqual;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.DuelistWeapon = duelistWeapon;
      component.NotExtraAttack = notExtraAttack;
      component.OnCharge = onCharge;
      component.IgnoreAutoHit = ignoreAutoHit;
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AddTargetAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetAttackRollTrigger))]
    public TBuilder AddTargetAttackRollTrigger(
        bool onlyHit = default,
        bool criticalHit = default,
        bool onlyMelee = default,
        bool notReach = default,
        bool checkCategory = default,
        bool not = default,
        WeaponCategory[]? categories = null,
        bool affectFriendlyTouchSpells = default,
        ActionsBuilder? actionsOnAttacker = null,
        ActionsBuilder? actionOnSelf = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddTargetAttackRollTrigger();
      component.OnlyHit = onlyHit;
      component.CriticalHit = criticalHit;
      component.OnlyMelee = onlyMelee;
      component.NotReach = notReach;
      component.CheckCategory = checkCategory;
      component.Not = not;
      component.Categories = categories;
      component.AffectFriendlyTouchSpells = affectFriendlyTouchSpells;
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? Constants.Empty.Actions;
      component.ActionOnSelf = actionOnSelf?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AddTargetBeforeAttackRollTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AddTargetBeforeAttackRollTrigger))]
    public TBuilder AddTargetBeforeAttackRollTrigger(
        SpellDescriptorWrapper spellDescriptors,
        bool onlyMelee = default,
        bool notReach = default,
        bool checkDescriptor = default,
        ActionsBuilder? actionsOnAttacker = null,
        ActionsBuilder? actionOnSelf = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new AddTargetBeforeAttackRollTrigger();
      component.OnlyMelee = onlyMelee;
      component.NotReach = notReach;
      component.CheckDescriptor = checkDescriptor;
      component.SpellDescriptors = spellDescriptors;
      component.ActionsOnAttacker = actionsOnAttacker?.Build() ?? Constants.Empty.Actions;
      component.ActionOnSelf = actionOnSelf?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="AdditionalDiceOnAttack"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="weaponType"><see cref="Kingmaker.Blueprints.Items.Weapons.BlueprintWeaponType"/></param>
    [Generated]
    [Implements(typeof(AdditionalDiceOnAttack))]
    public TBuilder AdditionalDiceOnAttack(
        Feet distanceLessEqual,
        DamageTypeDescription damageType,
        bool onlyOnFullAttack = default,
        bool onlyOnFirstAttack = default,
        bool onHit = default,
        bool onlyOnFirstHit = default,
        bool criticalHit = default,
        bool onAttackOfOpportunity = default,
        bool notCriticalHit = default,
        bool onlySneakAttack = default,
        bool notSneakAttack = default,
        string? weaponType = null,
        bool checkWeaponCategory = default,
        WeaponCategory category = default,
        bool checkWeaponGroup = default,
        WeaponFighterGroup group = default,
        bool checkWeaponRangeType = default,
        WeaponRangeType rangeType = default,
        bool reduceHPToZero = default,
        bool checkDistance = default,
        bool allNaturalAndUnarmed = default,
        bool duelistWeapon = default,
        bool notExtraAttack = default,
        bool onCharge = default,
        ConditionsBuilder? initiatorConditions = null,
        ConditionsBuilder? targetConditions = null,
        bool randomizeDamage = default,
        ContextDiceValue? value = null,
        List<AdditionalDiceOnAttack.DamageEntry>? damageEntries = null)
    {
      ValidateParam(value);
      ValidateParam(damageType);
      ValidateParam(damageEntries);
    
      var component = new AdditionalDiceOnAttack();
      component.OnlyOnFullAttack = onlyOnFullAttack;
      component.OnlyOnFirstAttack = onlyOnFirstAttack;
      component.OnHit = onHit;
      component.OnlyOnFirstHit = onlyOnFirstHit;
      component.CriticalHit = criticalHit;
      component.OnAttackOfOpportunity = onAttackOfOpportunity;
      component.NotCriticalHit = notCriticalHit;
      component.OnlySneakAttack = onlySneakAttack;
      component.NotSneakAttack = notSneakAttack;
      component.m_WeaponType = BlueprintTool.GetRef<BlueprintWeaponTypeReference>(weaponType);
      component.CheckWeaponCategory = checkWeaponCategory;
      component.Category = category;
      component.CheckWeaponGroup = checkWeaponGroup;
      component.Group = group;
      component.CheckWeaponRangeType = checkWeaponRangeType;
      component.RangeType = rangeType;
      component.ReduceHPToZero = reduceHPToZero;
      component.CheckDistance = checkDistance;
      component.DistanceLessEqual = distanceLessEqual;
      component.AllNaturalAndUnarmed = allNaturalAndUnarmed;
      component.DuelistWeapon = duelistWeapon;
      component.NotExtraAttack = notExtraAttack;
      component.OnCharge = onCharge;
      component.InitiatorConditions = initiatorConditions?.Build() ?? Constants.Empty.Conditions;
      component.TargetConditions = targetConditions?.Build() ?? Constants.Empty.Conditions;
      component.m_RandomizeDamage = randomizeDamage;
      component.Value = value ?? Constants.Empty.DiceValue;
      component.DamageType = damageType;
      component.m_DamageEntries = damageEntries;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AdditionalStatBonusOnAttackDamage"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AdditionalStatBonusOnAttackDamage))]
    public TBuilder AdditionalStatBonusOnAttackDamage(
        ConditionEnum fullAttack = default,
        ConditionEnum firstAttack = default,
        bool checkCategory = default,
        WeaponCategory category = default,
        bool checkTwoHanded = default,
        float bonus = default)
    {
      var component = new AdditionalStatBonusOnAttackDamage();
      component.FullAttack = fullAttack;
      component.FirstAttack = firstAttack;
      component.CheckCategory = checkCategory;
      component.Category = category;
      component.CheckTwoHanded = checkTwoHanded;
      component.Bonus = bonus;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AllAttacksEnhancement"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AllAttacksEnhancement))]
    public TBuilder AddAllAttacksEnhancement(
        int bonus = default,
        ModifierDescriptor descriptor = default)
    {
      var component = new AllAttacksEnhancement();
      component.Bonus = bonus;
      component.Descriptor = descriptor;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="BashingFinish"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(BashingFinish))]
    public TBuilder AddBashingFinish()
    {
      return AddComponent(new BashingFinish());
    }

    /// <summary>
    /// Adds <see cref="DestructiveShockwave"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DestructiveShockwave))]
    public TBuilder AddDestructiveShockwave()
    {
      return AddComponent(new DestructiveShockwave());
    }

    /// <summary>
    /// Adds <see cref="ShieldMaster"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ShieldMaster))]
    public TBuilder AddShieldMaster()
    {
      return AddComponent(new ShieldMaster());
    }

    /// <summary>
    /// Adds <see cref="ArmyBattleResultsTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="demonArmies"><see cref="Kingmaker.Armies.Blueprints.BlueprintArmyPreset"/></param>
    /// <param name="crusadeLeader"><see cref="Kingmaker.Armies.BlueprintArmyLeader"/></param>
    [Generated]
    [Implements(typeof(ArmyBattleResultsTrigger))]
    public TBuilder AddArmyBattleResultsTrigger(
        ActionsBuilder? onCrusadersVictory = null,
        ActionsBuilder? onDemonsVictory = null,
        RegionId assignedRegion = default,
        bool demonsFromList = default,
        string[]? demonArmies = null,
        ArmyType demonsArmyType = default,
        bool specificCrusadeLeader = default,
        string? crusadeLeader = null)
    {
      var component = new ArmyBattleResultsTrigger();
      component.OnCrusadersVictory = onCrusadersVictory?.Build() ?? Constants.Empty.Actions;
      component.OnDemonsVictory = onDemonsVictory?.Build() ?? Constants.Empty.Actions;
      component.m_AssignedRegion = assignedRegion;
      component.m_DemonsFromList = demonsFromList;
      component.m_DemonArmies = demonArmies.Select(name => BlueprintTool.GetRef<BlueprintArmyPresetReference>(name)).ToList();
      component.m_DemonsArmyType = demonsArmyType;
      component.m_SpecificCrusadeLeader = specificCrusadeLeader;
      component.m_CrusadeLeader = BlueprintTool.GetRef<BlueprintArmyLeaderReference>(crusadeLeader);
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="KingdomRegionClaimedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="regions"><see cref="Kingmaker.Kingdom.Blueprints.BlueprintRegion"/></param>
    [Generated]
    [Implements(typeof(KingdomRegionClaimedTrigger))]
    public TBuilder AddKingdomRegionClaimedTrigger(
        string[]? regions = null,
        ActionsBuilder? actions = null)
    {
      var component = new KingdomRegionClaimedTrigger();
      component.m_Regions = regions.Select(name => BlueprintTool.GetRef<BlueprintRegionReference>(name)).ToArray();
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SettlementSiegeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="settlementLocation"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(SettlementSiegeTrigger))]
    public TBuilder AddSettlementSiegeTrigger(
        bool specificLocation = default,
        string? settlementLocation = null,
        ActionsBuilder? onSiegeStart = null,
        ActionsBuilder? onSiegeEnd = null,
        ActionsBuilder? onSettlementDestroyed = null)
    {
      var component = new SettlementSiegeTrigger();
      component.m_SpecificLocation = specificLocation;
      component.m_SettlementLocation = BlueprintTool.GetRef<BlueprintGlobalMapPointReference>(settlementLocation);
      component.m_OnSiegeStart = onSiegeStart?.Build() ?? Constants.Empty.Actions;
      component.m_OnSiegeEnd = onSiegeEnd?.Build() ?? Constants.Empty.Actions;
      component.m_OnSettlementDestroyed = onSettlementDestroyed?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ArmyUnitRecruitedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="armyUnits"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(ArmyUnitRecruitedTrigger))]
    public TBuilder AddArmyUnitRecruitedTrigger(
        MercenariesIncludeOption mercenariesFilter = default,
        bool byTag = default,
        ArmyProperties armyTag = default,
        bool byUnits = default,
        string[]? armyUnits = null,
        int minCount = default,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyUnitRecruitedTrigger();
      component.m_MercenariesFilter = mercenariesFilter;
      component.m_ByTag = byTag;
      component.m_ArmyTag = armyTag;
      component.m_ByUnits = byUnits;
      component.m_ArmyUnits = armyUnits.Select(name => BlueprintTool.GetRef<BlueprintUnitReference>(name)).ToArray();
      component.m_MinCount = minCount;
      component.m_Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="LeaderRecruitedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(LeaderRecruitedTrigger))]
    public TBuilder AddLeaderRecruitedTrigger(
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new LeaderRecruitedTrigger();
      component.m_Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="SummonUnitsAfterArmyBattle"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SummonUnitsAfterArmyBattle))]
    public TBuilder AddSummonUnitsAfterArmyBattle(
        SummonUnitsAfterArmyBattle.SummonGroup[]? groups = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(groups);
    
      var component = new SummonUnitsAfterArmyBattle();
      component.m_Groups = groups;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ArmyAbilityTags"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ArmyAbilityTags))]
    public TBuilder AddArmyAbilityTags(
        ArmyProperties properties = default,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ArmyAbilityTags();
      component.Properties = properties;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="GarrisonDefeatedTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(GarrisonDefeatedTrigger))]
    public TBuilder AddGarrisonDefeatedTrigger(
        string? location = null,
        ActionsBuilder? actions = null)
    {
      var component = new GarrisonDefeatedTrigger();
      component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlayerVisitGlobalMapLocationTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="location"><see cref="Kingmaker.Globalmap.Blueprints.BlueprintGlobalMapPoint"/></param>
    [Generated]
    [Implements(typeof(PlayerVisitGlobalMapLocationTrigger))]
    public TBuilder AddPlayerVisitGlobalMapLocationTrigger(
        string? location = null,
        ActionsBuilder? actions = null)
    {
      var component = new PlayerVisitGlobalMapLocationTrigger();
      component.m_Location = BlueprintTool.GetRef<BlueprintGlobalMapPoint.Reference>(location);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateEnterTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OnIsleStateEnterTrigger))]
    public TBuilder AddOnIsleStateEnterTrigger(
        IsleEvaluator isleEvaluator,
        string targetState,
        ActionsBuilder? actions = null)
    {
      ValidateParam(isleEvaluator);
    
      var component = new OnIsleStateEnterTrigger();
      component.m_IsleEvaluator = isleEvaluator;
      component.m_TargetState = targetState;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="OnIsleStateExitTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(OnIsleStateExitTrigger))]
    public TBuilder AddOnIsleStateExitTrigger(
        IsleEvaluator isleEvaluator,
        string targetState,
        ActionsBuilder? actions = null)
    {
      ValidateParam(isleEvaluator);
    
      var component = new OnIsleStateExitTrigger();
      component.m_IsleEvaluator = isleEvaluator;
      component.m_TargetState = targetState;
      component.m_Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ActivateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ActivateTrigger))]
    public TBuilder AddActivateTrigger(
        bool once = default,
        bool alsoOnAreaLoad = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var component = new ActivateTrigger();
      component.m_Once = once;
      component.m_AlsoOnAreaLoad = alsoOnAreaLoad;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="AreaDidLoadTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(AreaDidLoadTrigger))]
    public TBuilder AddAreaDidLoadTrigger(
        ActionsBuilder? actions = null,
        ConditionsBuilder? conditions = null)
    {
      var component = new AreaDidLoadTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionRecruitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionBlueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionRecruitTrigger))]
    public TBuilder AddCompanionRecruitTrigger(
        string? companionBlueprint = null,
        ActionsBuilder? actions = null)
    {
      var component = new CompanionRecruitTrigger();
      component.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(companionBlueprint);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CompanionUnrecruitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="companionBlueprint"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(CompanionUnrecruitTrigger))]
    public TBuilder AddCompanionUnrecruitTrigger(
        string? companionBlueprint = null,
        bool triggerOnDeath = default,
        ActionsBuilder? actions = null)
    {
      var component = new CompanionUnrecruitTrigger();
      component.m_CompanionBlueprint = BlueprintTool.GetRef<BlueprintUnitReference>(companionBlueprint);
      component.TriggerOnDeath = triggerOnDeath;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="CustomEventTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(CustomEventTrigger))]
    public TBuilder AddCustomEventTrigger(
        string id,
        ActionsBuilder? actions = null)
    {
      var component = new CustomEventTrigger();
      component.Id = id;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DamageTypeTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DamageTypeTrigger))]
    public TBuilder AddDamageTypeTrigger(
        UnitEvaluator unit,
        ActionsBuilder? actions = null,
        bool anyDamageType = default,
        DamageEnergyType damageEType = default)
    {
      ValidateParam(unit);
    
      var component = new DamageTypeTrigger();
      component.Unit = unit;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.AnyDamageType = anyDamageType;
      component.DamageEType = damageEType;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeactivateTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeactivateTrigger))]
    public TBuilder AddDeactivateTrigger(
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var component = new DeactivateTrigger();
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="DeviceInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(DeviceInteractionTrigger))]
    public TBuilder AddDeviceInteractionTrigger(
        ActionsBuilder? actions = null,
        ActionsBuilder? restrictedActions = null)
    {
      var component = new DeviceInteractionTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.RestrictedActions = restrictedActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitCombatTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitCombatTrigger))]
    public TBuilder AddEvaluatedUnitCombatTrigger(
        UnitEvaluator unit,
        ActionsBuilder? actions = null,
        bool triggerOnExit = default)
    {
      ValidateParam(unit);
    
      var component = new EvaluatedUnitCombatTrigger();
      component.Unit = unit;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.TriggerOnExit = triggerOnExit;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitDeathTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitDeathTrigger))]
    public TBuilder AddEvaluatedUnitDeathTrigger(
        UnitEvaluator unit,
        bool anyUnit = default,
        ActionsBuilder? actions = null)
    {
      ValidateParam(unit);
    
      var component = new EvaluatedUnitDeathTrigger();
      component.AnyUnit = anyUnit;
      component.Unit = unit;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="EvaluatedUnitHealthTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(EvaluatedUnitHealthTrigger))]
    public TBuilder AddEvaluatedUnitHealthTrigger(
        UnitEvaluator unit,
        bool once = default,
        int percentage = default,
        bool triggerOnAlreadyLowerHeath = default,
        ActionsBuilder? actions = null)
    {
      ValidateParam(unit);
    
      var component = new EvaluatedUnitHealthTrigger();
      component.Unit = unit;
      component.Once = once;
      component.Percentage = percentage;
      component.TriggerOnAlreadyLowerHeath = triggerOnAlreadyLowerHeath;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ExperienceTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ExperienceTrigger))]
    public TBuilder AddExperienceTrigger(
        int experience = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new ExperienceTrigger();
      component.Experience = experience;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="GenericInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(GenericInteractionTrigger))]
    public TBuilder AddGenericInteractionTrigger(
        EntityReference mapObject,
        ActionsBuilder? actions = null,
        ActionsBuilder? restrictedActions = null)
    {
      ValidateParam(mapObject);
    
      var component = new GenericInteractionTrigger();
      component.MapObject = mapObject;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      component.RestrictedActions = restrictedActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="ItemInContainerTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="itemToCheck"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(ItemInContainerTrigger))]
    public TBuilder AddItemInContainerTrigger(
        MapObjectEvaluator mapObject,
        string? itemToCheck = null,
        ActionsBuilder? onAddActions = null,
        ActionsBuilder? onRemoveActions = null)
    {
      ValidateParam(mapObject);
    
      var component = new ItemInContainerTrigger();
      component.m_ItemToCheck = BlueprintTool.GetRef<BlueprintItemReference>(itemToCheck);
      component.MapObject = mapObject;
      component.OnAddActions = onAddActions?.Build() ?? Constants.Empty.Actions;
      component.OnRemoveActions = onRemoveActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="MapObjectDestroyTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectDestroyTrigger))]
    public TBuilder AddMapObjectDestroyTrigger(
        ActionsBuilder? destroyedActions = null,
        ActionsBuilder? destructionFailedActions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MapObjectDestroyTrigger();
      component.DestroyedActions = destroyedActions?.Build() ?? Constants.Empty.Actions;
      component.DestructionFailedActions = destructionFailedActions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="MapObjectPerceptionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(MapObjectPerceptionTrigger))]
    public TBuilder AddMapObjectPerceptionTrigger(
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new MapObjectPerceptionTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="PartyInventoryTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(PartyInventoryTrigger))]
    public TBuilder AddPartyInventoryTrigger(
        string? item = null,
        ActionsBuilder? onAddActions = null,
        ActionsBuilder? onRemoveActions = null)
    {
      var component = new PartyInventoryTrigger();
      component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      component.OnAddActions = onAddActions?.Build() ?? Constants.Empty.Actions;
      component.OnRemoveActions = onRemoveActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PerceptionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(PerceptionTrigger))]
    public TBuilder AddPerceptionTrigger(
        UnitEvaluator unit,
        MapObjectEvaluator mapObject,
        ActionsBuilder? onSpotted = null)
    {
      ValidateParam(unit);
      ValidateParam(mapObject);
    
      var component = new PerceptionTrigger();
      component.Unit = unit;
      component.MapObject = mapObject;
      component.OnSpotted = onSpotted?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="PlayerOpenItemDescriptionFirstTimeTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="item"><see cref="Kingmaker.Blueprints.Items.BlueprintItem"/></param>
    [Generated]
    [Implements(typeof(PlayerOpenItemDescriptionFirstTimeTrigger))]
    public TBuilder AddPlayerOpenItemDescriptionFirstTimeTrigger(
        string? item = null,
        ActionsBuilder? action = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new PlayerOpenItemDescriptionFirstTimeTrigger();
      component.m_Item = BlueprintTool.GetRef<BlueprintItemReference>(item);
      component.Action = action?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="RestTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(RestTrigger))]
    public TBuilder AddRestTrigger(
        bool once = default,
        RestResult restResults = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new RestTrigger();
      component.Once = once;
      component.RestResults = restResults;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="ScriptZoneTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(ScriptZoneTrigger))]
    public TBuilder AddScriptZoneTrigger(
        EntityReference scriptZone,
        string unitRef,
        ConditionsBuilder? onEnterConditions = null,
        ActionsBuilder? onEnterActions = null,
        ConditionsBuilder? onExitConditions = null,
        ActionsBuilder? onExitActions = null)
    {
      ValidateParam(scriptZone);
    
      var component = new ScriptZoneTrigger();
      component.ScriptZone = scriptZone;
      component.UnitRef = unitRef;
      component.OnEnterConditions = onEnterConditions?.Build() ?? Constants.Empty.Conditions;
      component.OnEnterActions = onEnterActions?.Build() ?? Constants.Empty.Actions;
      component.OnExitConditions = onExitConditions?.Build() ?? Constants.Empty.Conditions;
      component.OnExitActions = onExitActions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SkillCheckInteractionTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(SkillCheckInteractionTrigger))]
    public TBuilder AddSkillCheckInteractionTrigger(
        ActionsBuilder? onSuccess = null,
        ActionsBuilder? onFailure = null)
    {
      var component = new SkillCheckInteractionTrigger();
      component.OnSuccess = onSuccess?.Build() ?? Constants.Empty.Actions;
      component.OnFailure = onFailure?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpawnUnitTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="targetUnit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(SpawnUnitTrigger))]
    public TBuilder AddSpawnUnitTrigger(
        string? targetUnit = null,
        ActionsBuilder? actions = null)
    {
      var component = new SpawnUnitTrigger();
      component.m_TargetUnit = BlueprintTool.GetRef<BlueprintUnitReference>(targetUnit);
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SpellCastTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="spells"><see cref="Kingmaker.UnitLogic.Abilities.Blueprints.BlueprintAbility"/></param>
    [Generated]
    [Implements(typeof(SpellCastTrigger))]
    public TBuilder AddSpellCastTrigger(
        EntityReference scriptZone,
        string[]? spells = null,
        ActionsBuilder? actions = null)
    {
      ValidateParam(scriptZone);
    
      var component = new SpellCastTrigger();
      component.ScriptZone = scriptZone;
      component.m_Spells = spells.Select(name => BlueprintTool.GetRef<BlueprintAbilityReference>(name)).ToArray();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="SummonPoolTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="summonPool"><see cref="Kingmaker.Blueprints.BlueprintSummonPool"/></param>
    [Generated]
    [Implements(typeof(SummonPoolTrigger))]
    public TBuilder AddSummonPoolTrigger(
        int count = default,
        SummonPoolTrigger.ChangeTypes changeType = default,
        string? summonPool = null,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null)
    {
      var component = new SummonPoolTrigger();
      component.Count = count;
      component.ChangeType = changeType;
      component.m_SummonPool = BlueprintTool.GetRef<BlueprintSummonPoolReference>(summonPool);
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TimeOfDayChangedTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TimeOfDayChangedTrigger))]
    public TBuilder AddTimeOfDayChangedTrigger(
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new TimeOfDayChangedTrigger();
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UIEventTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(UIEventTrigger))]
    public TBuilder AddUIEventTrigger(
        UIEventType eventType = default,
        ConditionsBuilder? conditions = null,
        ActionsBuilder? actions = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      var component = new UIEventTrigger();
      component.EventType = eventType;
      component.Conditions = conditions?.Build() ?? Constants.Empty.Conditions;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    /// <summary>
    /// Adds <see cref="UnitHealthTrigger"/> (Auto Generated)
    /// </summary>
    ///
    /// <param name="unit"><see cref="Kingmaker.Blueprints.BlueprintUnit"/></param>
    [Generated]
    [Implements(typeof(UnitHealthTrigger))]
    public TBuilder AddUnitHealthTrigger(
        string? unit = null,
        int percentage = default,
        ActionsBuilder? actions = null)
    {
      var component = new UnitHealthTrigger();
      component.m_Unit = BlueprintTool.GetRef<BlueprintUnitReference>(unit);
      component.Percentage = percentage;
      component.Actions = actions?.Build() ?? Constants.Empty.Actions;
      return AddComponent(component);
    }

    /// <summary>
    /// Adds <see cref="TrapTrigger"/> (Auto Generated)
    /// </summary>
    [Generated]
    [Implements(typeof(TrapTrigger))]
    public TBuilder AddTrapTrigger(
        MapObjectEvaluator trap,
        ActionsBuilder? onActivation = null,
        ActionsBuilder? onDisarm = null,
        ComponentMerge mergeBehavior = ComponentMerge.Replace,
        Action<BlueprintComponent, BlueprintComponent>? mergeAction = null)
    {
      ValidateParam(trap);
    
      var component = new TrapTrigger();
      component.Trap = trap;
      component.OnActivation = onActivation?.Build() ?? Constants.Empty.Actions;
      component.OnDisarm = onDisarm?.Build() ?? Constants.Empty.Actions;
      return AddUniqueComponent(component, mergeBehavior, mergeAction);
    }

    //----- Start: Configure & Validate

    /// <summary>Type specific configuration implemented in child classes.</summary>
    /// 
    /// <remarks>Components are added to the blueprint after this step.</remarks>
    protected virtual void ConfigureInternal() { }

    /// <summary>Type specific validation implemented in child classes.</summary>
    /// 
    /// <remarks>Implementations should report errors using <see cref="AddValidationWarning(string)"/>.</remarks>
    protected virtual void ValidateInternal() { }

    protected void AddValidationWarning(string msg) { ValidationWarnings.AppendLine(msg); }

    protected void ValidateParam(object? obj) { Validator.Check(obj).ForEach(AddValidationWarning); }

    protected void ValidateParam<P>(IEnumerable<P>? objects)
    {
      if (objects is null) { return; }
      foreach (var obj in objects) { ValidateParam(obj); }
    }

    private void OnConfigure()
    {
      InternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
      ExternalOnConfigure.ForEach(action => action.Invoke(Blueprint));
    }

    private void ConfigureComponents()
    {
      foreach (UniqueComponent component in UniqueComponents)
      {
        var current = Blueprint.GetComponentMatchingType(component.Component);
        if (current == null)
        {
          Components.Add(component.Component);
          continue;
        }
        switch (component.Behavior)
        {
          case ComponentMerge.Skip:
            break;
          case ComponentMerge.Replace:
            ComponentsToRemove.Add(current);
            Components.Add(component.Component);
            break;
          case ComponentMerge.Merge:
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            component.Merge(current, component.Component);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            break;
          case ComponentMerge.Fail:
          default:
            throw new InvalidOperationException($"Failed merging components of type {current.GetType()}");
        }
      }

      if (Blueprint.Components is not null)
      {
        Blueprint.Components = Blueprint.Components.Except(ComponentsToRemove).ToArray();
      }
      Blueprint.AddComponents(Components.ToArray());
    }

    private void ValidateBase()
    {
      var validationContext = new ValidationContext();
      Blueprint.Validate(validationContext);
      foreach (var error in validationContext.Errors) { AddValidationWarning(error); }

      ValidateComponents();
    }

    // TODO: Refactor validation to rely on Validator. That way it can be used externally.
    /// <summary>
    /// Validates each <see cref="BlueprintComponent"/> using its own validation, attributes, and custom logic.
    /// </summary>
    private void ValidateComponents()
    {
      if (Blueprint.Components == null) { return; }
      var componentTypes = new HashSet<Type>();
      foreach (BlueprintComponent component in Blueprint.Components)
      {
        component.ApplyValidation(Context);

        var componentType = component.GetType();
        Attribute[] attrs = Attribute.GetCustomAttributes(componentType);

        if (componentTypes.Contains(componentType)
            && !attrs.Where(attr => attr is AllowMultipleComponentsAttribute).Any())
        {
          AddValidationWarning($"Multiple {componentType} present but only one is allowed.");
        }
        else { componentTypes.Add(componentType); }

        List<AllowedOnAttribute> allowedOn =
            attrs.Where(attr => attr is AllowedOnAttribute).Select(attr => (attr as AllowedOnAttribute)!).ToList();
        bool componentAllowed = false;
        var blueprintType = Blueprint.GetType();
        foreach (AllowedOnAttribute? attr in allowedOn)
        {
          var parent = attr.Type;
          // Need .NET 5.0 for IsAssignableTo()
          if (blueprintType == parent || blueprintType.IsSubclassOf(parent))
          {
            componentAllowed = true;
            break;
          }
        }

        if (allowedOn.Count > 0 && !componentAllowed)
        {
          AddValidationWarning($"Component of {componentType} not allowed on {blueprintType}");
        }
      }

      // Make sure there are no conflicting ContextRankConfigs
      var duplicateRankTypes =
          Blueprint.GetComponents<ContextRankConfig>()
              .Select(config => config.m_Type)
              .GroupBy(type => type)
              .Where(group => group.Count() > 1)
              .Select(group => group.Key);
      if (duplicateRankTypes.Any())
      {
        AddValidationWarning(
            $"Duplicate ContextRankConfig.m_Type values found. Only one of each type is used: {string.Join(",", duplicateRankTypes)}");
      }

      Context.Errors.ToList().ForEach(str => AddValidationWarning(str));
    }

    private struct UniqueComponent
    {
      public BlueprintComponent Component { get; }
      public ComponentMerge Behavior { get; }
      public Action<BlueprintComponent, BlueprintComponent>? Merge { get; }

      public UniqueComponent(
          BlueprintComponent component,
          ComponentMerge behavior,
          Action<BlueprintComponent, BlueprintComponent>? merge)
      {
        Component = component;
        Behavior = behavior;
        Merge = merge;
      }
    }
  }

  /// <summary>Configurator for any blueprint inheriting from <see cref="BlueprintScriptableObject"/>.</summary>
  /// 
  /// <remarks>
  /// <para>
  /// Prefer using the explicit configurator implementations wherever available.
  /// </para>
  /// 
  /// <para>
  /// BlueprintConfigurator is useful for types not supported by the library. Because it is generically typed it will
  /// not expose functions for all supported component types or functions for fields. Instead you can use
  /// <see cref="BaseBlueprintConfigurator{T, TBuilder}.AddComponent">AddComponent</see>,
  /// <see cref="BaseBlueprintConfigurator{T, TBuilder}.AddUniqueComponent">AddUniqueComponent</see>,
  /// and <see cref="BaseBlueprintConfigurator{T, TBuilder}.OnConfigure">OnConfigure</see>. This enables the
  /// configurator API without a specific type implementation and ensures your blueprints are validated.
  /// </para>
  /// 
  /// <example>
  /// <code>
  /// BlueprintConfigurator&lt;BlueprintDlc>.New(DlcGuid)
  ///     .OnConfigure(dlc => dlc.Description = LocalizedDlcDescription)
  ///     .Configure();
  /// </code>
  /// </example>
  /// </remarks>
  [Configures(typeof(BlueprintScriptableObject))]
  public class BlueprintConfigurator<T> : BaseBlueprintConfigurator<T, BlueprintConfigurator<T>>
      where T : BlueprintScriptableObject, new()
  {
    private BlueprintConfigurator(string name) : base(name) { }

    /// <inheritdoc cref="Buffs.BuffConfigurator.For(string)"/>
    public static BlueprintConfigurator<T> For(string name)
    {
      return new BlueprintConfigurator<T>(name);
    }

    /// <inheritdoc cref="Buffs.BuffConfigurator.New(string, string)"/>
    public static BlueprintConfigurator<T> New(string name, string guid)
    {
      BlueprintTool.Create<T>(name, guid);
      return For(name);
    }
  }
}
