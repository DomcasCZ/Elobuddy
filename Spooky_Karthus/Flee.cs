using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;

namespace Spooky_Karthus
{
    internal class Flee
    {
        public static void Execute()
        {

            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast Q
            if (FleeMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                    SpellsManager.Q.TryToCast(wtarget, ComboMenu);

            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range + 20) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.GetPrediction(qtarget);
            SpellsManager.Q.TryToCast(qtarget, FleeMenu);

        }
    }
}