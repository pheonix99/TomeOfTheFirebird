using Kingmaker.Utility;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TabletopTweaks.Core.Config;
using TabletopTweaks.Core.UMMTools;
using UnityEngine;
using UnityModManagerNet;

namespace TomeOfTheFirebird
{
    public static class UMMSettingsUI
    {
        private static int selectedTab;
        public static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.AutoWidth();
            UI.TabBar(ref selectedTab,
                    () => UI.Label("SETTINGS WILL NOT BE UPDATED UNTIL YOU RESTART YOUR GAME.".yellow().bold()),
                    new NamedAction("Added Content", () => SettingsTabs.NewContent()),
                    new NamedAction("Tweaks", () => SettingsTabs.Tweaks()),
                    new NamedAction("Bugfixes", () => SettingsTabs.Bugfixes()),
                    new NamedAction("Content Modifications", () => SettingsTabs.ContentModifications())

            );
        }
    }

    static class SettingsTabs
    {

        public static void NewContent()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var AddedContent = Main.TotFContext.NewContent;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref AddedContent.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("Spells", TabLevel, AddedContent.Spells);
                SetttingUI.SettingGroup("Feats", TabLevel, AddedContent.Feats);
                SetttingUI.SettingGroup("Mercies", TabLevel, AddedContent.Mercies);
                SetttingUI.SettingGroup("Items", TabLevel, AddedContent.Items);
              

            }
        }
        public static void Bugfixes()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var Bugfixes = Main.TotFContext.Bugfixes;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref Bugfixes.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("Fix Extra Hits", TabLevel, Bugfixes.FixExtraHits);
                SetttingUI.SettingGroup("Purifier", TabLevel, Bugfixes.Purifier);
                SetttingUI.SettingGroup("Cavalier", TabLevel, Bugfixes.Cavalier);
                SetttingUI.SettingGroup("Arcanist", TabLevel, Bugfixes.Arcanist);
                SetttingUI.SettingGroup("Items", TabLevel, Bugfixes.Items);

            }
        }
        public static void Tweaks()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var Tweaks = Main.TotFContext.Tweaks;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref Tweaks.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("Mythic", TabLevel, Tweaks.Mythic);
                SetttingUI.SettingGroup("Spells", TabLevel, Tweaks.Spells);
                SetttingUI.SettingGroup("Crusade", TabLevel, Tweaks.Crusade);
                SetttingUI.SettingGroup("Reward Feature Conversion", TabLevel, Tweaks.RewardFeatureConversion);
                SetttingUI.SettingGroup("Purifier", TabLevel, Tweaks.Purifier);
                SetttingUI.SettingGroup("Witch", TabLevel, Tweaks.Witch);
                SetttingUI.SettingGroup("Bloodlines", TabLevel, Tweaks.Bloodlines);
              

            }
        }

        public static void ContentModifications()
        {
            var TabLevel = SetttingUI.TabLevel.Zero;
            var ContentMods = Main.TotFContext.ContentModifications;
            UI.Div(0, 15);
            using (UI.VerticalScope())
            {
                UI.Toggle("New Settings Off By Default".bold(), ref ContentMods.NewSettingsOffByDefault);
                UI.Space(25);

                SetttingUI.SettingGroup("Dawn Of Dragons", TabLevel, ContentMods.DawnOfDragons);
                SetttingUI.SettingGroup("Crusade", TabLevel, ContentMods.Crusade);
             

            }
        }
    }
   
}
