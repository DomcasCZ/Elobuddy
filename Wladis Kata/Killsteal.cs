using EloBuddy;
using EloBuddy.SDK;
namespace Wladis_Kata
{
    class KillSteal
    {
        public static void Execute2()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);
            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (SpellsManager.Q.IsReady() && qtarget.IsValidTarget(SpellsManager.Q.Range ) &&
                Prediction.Health.GetPrediction(qtarget, SpellsManager.Q.CastDelay) <=
                SpellsManager.GetRealDamage(qtarget, SpellSlot.Q))
            {
                SpellsManager.Q.Cast(qtarget);
            }
        }

        public static void Execute3()
        {
            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Mixed);
            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast E
            if (SpellsManager.W.IsReady() && wtarget.IsValidTarget((SpellsManager.W.Range)) &&
                Prediction.Health.GetPrediction(wtarget, SpellsManager.W.CastDelay) <=
                SpellsManager.GetRealDamage(wtarget, SpellSlot.W))
            {
                SpellsManager.W.Cast();
            }
        }

        public static void Execute4()
        {
            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);
            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (SpellsManager.E.IsReady() && etarget.IsValidTarget((SpellsManager.E.Range)) &&
                Prediction.Health.GetPrediction(etarget, SpellsManager.E.CastDelay) <=
                SpellsManager.GetRealDamage(etarget, SpellSlot.E))
            {
                SpellsManager.E.Cast(etarget);
            }
        }
    }
}