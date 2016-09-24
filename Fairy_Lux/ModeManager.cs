using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Fairy_Lux.Menus;
using static Fairy_Lux.Active;

namespace Fairy_Lux
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
                LaneClear.Execute();

            if (HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute7();

            if (WMenu["W"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Active.Execute6();

            if (HarassMenu["AutoE"].Cast<CheckBox>().CurrentValue) 
                Autoharass.Execute8();

            if (KillStealMenu["Q"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute2();
            
            if (KillStealMenu["E"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute4();

            if (KillStealMenu["R"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute5();
            




        }
    }
}
