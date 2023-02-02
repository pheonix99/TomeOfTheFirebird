using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomeOfTheFirebird.Bugfixes.Items
{
    class PriceFixes
    {
        public static void FixTabletopPrices()
        {
            if (Settings.IsDisabled("FixPricesPaizo"))
                return;

            ItemEquipmentFeetConfigurator.For("1223ceb45ed647b44a04b44a9312328b").SetCost(2500).Configure();//Fix boots of elvenkind
            ItemEquipmentWristConfigurator.For("341bdc12a923fbb4097bc68492f67420").SetCost(6350).Configure();//Fix BracersOfTheWizard
        }

        public static void FixOwlcatPrices()
        {
            if (Settings.IsDisabled("FixPricesOwlbrewEarly"))
                return;
            int PlusOneAndAThird = 3500;
            int plusOneAndAHalf = 5000;
            

                 ItemWeaponConfigurator.For("2f771b62ffb4bdf45a425ba0a0130217").SetCost(5400).Configure();//Erastil Longbow; - list price 9k, BP I foundd shows 3500
                 ItemWeaponConfigurator.For("ca5489a4f7f0c964580fb311d1d6c0ea").SetCost(3600).Configure();// Light Hammer of Righteousness
                 ItemWeaponConfigurator.For("9a5aa6e310b70a14593f08cff0ae8430").SetCost(3600).Configure();//Roaring Handaxe
                 ItemWeaponConfigurator.For("4b84de757030c6944ae8e2f6c89b3231").SetCost(3600).Configure();// Devastaring blow from above
                 ItemWeaponConfigurator.For("7d09cd4da6643914a96e9b1a74ce6152").SetCost(5100).Configure();//Acrid sickle
                 ItemWeaponConfigurator.For("43f6985aaaefb2d4c812121252343c81").SetCost(5100).Configure();//ButcherOfUndead




        }

        public static void FixPricesLate()
        {


            if (Settings.IsEnabled("FixPricesOwlbrewEarly"))
            {
                ItemWeaponConfigurator.For("2f771b62ffb4bdf45a425ba0a0130217").SetCost(5400).Configure();//Erastil Longbow; - list price 9k, BP I foundd shows 3500

            }
        }

    }
}
