using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Dark_Syndra.Menus;
using static Dark_Syndra.Functions;
using System.Linq;

namespace Dark_Syndra
{
    internal static class Combo
    {
        public static void Execute()
        {
            var sphere =
    ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(a => a.Name == "Seed" && a.IsValid);

            var target = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((target == null) || target.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    var pred = SpellsManager.Q.GetPrediction(target);
                    SpellsManager.Q.Cast(pred.CastPosition);
                }
            //Cast W
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.W.Range+200) && SpellsManager.W.IsReady() && !target.IsDead)
                {
                    var pred = SpellsManager.W.GetPrediction(target);
                    SpellsManager.W.Cast(Functions.GrabWPost(true));
                    Core.DelayAction(() => SpellsManager.W.Cast(pred.CastPosition), 10);
                }

            if (ComboMenu["QE"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.QE.Range) && SpellsManager.E.IsReady())
                    if (sphere.CountEnemyMinionsInRange(300) >= 1)
                        SpellsManager.Q.Cast(target);
                    SpellsManager.E.Cast(target);


            //Cast r
            // if (Menus.ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            //   if (rtarget.IsValidTarget(SpellsManager.R.Range) && SpellsManager.R.IsReady())
            //      SpellsManager.R.TryToCast(SpellsManager.R.GetKillableHero(), Menus.ComboMenu);


            if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range) && !target.HasUndyingBuff() &&
                Prediction.Health.GetPrediction(target, SpellsManager.R.CastDelay) <=
                SpellsManager.RDamage(SpellSlot.R, target))
            {
                SpellsManager.R.Cast(target);
            }





        }
    }
}
    


