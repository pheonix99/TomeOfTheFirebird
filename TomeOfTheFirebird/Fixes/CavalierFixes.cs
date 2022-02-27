using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.Config;

namespace TomeOfTheFirebird.Fixes
{
    public static class CavalierFixes
    {
        public static void FixOrderAbilityDisplays()
        {
            //Display Cockatrice L15
            FeatureConfigurator.For("1ee7bb75e8d29b641b39294ad4d9afca").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            FeatureConfigurator.For("66ed10b9ff262734ca90a7b7167db764").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            //Display Lion L8
            FeatureConfigurator.For("14c5ae26f6c962047be3fda7f865f519").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            //Display Star L2
            FeatureConfigurator.For("271af8eb5d6ccd04899f548380bff006").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            

            //Display Star l8
            FeatureConfigurator.For("2cc3041fdc8693640a0b18c8d14e77e0").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            //Display Sword L15
            FeatureConfigurator.For("485ffa7a62af8064fa76d6d0de13c253").SetHideInCharacterSheetAndLevelUp(false).SetHideInUi(false).Configure();

            //Add Text to sword L8 Feat Selector
            FeatureConfigurator.For("20d873a12e4e6cb4ea6da9761e974dd4").SetDescription(LocalizationTool.CreateString("CavalierMountedMasteryFeatSelection.Desc", "Order Of The Sword Mounted Feat Selector")).Configure();

        }

        public static void FixOrderOfTheStarChannelAssistance()
        {
            if (ModSettings.Bugfixes.Cavalier.IsDisabled("FixOrderOfTheStarCallingChannelingSupport"))
                return;

            var starChannelAssist = FeatureConfigurator.For("eff49ecc28a0ce54caf416bdacedf4f3");

            starChannelAssist.AddIncreaseSpellDescriptorCasterLevel(descriptor: new SpellDescriptorWrapper(SpellDescriptor.ChannelPositiveHeal | SpellDescriptor.ChannelPositiveHarm | SpellDescriptor.ChannelNegativeHeal | SpellDescriptor.ChannelNegativeHarm), 1, modifierDescriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);
            



            //Lay On Hands: Self
            starChannelAssist.AddCasterLevelForAbility("8d6073201e5395d458b8251386d72df1", 1, Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            //Lay On Hands: Other
            starChannelAssist.AddCasterLevelForAbility("caae1dc6fcf7b37408686971ee27db13", 1, Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            //Lay On Hands: Special
            starChannelAssist.AddCasterLevelForAbility("8337cea04c8afd1428aad69defbfc365", 1, Kingmaker.Enums.ModifierDescriptor.UntypedStackable);

            starChannelAssist.Configure();
        }

    }
}
