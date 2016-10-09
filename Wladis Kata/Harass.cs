using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Wladis_Kata
{
    internal static class Harass
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(target.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (Menus.HarassMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(target.Q.Range) && target.Q.IsReady())
            target.Q.Cast(qtarget);

            var wtarget = TargetSelector.GetTarget(target.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (Menus.HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(target.W.Range) && target.W.IsReady())
                    target.W.Cast(wtarget);

            var etarget = TargetSelector.GetTarget(target.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (Menus.HarassMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(target.E.Range) && target.E.IsReady())
                    target.E.Cast(etarget);


        }

        public static void Execute7()
        {
            var qtarget = TargetSelector.GetTarget(target.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;

                if (qtarget.IsValidTarget(target.Q.Range) && target.Q.IsReady())
                    target.Q.Cast(qtarget);
        }

        public static void Execute9()
        {
            var wtarget = TargetSelector.GetTarget(target.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
                if (wtarget.IsValidTarget(target.W.Range) && target.W.IsReady())
                    target.W.Cast(wtarget);
        }

    }
}