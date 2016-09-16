/*using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;

namespace Spooky_Karthus
{
    class KillSteal
    {
        public static void Execute2()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (SpellsManager.Q.IsReady() && qtarget.IsValidTarget((SpellsManager.Q.Range+10)) &&
                Prediction.Health.GetPrediction(qtarget, SpellsManager.Q.CastDelay) <=
                SpellsManager.GetRealDamage(qtarget, SpellSlot.Q))
            {
                SpellsManager.Q.TryToCast(qtarget, KillStealMenu);
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
                SpellsManager.E.TryToCast(etarget, KillStealMenu);
            }
        }

        }

    }
    */