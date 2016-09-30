using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;

namespace Fairy_Lux
{
    internal class Menus
    {
        public const string DrawingsMenuId = "drawingsmenuid";
        public const string MiscMenuId = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu DrawingsMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu FleeMenu;
        public static Menu MiscMenu;
        public static Menu KillStealMenu;
        public static Menu WMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {

            FirstMenu = MainMenu.AddMenu("Fairy " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Lux");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            HarassMenu = FirstMenu.AddSubMenu("• Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear");
            FleeMenu = FirstMenu.AddSubMenu("• Flee");
            WMenu = FirstMenu.AddSubMenu("• W Settings");
            KillStealMenu = FirstMenu.AddSubMenu("• Killsteal");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuId);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuId);


            ComboMenu.AddGroupLabel("Combo Settings");
          //  ComboMenu.Add("Combo1", new CheckBox("Combo 1"));
          //  ComboMenu.AddLabel("Combo 1= E - Q - R");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("E", new CheckBox("- Use E"));
            ComboMenu.Add("R", new CheckBox("- Use R"));
           // ComboMenu.AddLabel("             -            ");
           // ComboMenu.Add("Combo2", new CheckBox("Combo 2"));
           // ComboMenu.AddLabel("Combo 2= Q - E - R");
           // ComboMenu.Add("Q1", new CheckBox("- Use Q"));
            //ComboMenu.Add("E1", new CheckBox("- Use E"));
           // ComboMenu.Add("R1", new CheckBox("- Use R"));

            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.Add("Q", new CheckBox("- Use Q"));
            HarassMenu.Add("E", new CheckBox("- Use E"));
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use Harass Spells", "manaSlider", 50);

            HarassMenu.AddGroupLabel("Auto Harass");
            HarassMenu.Add("AutoQ", new CheckBox("- Use Q", false));
            HarassMenu.Add("AutoE", new CheckBox("- Use E ", false));
            HarassMenu.AddLabel("Autoharras casts spells from itself, when the enemy is in range");
            //HarassMenu.AddLabel("*Autoharass will come soon*");
            //HarassMenu.AddLabel("*Autoharass will come soon*");


            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("Q", new CheckBox("- Use Q"));
            LaneClearMenu.Add("E", new CheckBox("- Use E"));
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use Lane Clear Spells", "manaSlider", 50);

            WMenu.AddGroupLabel("W Settings");
            WMenu.Add("W", new CheckBox("- Use W"));
            WMenu.AddLabel("It will only use W if an enemy is in range");
            WMenu.CreateSlider("HP must be lower that[{0}%] to use W", "dangerSlider", 80);
            WMenu.CreateSlider("Mana must be higher than [{0}%] to use W", "manaSlider", 50);

            KillStealMenu.AddGroupLabel("Killsteal Settings");
            KillStealMenu.Add("Q", new CheckBox("- Use Q"));
            KillStealMenu.Add("E", new CheckBox("- Use E"));
            KillStealMenu.Add("R", new CheckBox("- Use R", false));
            
            FleeMenu.AddGroupLabel("Flee Settings");
            FleeMenu.Add("Q", new CheckBox("- Use Q"));
            FleeMenu.Add("E", new CheckBox("- Use E"));
            FleeMenu.AddLabel("Press T and it will use Q and/or E ");

            MiscMenu.AddGroupLabel("Misc");
            MiscMenu.Add("Interrupt", new CheckBox("- Interrupt"));
            MiscMenu.Add("Gapcloser", new CheckBox("- Gapcloser"));
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
            DrawingsMenu.CreateCheckBox(" - Draw Spell Range only if Spell is Ready.", "readyDraw", false);
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator.", "damageDraw", false);
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Percent.", "perDraw", false);
            DrawingsMenu.CreateCheckBox(" - Draw Damage Indicator Statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox(" - Draw R.", "rDraw");
            DrawingsMenu.AddLabel("It will only draw if ready");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.CornflowerBlue, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.White, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Coral, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.Red, "R Color:");
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