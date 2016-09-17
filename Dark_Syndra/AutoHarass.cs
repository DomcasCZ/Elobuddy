using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;



namespace Dark_Syndra
{
    internal static class AutoHarass
    {
        public static void Execute6()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (Menus.HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                SpellsManager.Q.TryToCast(qtarget, Menus.HarassMenu);
        }

        public static void Execute7()
        {
            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (Menus.HarassMenu["AutoW"].Cast<CheckBox>().CurrentValue)
            if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                SpellsManager.W.Cast(Functions.GrabWPost(true));
            SpellsManager.W.TryToCast(wtarget, Menus.HarassMenu);
        }
    }
}