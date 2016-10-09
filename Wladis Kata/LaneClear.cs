using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Combo;
using static Wladis_Kata.Menus;

namespace Wladis_Kata
{
    internal static class LaneClear
    {
        public static void Execute10()
        {
            var minionq = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
                EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, target.Q.Range)
                                    .FirstOrDefault();
            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && target.Q.IsReady() && target.Q.IsInRange(minionq))
            {
                target.Q.Cast(minionq);
            }

            if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && target.W.IsReady() &&
                    myhero.CountEnemyMinionsInRange(target.W.Range) >= LaneClearMenu["WX"].Cast<Slider>().CurrentValue)
            {
                target.W.Cast();
            }
            var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, target.E.Range)
            .FirstOrDefault();

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && target.E.IsReady() && target.E.IsInRange(minione))
            {
                target.E.Cast(minione);
            }

        }

        public static void Execute8()
        {
            //Cast Q
            var minionq = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
    EntityManager.UnitTeam.Enemy,
    Player.Instance.ServerPosition, target.Q.Range)
                        .FirstOrDefault();

            if (Menus.LastHitMenu["Q"].Cast<CheckBox>().CurrentValue && target.Q.IsReady())
                if (target.Q.IsReady() && minionq.IsValidTarget(target.Q.Range) &&
    Prediction.Health.GetPrediction(minionq, target.Q.CastDelay) <=
    target.GetRealDamage(minionq, SpellSlot.Q))
                {
                    target.Q.Cast(minionq);
                }
            var minionw = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, target.W.Range)
            .FirstOrDefault();

            if (Menus.LastHitMenu["W"].Cast<CheckBox>().CurrentValue && target.W.IsReady())
                if (target.W.IsReady() && minionw.IsValidTarget((target.W.Range)) &&
    Prediction.Health.GetPrediction(minionw, target.W.CastDelay) <=
    target.GetRealDamage(minionw, SpellSlot.W))
                {
                    target.W.Cast();
                }
            var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, target.E.Range)
.FirstOrDefault();

            if (Menus.LastHitMenu["E"].Cast<CheckBox>().CurrentValue && target.E.IsReady())
                if (target.E.IsReady() && minione.IsValidTarget((target.E.Range)) &&
    Prediction.Health.GetPrediction(minione, target.E.CastDelay) <=
    target.GetRealDamage(minione, SpellSlot.E))
                {
                    target.E.Cast(minione);
                }
        }
    }
}