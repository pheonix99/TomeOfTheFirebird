using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.New_Content.ModifySpellLists
{
    static class CoreGameDeityModifications
    {
        public static void Append()
        {
           

            BlueprintTool.AddGuidsByName(("ClericClass", "67819271767a9dd4fbfd4ae700befea0"));
            BlueprintTool.AddGuidsByName(("WarpriestClass", "30b5e47d47a0e37438cc5a80c96cfb99"));
            BlueprintTool.AddGuidsByName(("DruidClass", "610d836f3a3a9ed42a4349b62f002e96"));
            BlueprintTool.AddGuidsByName(("PaladinClass", "bfa11238e7ae3544bbeb4d0b92e897ec"));
            BlueprintTool.AddGuidsByName(("RangerClass", "cda0615668a6df14eb36ba19ee881af6"));
            BlueprintTool.AddGuidsByName(("RageSpell", "97b991256e43bb140b263c326f690ce2"));
            BlueprintTool.AddGuidsByName(("CreatePitSpell", "29ccc62632178d344ad0be0865fd3113"));
            BlueprintTool.AddGuidsByName(("AcidPitSpell", "1407fb5054d087d47a4c40134c809f12"));
            BlueprintTool.AddGuidsByName(("LeadBladesSpell", "779179912e6c6fe458fa4cfb90d96e10"));
            BlueprintTool.AddGuidsByName(("IronBodySpell", "198fcc43490993f49899ed086fe723c1"));
            BlueprintTool.AddGuidsByName(("EyebiteSpell", "3167d30dd3c622c46b0c0cb242061642"));
            BlueprintTool.AddGuidsByName(("FearSpell", "d2aeac47450c76347aebbc02e4f463e0"));
            BlueprintTool.AddGuidsByName(("ConfusionSpell", "886c7407dc629dc499b9f1465ff382df"));
            BlueprintTool.AddGuidsByName(("StoneFistSpell", "85067a04a97416949b5d1dbf986d93f3"));
            BlueprintTool.AddGuidsByName(("HasteSpell", "486eaff58293f6441a5c2759c4872f98"));
            BlueprintTool.AddGuidsByName(("TransformationSpell", "27203d62eb3d4184c9aced94f22e1806"));
            BlueprintTool.AddGuidsByName(("HolySwordSpell", "bea9deffd3ab6734c9534153ddc70bde"));
            BlueprintTool.AddGuidsByName(("GoodHopeSpell", "a5e23522eda32dc45801e32c05dc9f96"));
            BlueprintTool.AddGuidsByName(("BalefulPolymorphSpell", "3105d6e9febdc3f41a08d2b7dda1fe74"));
            BlueprintTool.AddGuidsByName(("FoxsCunningSpell", "ae4d3ad6a8fda1542acf2e9bbc13d113"));
            BlueprintTool.AddGuidsByName(("PerniciousPoisonSpell", "dee3074b2fbfb064b80b973f9b56319e"));
            BlueprintTool.AddGuidsByName(("CircleOfDeathSpell", "a89dcbbab8f40e44e920cc60636097cf"));
            BlueprintTool.AddGuidsByName(("FalseLifeSpell", "7a5b5bf845779a941a67251539545762"));
            BlueprintTool.AddGuidsByName(("SunbeamSpell", "1fca0ba2fdfe2994a8c8bc1f0f2fc5b1"));
            BlueprintTool.AddGuidsByName(("SunburstSpell", "e96424f70ff884947b06f41a765b7658"));
            BlueprintTool.AddGuidsByName(("ContagionSpell", "48e2744846ed04b4580be1a3343a5d3d"));
            BlueprintTool.AddGuidsByName(("RemoveDiseaseSpell", "4093d5a0eb5cae94e909eb1e0e1a6b36"));

            if (Settings.IsDisabled("AddDeitySpecificSpells"))
                return;

            //AbilityConfigurator.For("97b991256e43bb140b263c326f690ce2").AddSpellListComponent(3, "8443ce803d2d31347897a3d85cc32f53").AddSpellListComponent(3, "57c894665b7895c499b3dce058c284b3").Configure();//Rage
            var CalistriaConfig = FeatureConfigurator.For("c7531715a3f046d4da129619be63f44c").SkipAddToSelections();
            CalistriaConfig.AddKnownClericSpell( spell: "RageSpell", spellLevel: 3);
            CalistriaConfig.AddInquisitorSpell( spell: "RageSpell", spellLevel: 3);
            


            CalistriaConfig.Configure();//Calistria

            var DeskariConfig = FeatureConfigurator.For("ddf913858bdf43b4da3b731e082fbcc0").SkipAddToSelections();
            DeskariConfig.AddKnownClericSpell("CreatePitSpell", 3);
           
            
            DeskariConfig.AddKnownClericSpell("AcidPitSpell", 6);
        

            DeskariConfig.Configure();

            var GorumConfig = FeatureConfigurator.For("8f49a5d8528a82c44b8c117a89f6b68c").SkipAddToSelections();

            GorumConfig.AddKnownClericSpell(spell: "LeadBladesSpell", 3);
            GorumConfig.AddInquisitorSpell(spell: "LeadBladesSpell", 3);

            GorumConfig.AddKnownClericSpell(spell: "RageSpell", spellLevel: 3);//Rage for Cleric         
            GorumConfig.AddKnownSpell(characterClass: "DruidClass", spell: "RageSpell", spellLevel: 3);//Rage for Druid

            GorumConfig.AddKnownClericSpell(spell: "IronBodySpell", spellLevel: 8);    

            GorumConfig.Configure();

            var GyronnaConfig = FeatureConfigurator.For("8b535b6842e063d48a571a042c3c6e8f").SkipAddToSelections();
            GyronnaConfig.AddKnownClericSpell("EyebiteSpell", 6);

            GyronnaConfig.Configure();

            var GroetusConfig = FeatureConfigurator.For("c3e4d5681906d5246ab8b0637b98cbfe").SkipAddToSelections();
            GroetusConfig.AddKnownClericSpell("FearSpell", 4);
            GroetusConfig.Configure();

            var IroriConfig = FeatureConfigurator.For("23a77a5985de08349820429ce1b5a234").SkipAddToSelections();
            IroriConfig.AddKnownClericSpell("StoneFistSpell", 1);
            IroriConfig.AddInquisitorSpell("StoneFistSpell", 1);

            IroriConfig.AddKnownClericSpell("HasteSpell", 4);
            IroriConfig.AddInquisitorSpell("HasteSpell", 4);

            IroriConfig.AddKnownClericSpell("TransformationSpell", 6);
            IroriConfig.AddInquisitorSpell("TransformationSpell", 5);

            IroriConfig.Configure();

            var IomedaeFeature = FeatureConfigurator.For("88d5da04361b16746bf5b65795e0c38c").SkipAddToSelections();
            IomedaeFeature.AddKnownClericSpell("HolySwordSpell", 8);
            IomedaeFeature.AddInquisitorSpell("HolySwordSpell", 6);

            IomedaeFeature.AddKnownClericSpell("GoodHopeSpell", 4);
            IomedaeFeature.AddKnownSpell(characterClass: "PaladinClass", spell: "GoodHopeSpell",spellLevel: 3);
            IomedaeFeature.Configure();

            var LamashtuConfig = FeatureConfigurator.For("f86bc8fbf13221f4f9041608a1fb8585").SkipAddToSelections();
            LamashtuConfig.AddKnownClericSpell("BalefulPolymorphSpell", 5);
            LamashtuConfig.AddKnownSpell(characterClass: "DruidClass", spell: "f86bc8fbf13221f4f9041608a1fb8585", spellLevel: 5);

            LamashtuConfig.Configure();

            var NethysConfig = FeatureConfigurator.For("6262cfce7c31626458325ca0909de997").SkipAddToSelections();
            NethysConfig.AddKnownClericSpell("FoxsCunningSpell", 2);
            NethysConfig.Configure();

            var NoroConfig = FeatureConfigurator.For("805b6bdc8c96f4749afc687a003f9628").SkipAddToSelections();
            NoroConfig.AddKnownClericSpell("PerniciousPoisonSpell", 2);
            NoroConfig.AddKnownClericSpell("CircleOfDeathSpell", 6);
            NoroConfig.Configure();

            var PharasmaConfig = FeatureConfigurator.For("458750bc214ab2e44abdeae404ab22e9").SkipAddToSelections();
            PharasmaConfig.AddKnownClericSpell("FalseLifeSpell", 2);
            PharasmaConfig.AddInquisitorSpell("FalseLifeSpell", 2);
            PharasmaConfig.AddOracleSpell("FalseLifeSpell", 2);
            PharasmaConfig.Configure();

            var RovuConfig = FeatureConfigurator.For("04bc2b62273ab744092d992ed72bff41").SkipAddToSelections();
            RovuConfig.AddKnownClericSpell("BalefulPolymorphSpell", 4);
            RovuConfig.AddInquisitorSpell("BalefulPolymorphSpell", 4);
            RovuConfig.AddKnownSpell(characterClass: "DruidClass", spell: "BalefulPolymorphSpell", spellLevel: 4);

            RovuConfig.Configure();

            var SheylenConfig = FeatureConfigurator.For("b382afa31e4287644b77a8b30ed4aa0b").SkipAddToSelections();
            SheylenConfig.AddKnownClericSpell("GoodHopeSpell", 4);
            SheylenConfig.AddInquisitorSpell("GoodHopeSpell", 4);
            SheylenConfig.AddKnownSpell(characterClass: "PaladinClass", spell: "GoodHopeSpell", spellLevel: 4);
            SheylenConfig.Configure();

            var SaraeConfig = FeatureConfigurator.For("c1c4f7f64842e7e48849e5e67be11a1b").SkipAddToSelections();
            SaraeConfig.AddKnownClericSpell("SunbeamSpell", 7);
            SaraeConfig.AddInquisitorSpell("SunbeamSpell", 5);
            SaraeConfig.AddKnownSpell(characterClass: "PaladinClass", spell: "SunbeamSpell", spellLevel: 4);
            SaraeConfig.AddKnownSpell(characterClass: "RangerClass", spell: "SunbeamSpell", spellLevel: 4);
            SaraeConfig.AddKnownClericSpell("SunburstSpell", 8);
            SaraeConfig.AddInquisitorSpell("SunburstSpell", 6);

            SaraeConfig.Configure();

        }

        public static FeatureConfigurator AddKnownClericSpell(this FeatureConfigurator featureConfigurator, Blueprint<BlueprintAbilityReference> spell, int spellLevel)
        {
            featureConfigurator.AddKnownSpell(characterClass: "67819271767a9dd4fbfd4ae700befea0", spell: spell, spellLevel: spellLevel);
            if (spellLevel < 6)
                featureConfigurator.AddKnownSpell(characterClass: "30b5e47d47a0e37438cc5a80c96cfb99", spell: spell, spellLevel: spellLevel);


            return featureConfigurator;
        }

        public static FeatureConfigurator AddInquisitorSpell(this FeatureConfigurator featureConfigurator, Blueprint<BlueprintAbilityReference> spell, int spellLevel)
        {
            return featureConfigurator;
        }
        public static FeatureConfigurator AddOracleSpell(this FeatureConfigurator featureConfigurator, Blueprint<BlueprintAbilityReference> spell, int spellLevel)
        {
            return featureConfigurator;
        }


        /*
         *  /*
     * Base Game: 
     * Abadar: Nothing Implementable
     * Aresh: None
     * Asmodeus: Nothing Implementable
     * Baph: Monsterous Physique https://aonprd.com/SpellDisplay.aspx?ItemName=Monstrous%20Physique%20I - spell levels: Teir+1 for ranger/antipaladin, Tier+2 for Cleric/Wizard, Mazw as cleric 8
     * Calistria: Rage for Cleric/Inqiusotir 3, Suggestion for Cleric/Inquistor at 4 if no charm domain, add to gen list at 3 if Charm domain, https://aonprd.com/SpellDisplay.aspx?ItemName=Incessant%20Buzzing as cleric 1
     * Cayden: None Implementable? Creat Food And Water is a maybe but would require cast-during-rest work and ... lots of stuff
     * Deskari: Antipaladin: Cape of Wasps at 3, Vermin Shape 1 at 4. Cleric: Create pit at 3, Cape of wasp at 4,  Vermin SHape 1/2 at 4/5, Acid Pit at 6
     * Desna: None Implementable
     * Erastil: Goodberry at ranger/paladin /cleric 2 (lol reduce to 1 that spell is hilariously niche)
     * Gorum: Lead Blades: Cleric 3/Inquisitor 3. Rage: Cleric/Druid 3. Iron Body: Cleric 8, Heat Metal: Cleric 3
     * Gyronna: Eyebite: Cleric 6
     * Groteus (from Kingmaker): Fear: Cleric 4. Confusion (Cleric 4 with madness/viod domain)
     * Irori: Stone FIst: CLeric/Inqi 1, Haste: Cleric/Inqi 4, Transformation: Cleric/Inqi 6/5,
     * Iomedae: Holy Sword: Cleric 8 / Inqu 6, Good Hope: CLeric 4 Pal 3,
     * Lamashtu: Baleful Poly: Cleric/Druid 5
     * Netheys: Fox's Cunnning: CLeric 2
     * Noro: Pernicious Poison: Cleric 2. Circle Of Death: Cleric 6
     * Pharasma: False Life: Cleric/Inquistor/Oracle 2
     * Pulara: None
     * Rovugog: Baleful Poly: Antipal/druid/cleric/inquis 4
     * Shelyn: Good Hope: Cleric/inquis/paladin 4
     * Saraenae: https://aonprd.com/SpellDisplay.aspx?ItemName=Sun%20Metal: Inquis 1, Sunbeam: Cleric 7, Inquis 5, Paladin/Ranger 4, Sunburst: Cleric 8, Inquis 6, Flame blade: Clerid/inquis 3, Paladin/ranger 2
     * Torag: None Implementable
     * Urgarotha: Ghoul Touch: Antipaladin/Cleric/Inqus 2, Contagion: Sorc/Necro 3, Remove Disease: Sorc/Necro 3
     * Zon: None Implementable
     */

    }
}
