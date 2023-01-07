using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Owlcat.Runtime.Core;
using System.Collections.Generic;
using System.Linq;
using TabletopTweaks.Core.Utilities;
using TomeOfTheFirebird.Helpers;

namespace TomeOfTheFirebird.New_Content.Items
{
    class PaladinGear
    {
        public static BlueprintItemEquipmentWrist merciful;
        public static BlueprintItemEquipmentWrist avengingItem;
        private static BlueprintItemArmor MemoryOfYaniel;
        public static void Build()
        {
            BuildMercy();
            BuildSmite();
            //BuildArmor();
            BuildMaster();



        }

        private static void BuildMaster()
        {
            //Combine both bracers and the extra smite ring into one kickass pair of bracers - 
        }

        private static void BuildSmite()
        {
            //+4 effective class level for smitage
            //Damage *and uses*?
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator avengingFeature = MakerTools.MakeFeature("BracersOfTheAvengingKnightFeature", "Bracers Of The Avenging Knight Feature", "You Shouldn't See This", true);
            string sharedDesc = "If the wearer has levels in a class that grants a smite ability (such as a paladin or hellknight), her smite damage is treated as though she were a member of that class four levels higher.";
            BlueprintCore.Blueprints.Configurators.Items.Ecnchantments.EquipmentEnchantmentConfigurator enchant = MakerTools.MakeItemEnchantment("BracersOfTheAvengingKnightEnchant", "Bracers Of The Avenging Knight", sharedDesc, 1);
            if (Settings.IsEnabled("BracersOfTheAvengingKnight"))
            {
                
                //var DestroSmite = Resources.GetBlueprint<BlueprintAbility>("e69898f762453514780eb5e467694bdb");
                
                //avengingFeature.AddComponent(new IncreaseSpecificSPellsCasterLevel() { spells = new BlueprintAbility[] { SmiteEvil, SmiteChaos, ChampionOfTheFaithSmite, MarkOfJusticeSmite }, Descriptor = Kingmaker.Enums.ModifierDescriptor.Sacred, Value = new Kingmaker.UnitLogic.Mechanics.ContextValue() { Value = 4 } });
                enchant.AddCasterLevelEquipment(bonus: 4, spell: BlueprintTool.GetRef<BlueprintAbilityReference>("7bb9eb2042e67bf489ccd1374423cdec"));
                enchant.AddCasterLevelEquipment(bonus: 4, spell: BlueprintTool.GetRef<BlueprintAbilityReference>("a4df3ed7ef5aa9148a69e8364ad359c5"));
                enchant.AddCasterLevelEquipment(bonus: 4, spell: BlueprintTool.GetRef<BlueprintAbilityReference>("a2736145a29c8814b97a54b45588cd29"));
                enchant.AddCasterLevelEquipment(bonus: 4, spell: BlueprintTool.GetRef<BlueprintAbilityReference>("7a4f0c48829952e47bb1fd1e4e9da83a"));
                AddStatBonusIfHasFactFixed fixedFact = new AddStatBonusIfHasFactFixed(stat: Kingmaker.EntitySystem.Stats.StatType.AdditionalDamage, bonus: new Kingmaker.UnitLogic.Mechanics.ContextValue() { Property = Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.None, Value = 2, ValueRank = Kingmaker.Enums.AbilityRankType.StatBonus, ValueType = Kingmaker.UnitLogic.Mechanics.ContextValueType.Simple }, new List<Blueprint<BlueprintUnitFactReference>>() { "BracersOfTheAvengingKnightFeature" }, descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);
                Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff destroSmite = BuffConfigurator.For("0dfe08afb3cf3594987bab12d014e74b").AddStatBonusIfHasFactFixed(fixedFact).Configure();

            }
            Kingmaker.Blueprints.Classes.BlueprintFeature avengingFeatureBuilt = avengingFeature.Configure();
            
            
            //Add destro active-smite
            //If the wearer is not a member of such a class, once per day she may make one smite attack, gaining a bonus on the attack roll equal to her Charisma bonus, and a +5 bonus to the damage roll on a hit.
            enchant.AddUnitFeatureEquipment(avengingFeatureBuilt.AssetGuidThreadSafe);

            Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment enchantBuilt = enchant.Configure();

            BlueprintItemEquipment templateItem = BlueprintTools.GetBlueprint<BlueprintItemEquipmentWrist>("d68cea6c999eab4459c030c6588c1083");

            string itemSysName = "BracersOfTheAvengingKnight";
            string itemName = "Bracers Of The Avenging Knight";
            string itemDesc = $"TThese silver bracers are polished to a mirrored sheen, but otherwise shift their appearance to match whatever suit of armor they are worn with.\n {sharedDesc}.";
            //TODO add the 1/day lesser resto on LoH
            BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(itemSysName);
            LocalizedString name = LocalizationTool.CreateString(itemSysName + ".Name", itemName);
            LocalizedString desc = LocalizationTool.CreateString(itemSysName + ".Desc", itemDesc);
            ItemEquipmentWristConfigurator item = ItemEquipmentWristConfigurator.New(itemSysName, guid.ToString()).SetDisplayNameText(name).SetDescriptionText(desc);
            item.SetEnchantments(  enchantBuilt.AssetGuidThreadSafe );
            item.SetFlavorText(new LocalizedString());
            item.SetInventoryEquipSound("ArmorPlateEquip");
            item.SetInventoryTakeSound("ArmorPlatePut");
            item.SetInventoryPutSound("ArmorPlateTake");
            item.SetCR(10);
            item.SetCost(11500);
            item.SetIcon(templateItem.Icon);
            item.SetEquipmentEntity(templateItem.EquipmentEntity.AssetGuidThreadSafe);
            item.SetShardItem(templateItem.ShardItem.AssetGuidThreadSafe);
            item.SetNonIdentifiedNameText(new LocalizedString());
            item.SetNonIdentifiedDescriptionText(new LocalizedString());


            avengingItem = item.Configure();

        }

