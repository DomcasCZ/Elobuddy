using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.WarJumper;
using static Wladis_Kata.Skins;

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
            ComboMenu.Add("ComboLogic", new ComboBox(" Combo Logic ", 0, "Q>E>W", "E>Q>W"));
            ComboMenu.AddSeparator();
            ComboMenu.Add("El", new CheckBox(" Don't Use E if enemy is in AA- range"));
            ComboMenu.AddLabel("Dont use E on almost not killable enemys");
            ComboMenu.AddSeparator();
            ComboMenu.Add("Ignite", new CheckBox("- Use Ignite", false));
            ComboMenu.AddLabel("It will only use ignite, when the enemy isn't killable with Combo");
            ComboMenu.AddSeparator(15);
            ComboMenu.Add("IgniteHealth", new Slider("- Ignite if enemy Hp % < Slider %", 60, 1, 100));
            ComboMenu.AddSeparator(30);
            //ComboMenu.Add("R-Logic", new ComboBox(" R-Logic ", 2, "< Half R range", "In R range", "In W Range"));
            ComboMenu.AddLabel("If you want perfekt R, disable your Evade or set it to dodge dangerous only");
            ComboMenu.Add("R1", new CheckBox("- R on full range", false));
            ComboMenu.Add("R2", new CheckBox("- R on half range or closer"));
            ComboMenu.Add("R3", new CheckBox("- R on W range", false));
            ComboMenu.AddSeparator();
            ComboMenu.Add("Rblock", new CheckBox("- Block other spells while R is casting"));
            ComboMenu.Add("Rendblock", new CheckBox("- End the Block when Q W E is ready"));
            ComboMenu.AddLabel("It will always end the block when target is out of R range and it will cast spells again");
            //ComboMenu.AddLabel("with '< Half R range' is ment that, R will be casted, when enemy is in half of the R range or closer");
            ComboMenu.AddSeparator(15);
            ComboMenu.Add("Rhealth", new Slider("- R if enemy health % < Slider %", 0, 1, 100));
            ComboMenu.AddSeparator();
            ComboMenu.Add("AutoKill", new CheckBox("Auto kill with combo", false));
            ComboMenu.Add("AutoKillenemysinrange", new Slider("only autokill if < x enemies surround the target", 5, 1 , 5));
            ComboMenu.AddSeparator(15);
            //ComboMenu.Add("Status", new CheckBox("disable status drawings", false));

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
            MiscMenu.Add("Z", new CheckBox("- use Zhonyas"));
            MiscMenu.AddSeparator(15);
            MiscMenu.Add("Zhealth", new Slider("- Health % for Zhonyas", 20, 0, 100));
            MiscMenu.AddSeparator(15);
            MiscMenu.Add("Humanizer", new CheckBox("- Use Humanizer", false));
            MiscMenu.AddSeparator(25);
            MiscMenu.AddGroupLabel("Skin Changer");

            var skinList = SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.Add("SkinComboBox", new ComboBox ("Choose the skin", skinList.Skins));
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange +=
                    delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                    {
                        Player.Instance.SetSkinId(sender.CurrentValue);
                    };
            }

            DrawingsMenu.AddGroupLabel("Setting");
            DrawingsMenu.Add("readyDraw", new CheckBox (" - Draw Spell Range only if Spell is Ready."));
            DrawingsMenu.Add("damageDraw", new CheckBox (" - Draw Damage Indicator."));
            DrawingsMenu.Add("perDraw", new CheckBox (" - Draw Damage Indicator Percent."));
            DrawingsMenu.Add("statDraw", new CheckBox (" - Draw Damage Indicator Statistics.", false));
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.Add("readyDraw", new CheckBox(" - Draw Spell Range only if Spell is Ready."));
            DrawingsMenu.Add("qDraw", new CheckBox("- draw Q"));
            DrawingsMenu.Add("wDraw", new CheckBox("- draw W"));
            DrawingsMenu.Add("eDraw", new CheckBox("- draw E"));
            DrawingsMenu.Add("rDraw", new CheckBox("- draw R"));
            DrawingsMenu.AddLabel("It will only draw if ready");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.CornflowerBlue, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.White, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Coral, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.Red, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.Gold,
                "DamageIndicator Color:");

            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.Add("activateAutoLVL", new CheckBox ("Activate Auto Leveler", false));
            MiscMenu.AddLabel("The Auto Leveler will always Focus R than the rest of the Spells");
            MiscMenu.Add("firstFocus", new ComboBox ("1 Spell to Focus", new List<string> { "Q", "W", "E" }));
            MiscMenu.Add("secondFocus", new ComboBox ("2 Spell to Focus", new List<string> { "Q", "W", "E" }, 1));
            MiscMenu.Add("thirdFocus", new ComboBox ("3 Spell to Focus", new List<string> { "Q", "W", "E" }, 2));
            MiscMenu.Add("delaySlider", new Slider ("Delay Slider", 200, 150, 500));
        }
    }
}
