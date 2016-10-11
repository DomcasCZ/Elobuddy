using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Soraka.Menus;
using EloBuddy.SDK.Events;

namespace Wladis_Soraka
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
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
                Combo.Execute1();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Flee))
                Combo.Execute3();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
                Combo.Execute4();

            if (ComboMenu["AutoQ"].Cast<CheckBox>().CurrentValue)
                Combo.Execute7();

            if (HealMenu["AutoW"].Cast<CheckBox>().CurrentValue)
                HealSettings.Execute6();

            if (HealMenu["R"].Cast<CheckBox>().CurrentValue || HealMenu["RYou"].Cast<CheckBox>().CurrentValue)
                HealSettings.Execute8();
            
            if (MiscMenu["EStun"].Cast<CheckBox>().CurrentValue)
            if (target.IsCharmed || target.IsStunned || target.IsTaunted || target.IsRooted || target.IsFeared)
            {
                var pred = SpellsManager.E.GetPrediction(target);
                SpellsManager.E.Cast(pred.CastPosition);
            }
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Menus.MiscMenu["Gapcloser"].Cast<CheckBox>().CurrentValue)
                if (!sender.IsEnemy) return;

            if (sender.IsValidTarget(SpellsManager.E.Range))
            {
                SpellsManager.E.Cast(sender.Position);
            }
        }
    }
}