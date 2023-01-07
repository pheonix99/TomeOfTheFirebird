using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using TomeOfTheFirebird.New_Components;

namespace TomeOfTheFirebird.Bugfixes.Items
{
    class AngelCloak
    {
        public static void CloakFix()
        {
            if (Settings.IsDisabled("FixAngelArtifactCloak"))
                return;

            //Kingmaker.Blueprints.Items.Ecnchantments.BlueprintEquipmentEnchantment enchant = EquipmentEnchantmentConfigurator.For("10b62f56302c49c887d53787948c5cda").RemoveComponents(x => x is AddUnitFeatureEquipment).AddUnitFeatureEquipment("58b832df3c4a4ccba1f0c64138ca95fc").Configure();
            //Main.TotFContext.Logger.LogPatch(enchant);
            /* Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff buff1 = BuffConfigurator.For("f5f500d6a2a39fc4181af32ad79af488").EditComponent<AngelSwordAdditionalDamageAndHeal>(x =>
             {
                 x.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>("58b832df3c4a4ccba1f0c64138ca95fc");
             }).Configure();
             Main.TotFContext.Logger.LogPatch(buff1);*/
            /* Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff buff2 = BuffConfigurator.For("a422afd38359e6a40b71dd41ada6b334").EditComponent<AngelSwordAdditionalDamageAndHeal>(x =>
             {
                 x.m_CloakFact = BlueprintTool.GetRef<BlueprintUnitFactReference>("58b832df3c4a4ccba1f0c64138ca95fc");
             }).Configure();
             Main.TotFContext.Logger.LogPatch(buff2);*/

            //Still needed in EE
            Kingmaker.Blueprints.Items.Ecnchantments.BlueprintWeaponEnchantment swordEnchant = WeaponEnchantmentConfigurator.For("8a24f0fa51f3a2843be5aec58befefb6").RemoveComponents(x => x is WeaponAngelDamageDice).AddComponent<ArtifactEnabledWeaponAngelDamageDice>(x =>
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
