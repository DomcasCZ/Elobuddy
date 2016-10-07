using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Wladis_Kata
{
    internal static class Harass
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (Menus.HarassMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
            SpellsManager.Q.Cast(qtarget);

            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (Menus.HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                    SpellsManager.W.Cast(wtarget);

            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (Menus.HarassMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                    SpellsManager.E.Cast(etarget);


        }

        public static void Execute7()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;

                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.Cast(qtarget);
        }

        public static void Execute8()
        {
            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                    SpellsManager.W.Cast(wtarget);
        }

    }
}