        private static void BuildArmor()
        {


            string armorSysName = "MemoryOfYaniel";
            string armorName = "MemoryOfYaniel";
            string guidForBlessedWay = "30db78c139acf3b41b6572357f0a7650";
            
            //Blessed Path knockoff

            //Drop Wis Bonus
            //Make Cha Bonus Sacred
            //Remove anti-poison save
            //Make Mithril

            //Set bonus with Radience!
            //
        }

        private static void BuildMercy()
        {
            BlueprintCore.Blueprints.CustomConfigurators.Classes.FeatureConfigurator MercyFeature = MakerTools.MakeFeature("BracersOfTheMercifulKnightFeature", "Bracers Of The Merciful Knight Feature", "You Shouldn't See This", true);
            BlueprintCore.Blueprints.Configurators.Items.Ecnchantments.EquipmentEnchantmentConfigurator enchant = MakerTools.MakeItemEnchantment("BracersOfTheMercifulKnightEnchant", "Bracers Of The Merciful Knight", "When worn by a paladin, she is considered four levels higher for the purposes of determining the uses per day and healing provided by her lay on hands class feature. This does not increase the power of her Channel Energy ability.", 1);
            if (Settings.IsEnabled("BracersOfTheMercifulKnight"))
            {
                BlueprintAbility LayOnHandsSelf = BlueprintTools.GetBlueprint<BlueprintAbility>("8d6073201e5395d458b8251386d72df1");

                LayOnHandsSelf.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20

                BlueprintAbility LayOnHandsOther = BlueprintTools.GetBlueprint<BlueprintAbility>("caae1dc6fcf7b37408686971ee27db13");

                LayOnHandsOther.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20
                BlueprintAbility LayOnHandsSpecial = BlueprintTools.GetBlueprint<BlueprintAbility>("8337cea04c8afd1428aad69defbfc365");

                LayOnHandsSpecial.Components.OfType<ContextRankConfig>().FirstOrDefault().m_UseMax = false;//There's no reason for this and we don't want the item crapping out at 20


                MercyFeature.AddIncreaseResourceAmount(resource: "9dedf41d995ff4446a181f143c3db98c", value: 2);
                enchant.AddCasterLevelEquipment(bonus: 4, spell: LayOnHandsSelf.AssetGuidThreadSafe);
                enchant.AddCasterLevelEquipment(bonus:4,  spell: LayOnHandsOther.AssetGuidThreadSafe);
                enchant.AddCasterLevelEquipment(bonus: 4, spell: LayOnHandsSpecial.AssetGuidThreadSafe);
                
            }
            //TODO - add resoration effect with smartness

            Kingmaker.Blueprints.Classes.BlueprintFeature mercyFeatureBuilt = MercyFeature.Configure();

            
            enchant.AddUnitFeatureEquipment(mercyFeatureBuilt.AssetGuidThreadSafe);

            Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment enchantBuilt = enchant.Configure();

            BlueprintItemEquipment templateItem = BlueprintTools.GetBlueprint<BlueprintItemEquipmentWrist>("d68cea6c999eab4459c030c6588c1083");

            string itemSysName = "BracersOfTheMercifulKnight";
            string itemName = "Bracers Of The Merciful Knight";
            string itemDesc = "These golden bracers are engraved with images of celestial creatures.\n When worn by a paladin, she is considered four levels higher for the purposes of determining the uses per day and healing provided by her lay on hands class feature. This does not increase the power of her Channel Energy ability.";
            //TODO add the 1/day lesser resto on LoH
            BlueprintGuid guid = Main.TotFContext.Blueprints.GetGUID(itemSysName);
            LocalizedString name = LocalizationTool.CreateString(itemSysName + ".Name", itemName);
            LocalizedString desc = LocalizationTool.CreateString(itemSysName + ".Desc", itemDesc);
            ItemEquipmentWristConfigurator item = ItemEquipmentWristConfigurator.New(itemSysName, guid.ToString()).SetDisplayNameText(name).SetDescriptionText(desc);
            item.SetEnchantments(enchantBuilt.AssetGuidThreadSafe );
            item.SetFlavorText(new LocalizedString());
            item.SetInventoryEquipSound("ArmorPlateEquip");
            item.SetInventoryTakeSound("ArmorPlatePut");
            item.SetInventoryPutSound("ArmorPlateTake");
            item.SetCR(10);
            item.SetCost(15600);
            item.SetIcon(templateItem.Icon);
            item.SetEquipmentEntity(templateItem.EquipmentEntity.AssetGuidThreadSafe);
            item.SetShardItem(templateItem.ShardItem.AssetGuidThreadSafe);
            item.SetNonIdentifiedNameText(new LocalizedString());
            item.SetNonIdentifiedDescriptionText(new LocalizedString());


             merciful = item.Configure();
        }

    }
}
