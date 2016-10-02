using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using T2IN1_Lib.DataBases;
using static Wladis_Kata.WarJumper;

namespace Wladis_Kata
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
        public static Menu LastHitMenu;
        public static Menu MiscMenu;
        public static Menu KillStealMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {

            FirstMenu = MainMenu.AddMenu("Wladis " + Player.Instance.ChampionName,
                Player.Instance.ChampionName.ToLower() + "Kata");
            ComboMenu = FirstMenu.AddSubMenu("• Combo ");
            HarassMenu = FirstMenu.AddSubMenu("• Harass");
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear");
            LastHitMenu = FirstMenu.AddSubMenu("• Lasthit");
            KillStealMenu = FirstMenu.AddSubMenu("• Killsteal");
            WardjumpMenu = FirstMenu.AddSubMenu("• WardJump");
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuId);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuId);


            ComboMenu.AddGroupLabel("Combo Settings");
            ComboMenu.Add("Q", new CheckBox("- Use Q"));
            ComboMenu.Add("W", new CheckBox("- Use W"));
            ComboMenu.Add("E", new CheckBox("- Use E"));
            ComboMenu.Add("R", new CheckBox("- Use R"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("El", new CheckBox(" Don't Use E if enemy is in AA- range", false));
            ComboMenu.AddSeparator();
            //ComboMenu.Add("R-Logic", new ComboBox(" R-Logic ", 2, "< Half R range", "In R range", "In W Range"));
            ComboMenu.AddLabel("If you want perfekt R, disable your Evade or set it to dodge dangerous only");
            ComboMenu.Add("R1", new CheckBox("- R on full range", false));
            ComboMenu.Add("R2", new CheckBox("- R on half range or closer"));
            ComboMenu.Add("R3", new CheckBox("- R on W range", false));
            //ComboMenu.AddLabel("with '< Half R range' is ment that, R will be casted, when enemy is in half of the R range or closer");
            ComboMenu.AddSeparator(15);
            ComboMenu.Add("Rhealth", new Slider("- R if enemy health % < Slider %", 0, 1, 100));

            WardjumpMenu.AddGroupLabel("Wardjump Settings");
            var a = WardjumpMenu.Add("alwaysMax", new CheckBox("Always Jump To Max Range"));
            var b = WardjumpMenu.Add("onlyToCursor", new CheckBox("Always Jump To Cursor", false));
            a.OnValueChange += delegate { if (a.CurrentValue) b.CurrentValue = false; };
            b.OnValueChange += delegate { if (b.CurrentValue) a.CurrentValue = false; };
            WardjumpMenu.AddSeparator();
            WardjumpMenu.AddLabel("Time Modifications");
            WardjumpMenu.Add("checkTime", new Slider("Position Reset Time (ms)", 0, 1, 2000));
            WardjumpMenu.AddSeparator();
            WardjumpMenu.AddLabel("Keybind Settings");
            var wj = WardjumpMenu.Add("wardjumpKeybind",
    new KeyBind("WardJump", false, KeyBind.BindTypes.HoldActive, 'T'));
            GameObject.OnCreate += GameObject_OnCreate;
            Game.OnTick += delegate
            {
                if (wj.CurrentValue)
                {
                    WardJump(Game.CursorPos, a.CurrentValue, b.CurrentValue);
                    return;
                }
            };

            HarassMenu.AddGroupLabel("Harass Settings");
            HarassMenu.Add("Q", new CheckBox("- Use Q"));
            HarassMenu.AddSeparator();
            HarassMenu.Add("W", new CheckBox("- Use W"));

            HarassMenu.AddGroupLabel("Auto Harass");
            HarassMenu.Add("AutoQ", new CheckBox("- Use Q", false));
            HarassMenu.Add("AutoW", new CheckBox("- Use W", false));
            HarassMenu.AddLabel("Autoharras casts spells from itself, when the enemy is in range");


            LaneClearMenu.AddGroupLabel("Lane Clear Settings");
            LaneClearMenu.Add("Q", new CheckBox("- Use Q"));
            LaneClearMenu.Add("W", new CheckBox("- Use W"));
            LaneClearMenu.Add("E", new CheckBox("- Use E", false));
            LaneClearMenu.AddSeparator();
            LaneClearMenu.Add("WX", new Slider("- Will hit x minions with W", 0, 1, 6));

            LastHitMenu.AddGroupLabel("Last hit Settings");
            LastHitMenu.Add("Q", new CheckBox("- Use Q"));
            LastHitMenu.Add("W", new CheckBox("- Use W"));
            LastHitMenu.Add("E", new CheckBox("- Use E", false));

            KillStealMenu.AddGroupLabel("Killsteal Settings");
            KillStealMenu.Add("Q", new CheckBox("- Use Q"));
            KillStealMenu.Add("W", new CheckBox("- Use W"));
            KillStealMenu.Add("E", new CheckBox("- Use E"));
            KillStealMenu.Add("R", new CheckBox("- Use R", false));

            MiscMenu.AddGroupLabel("Misc");
            MiscMenu.Add("Z", new CheckBox("- use Zhonyas", false));
            MiscMenu.AddSeparator(15);
            MiscMenu.Add("Zhealth", new Slider("- Health % for Zhonyas", 20, 0, 100));
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
