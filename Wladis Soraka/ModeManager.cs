using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Soraka.Menus;
using static Wladis_Soraka.Combo;
using EloBuddy.SDK.Events;
using System.Linq;

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
            var sdl = EntityManager.Heroes.Allies.FirstOrDefault(hero => !hero.IsMe && !hero.IsInShopRange() && !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.W.Range);
            var playerMana = Player.Instance.ManaPercent;
            var enemy = EntityManager.Heroes.Enemies.FirstOrDefault(hero => !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.E.Range);

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

            if (HealMenu["SpeedBuff"].Cast<CheckBox>().CurrentValue && HealMenu["SpeedBuffFlee"].Cast<CheckBox>().CurrentValue && enemy.IsFleeing && myhero.Distance(enemy) <= SpellsManager.E.Range && SpellsManager.W.IsReady() && !sdl.HasBuff("SorakaQRegen") && myhero.HasBuff("SorakaQRegen"))
            {
                SpellsManager.W.Cast(sdl);
            }

            if (HealMenu["SpeedBuff"].Cast<CheckBox>().CurrentValue && HealMenu["SpeedBuffEnemy"].Cast<CheckBox>().CurrentValue && myhero.Distance(enemy) <= SpellsManager.E.Range && SpellsManager.W.IsReady() && !sdl.HasBuff("SorakaQRegen") && myhero.HasBuff("SorakaQRegen"))
            {
                SpellsManager.W.Cast(sdl);
            }

                if (MiscMenu["EStun"].Cast<CheckBox>().CurrentValue && enemy.IsCharmed || enemy.IsStunned || enemy.IsTaunted || enemy.IsRooted || enemy.IsFeared)
            {
                var pred = SpellsManager.E.GetPrediction(enemy);
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