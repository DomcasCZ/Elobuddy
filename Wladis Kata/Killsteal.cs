using EloBuddy;
using EloBuddy.SDK;
namespace Wladis_Kata
{
    class KillSteal
    {
        public static void Execute2()
        {
            var qtarget = TargetSelector.GetTarget(target.Q.Range, DamageType.Magical);
            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (target.Q.IsReady() && qtarget.IsValidTarget(target.Q.Range ) &&
                Prediction.Health.GetPrediction(qtarget, target.Q.CastDelay) <=
                target.GetRealDamage(qtarget, SpellSlot.Q))
            {
                target.Q.Cast(qtarget);
            }
        }

        public static void Execute3()
        {
            var wtarget = TargetSelector.GetTarget(target.W.Range, DamageType.Mixed);
            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast E
            if (target.W.IsReady() && wtarget.IsValidTarget((target.W.Range)) &&
                Prediction.Health.GetPrediction(wtarget, target.W.CastDelay) <=
                target.GetRealDamage(wtarget, SpellSlot.W))
            {
                target.W.Cast(wtarget);
            }
        }

        public static void Execute4()
        {
            var etarget = TargetSelector.GetTarget(target.E.Range, DamageType.Magical);
            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (target.E.IsReady() && etarget.IsValidTarget((target.E.Range)) &&
                Prediction.Health.GetPrediction(etarget, target.E.CastDelay) <=
                target.GetRealDamage(etarget, SpellSlot.E))
            {
                target.E.Cast(etarget);
            }
        }
        public static void Execute5()
        {
            var rtarget = TargetSelector.GetTarget(target.R.Range, DamageType.Mixed);
            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast R
            if (target.R.IsReady() && rtarget.IsValidTarget((target.R.Range)) &&
                Prediction.Health.GetPrediction(rtarget, target.R.CastDelay) <=
                target.GetRealDamage(rtarget, SpellSlot.R))
            {
                target.R.Cast(rtarget);
            }
        }
    }
}