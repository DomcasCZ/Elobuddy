using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;

namespace Spooky_Karthus
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;


           

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass) && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Harass.Execute1();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Flee))
                Flee.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                LaneClear.Execute2();

            if (HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute7();

            if (HarassMenu["AutoE"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute8();

            if (HarassMenu["Q1"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute12();

            /*if (KillStealMenu["Q"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute2();

            if (KillStealMenu["E"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute4();*/

            if (RMenu["R"].Cast<CheckBox>().CurrentValue)
                Active.Execute9();

            if (RMenu["R1"].Cast<CheckBox>().CurrentValue)
                Active.Execute10();

            if (RMenu["R2"].Cast<CheckBox>().CurrentValue)
                Active.Execute11();

            
        }
    }
}