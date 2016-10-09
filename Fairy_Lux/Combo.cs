using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Fairy_Lux.Menus;

namespace Fairy_Lux
{
    internal static class Combo
    {
        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }

        public static void Execute()
        {

            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((target == null) || target.IsInvulnerable)
                return;

            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast E
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                    SpellsManager.E.Cast(target);
            if (myhero.HasBuff("Detonate"))
            {
                SpellsManager.E.Cast();
            }
            
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    var prediction = SpellsManager.Q.GetPrediction(target);
                    SpellsManager.Q.Cast(target);
                }

            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && rtarget.Health > rtarget.GetRealDamage())
                    if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                        Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                        SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                    {
                            var prediction = SpellsManager.R.GetPrediction(rtarget);
                            SpellsManager.R.Cast(rtarget);
                    }





        }

        /*public static void Execute8()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q2"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(qtarget, ComboMenu);


            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (ComboMenu["E2"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown)
                if (etarget.IsValidTarget(SpellsManager.E.Range+300) && SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(etarget, ComboMenu);


            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;

            if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown &&
                SpellsManager.E.IsOnCooldown)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                    Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                    SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    SpellsManager.R.Cast(rtarget);
                }
        }*/
    }
}



