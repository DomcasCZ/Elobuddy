using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;

namespace Spooky_Karthus
{
    internal class Menus
    {
        public const string DrawingsMenuId = "drawingsmenuid";
        public const string MiscMenuId = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu RMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu FleeMenu;
        public static Menu MiscMenu;
        public static Menu KillStealMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {

            FirstMenu = MainMenu.AddMenu("Spooky " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Karthus");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            RMenu = FirstMenu.AddSubMenu("• R - Settings ");
            HarassMenu = FirstMenu.AddSubMenu("• Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear");
            FleeMenu = FirstMenu.AddSubMenu("• Flee");
            //KillStealMenu = FirstMenu.AddSubMenu("• Killsteal");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuId);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuId);


            FirstMenu.AddGroupLabel("Please give me feedback, that I can improve Spooky Karthus :)");

            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("Q1", new CheckBox("- Use Q - crit"));
            ComboMenu.AddLabel("Q - crit will try to cast Q only on 1 target, if it is possible");
            ComboMenu.Add("W", new CheckBox("- Use W"));
            ComboMenu.Add("E", new CheckBox("- Use E", false));
            ComboMenu.AddGroupLabel("Don't use SDK beta prediction");

            RMenu.Add("R", new CheckBox("- Use R", false));
            RMenu.AddLabel("Will use R to KS");
            RMenu.Add("R1", new CheckBox("- Use R "));
            RMenu.AddLabel("Will use R to kill a safe enemy");
            RMenu.Add("R2", new CheckBox("- Use only text", false));
            RMenu.AddLabel("' Killable target with R' ");
            RMenu.AddLabel("-");
            RMenu.AddLabel("It will only use R when you are not pressing spacebar and could kill the enemy with Q");
            

            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.Add("Q", new CheckBox("- Use Q"));
            HarassMenu.Add("E", new CheckBox("- Use E"));
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use harass spells", "manaSlider", 50);

            HarassMenu.AddGroupLabel("Auto Harass");
            HarassMenu.Add("AutoQ", new CheckBox("- Use Q", false));
            HarassMenu.Add("Q1", new CheckBox("- Use Q - crit", false));
            HarassMenu.Add("AutoE", new CheckBox("- Use E ", false));
            HarassMenu.AddLabel("Autoharras casts spells from itself, when the enemy is in range");
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use autoharass Spells", "manaSlider", 40);


            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("Q", new CheckBox("- Use Q"));
            LaneClearMenu.Add("E", new CheckBox("- Use E"));
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use Lane Clear Spells", "manaSlider", 50);

           // KillStealMenu.AddGroupLabel("Killsteal Settings");
           // KillStealMenu.Add("Q", new CheckBox("- Use Q"));
           // KillStealMenu.Add("E", new CheckBox("- Use E"));

            FleeMenu.AddGroupLabel("Flee Settings");
            FleeMenu.Add("W", new CheckBox("- Use W"));
            FleeMenu.AddLabel("Click T and it will use W ");
            
            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        Player.Instance.SetSkinId(sender.CurrentValue);
                    };
            }

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.CreateCheckBox(" - Draw Spell Range only if Spell is Ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.AddLabel("*Only draw if ready*");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.CornflowerBlue, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.White, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Coral, "E Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.Gold,
                "DamageIndicator Color:");

            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.CreateCheckBox("Activate Auto Leveler", "activateAutoLVL", false);
            MiscMenu.AddLabel("The Auto Leveler will always Focus R than the rest of the Spells");
            MiscMenu.CreateComboBox("1 Spell to Focus", "firstFocus", new List<string> { "Q", "W", "E" });
            MiscMenu.CreateComboBox("2 Spell to Focus", "secondFocus", new List<string> { "Q", "W", "E" }, 1);
            MiscMenu.CreateComboBox("3 Spell to Focus", "thirdFocus", new List<string> { "Q", "W", "E" }, 2);
            MiscMenu.CreateSlider("Delay Slider", "delaySlider", 200, 150, 500);
        }
    }
}