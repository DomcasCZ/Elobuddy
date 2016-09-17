using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Dark_Syndra.Menus;

namespace Dark_Syndra
{
    internal static class Combo
    {
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(qtarget, ComboMenu);

            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                    SpellsManager.W.Cast(Functions.GrabWPost(true));
            SpellsManager.W.TryToCast(wtarget, ComboMenu);

            var qetarget = TargetSelector.GetTarget(SpellsManager.QE.Range, DamageType.Magical);

            if ((qetarget == null) || qetarget.IsInvulnerable)
                return;

            if (ComboMenu["QE"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady() && SpellsManager.E.IsReady() &&
                    qetarget.IsValidTarget(SpellsManager.QE.Range) && SpellsManager.Q.Cast() && SpellsManager.E.Cast())
                {
                    var b = SpellsManager.Q.TryToCast(qetarget, ComboMenu) &&
                            SpellsManager.E.TryToCast(qetarget, ComboMenu);
                }


            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (FleeMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(etarget, FleeMenu);


            //Cast r
            // if (Menus.ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            //   if (rtarget.IsValidTarget(SpellsManager.R.Range) && SpellsManager.R.IsReady())
            //      SpellsManager.R.TryToCast(SpellsManager.R.GetKillableHero(), Menus.ComboMenu);

            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;


            if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                SpellsManager.RDamage(SpellSlot.R, rtarget))
            {
                SpellsManager.R.TryToCast(rtarget, ComboMenu);
            }





        }
    }
}
    


