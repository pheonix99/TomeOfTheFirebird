using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;

namespace TomeOfTheFirebird.Bugfixes.Classes
{
    public static class CavalierFixes
    {
        public static void FixOrderAbilityDisplays()
        {
            //Display Cockatrice L15
            FeatureConfigurator.For("1ee7bb75e8d29b641b39294ad4d9afca").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            FeatureConfigurator.For("66ed10b9ff262734ca90a7b7167db764").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            //Display Lion L8
            FeatureConfigurator.For("14c5ae26f6c962047be3fda7f865f519").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            //Display Star L2
            FeatureConfigurator.For("271af8eb5d6ccd04899f548380bff006").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            

            //Display Star l8
            FeatureConfigurator.For("2cc3041fdc8693640a0b18c8d14e77e0").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            //Display Sword L15
            FeatureConfigurator.For("485ffa7a62af8064fa76d6d0de13c253").SetHideInCharacterSheetAndLevelUp(false).SetHideInUI(false).Configure();

            //Add Text to sword L8 Feat Selector
            FeatureConfigurator.For("20d873a12e4e6cb4ea6da9761e974dd4").SetDescription(LocalizationTool.CreateString("CavalierMountedMasteryFeatSelection.Desc", "Order Of The Sword Mounted Feat Selector")).Configure();

        }

        public static void FixOrderOfTheStarChannelAssistance()
        {
            if (Main.TotFContext.Bugfixes.Cavalier.IsDisabled("FixOrderOfTheStarCallingChannelingSupport"))
                return;
            //Still needed in EE
            FeatureConfigurator starChannelAssist = FeatureConfigurator.For("eff49ecc28a0ce54caf416bdacedf4f3");

            starChannelAssist.AddIncreaseSpellDescriptorCasterLevel(descriptor: new SpellDescriptorWrapper(SpellDescriptor.ChannelPositiveHeal | SpellDescriptor.ChannelPositiveHarm | SpellDescriptor.ChannelNegativeHeal | SpellDescriptor.ChannelNegativeHarm), bonusCasterLevel: 1, modifierDescriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);
            



            //Lay On Hands: Self
            starChannelAssist.AddCasterLevelForAbility(spell: "8d6073201e5395d458b8251386d72df1", bonus: 1, descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            //Lay On Hands: Other
            starChannelAssist.AddCasterLevelForAbility(spell: "caae1dc6fcf7b37408686971ee27db13", bonus:1,descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            //Lay On Hands: Special
            starChannelAssist.AddCasterLevelForAbility(spell: "8337cea04c8afd1428aad69defbfc365", bonus: 1, descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            starChannelAssist.Configure();
        }

    }
}
