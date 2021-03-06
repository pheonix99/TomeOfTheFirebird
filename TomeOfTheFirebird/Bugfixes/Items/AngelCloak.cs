using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Designers.Mechanics.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Bugfixes.Items
{
    class AngelCloak
    {
        public static void CloakFix()
        {
            if (Main.TotFContext.Bugfixes.Items.IsDisabled("FixAngelArtifactCloak"))
                return;

            var enchant = EquipmentEnchantmentConfigurator.For("10b62f56302c49c887d53787948c5cda").RemoveComponents(x => x is AddUnitFeatureEquipment).AddUnitFeatureEquipment("58b832df3c4a4ccba1f0c64138ca95fc").Configure();
            Main.TotFContext.Logger.LogPatch(enchant);
            var buff1 = BuffConfigurator.For("f5f500d6a2a39fc4181af32ad79af488").EditComponent<AngelSwordAdditionalDamageAndHeal>(x =>
            {
                x.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>("58b832df3c4a4ccba1f0c64138ca95fc");
            }).Configure();
            Main.TotFContext.Logger.LogPatch(buff1);
            var buff2 = BuffConfigurator.For("a422afd38359e6a40b71dd41ada6b334").EditComponent<AngelSwordAdditionalDamageAndHeal>(x =>
            {
                x.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>("58b832df3c4a4ccba1f0c64138ca95fc");
            }).Configure();
            Main.TotFContext.Logger.LogPatch(buff2);

            var swordEnchant = WeaponEnchantmentConfigurator.For("8a24f0fa51f3a2843be5aec58befefb6").RemoveComponents(x => x is WeaponAngelDamageDice).AddComponent<ArtifactEnabledWeaponAngelDamageDice>(x =>
              {
                  x.BaseFormula = new Kingmaker.RuleSystem.DiceFormula(2, Kingmaker.RuleSystem.DiceType.D6);
                  x.ExtraFormula = new Kingmaker.RuleSystem.DiceFormula(2, Kingmaker.RuleSystem.DiceType.D6);
                  x.Element = Kingmaker.Enums.Damage.DamageEnergyType.Holy;
                  x.m_MaximizeFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>("84f001f9aaaa73c479659edfa87f4782");
                  x.m_ArtifactFeature = BlueprintTool.GetRef<BlueprintUnitFactReference>("58b832df3c4a4ccba1f0c64138ca95fc");

              }).Configure();
        }
    }
}
