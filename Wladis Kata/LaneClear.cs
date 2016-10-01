using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
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
                Player.Instance.ServerPosition, SpellsManager.Q.Range)
                                    .FirstOrDefault();
            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && SpellsManager.Q.IsInRange(minionq))
            {
                SpellsManager.Q.Cast(minionq);
            }

            if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() &&
                    myhero.CountEnemyMinionsInRange(SpellsManager.W.Range) >= LaneClearMenu["WX"].Cast<Slider>().CurrentValue)
            {
                SpellsManager.W.Cast();
            }
            var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, SpellsManager.E.Range)
            .FirstOrDefault();

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady() && SpellsManager.E.IsInRange(minione))
            {
                SpellsManager.E.Cast(minione);
            }

        }

        public static void Execute8()
        {
            //Cast Q
            var minionq = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
    EntityManager.UnitTeam.Enemy,
    Player.Instance.ServerPosition, SpellsManager.Q.Range)
                        .FirstOrDefault();

            if (Menus.LastHitMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
                if (SpellsManager.Q.IsReady() && minionq.IsValidTarget(SpellsManager.Q.Range) &&
    Prediction.Health.GetPrediction(minionq, SpellsManager.Q.CastDelay) <=
    SpellsManager.GetRealDamage(minionq, SpellSlot.Q))
                {
                    SpellsManager.Q.Cast(minionq);
                }
            var minionw = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, SpellsManager.W.Range)
            .FirstOrDefault();

            if (Menus.LastHitMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady())
                if (SpellsManager.W.IsReady() && minionw.IsValidTarget((SpellsManager.W.Range)) &&
    Prediction.Health.GetPrediction(minionw, SpellsManager.W.CastDelay) <=
    SpellsManager.GetRealDamage(minionw, SpellSlot.W))
                {
                    SpellsManager.W.Cast();
                }
            var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
EntityManager.UnitTeam.Enemy,
Player.Instance.ServerPosition, SpellsManager.E.Range)
.FirstOrDefault();

            if (Menus.LastHitMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady())
                if (SpellsManager.E.IsReady() && minione.IsValidTarget((SpellsManager.E.Range)) &&
    Prediction.Health.GetPrediction(minione, SpellsManager.E.CastDelay) <=
    SpellsManager.GetRealDamage(minione, SpellSlot.E))
                {
                    SpellsManager.E.Cast(minione);
                }
        }
    }
}