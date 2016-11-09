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
            var DaggerFirst =
ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(a => a.Name == "HiddenMinion" && a.IsValid);

            var minionq = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
                EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, SpellsManager.Q.Range)
                                    .FirstOrDefault();
            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && minionq.IsValidTarget(SpellsManager.Q.Range))
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

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady() && !DaggerFirst.IsDead && DaggerFirst.CountEnemyMinionsInRange(400) >= 1 )
            {
                SpellsManager.E.Cast(DaggerFirst.Position);
            }

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady() && minione.IsValidTarget(SpellsManager.E.Range) && SpellsManager.Q.IsOnCooldown)
            {
                SpellsManager.E.Cast(minione);
            }

        }

        public static void Execute8()
        {
            //Cast Q
            var minionQ = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
                 EntityManager.UnitTeam.Enemy,
                  Player.Instance.ServerPosition, SpellsManager.Q.Range)
                        .FirstOrDefault(m => SpellsManager.Q.IsReady() && m.IsValidTarget(SpellsManager.Q.Range) &&
                Prediction.Health.GetPrediction(m, SpellsManager.Q.CastDelay) <=
                SpellsManager.GetRealDamage(m, SpellSlot.E));

            if (Menus.LaneClearMenu["QLastHit"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && minionQ.IsValidTarget(SpellsManager.Q.Range))
                  {
                    SpellsManager.Q.Cast(minionQ);
                }
                  var minionw = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
                EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, SpellsManager.W.Range)
               .FirstOrDefault();

                 var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
                EntityManager.UnitTeam.Enemy,
                Player.Instance.ServerPosition, SpellsManager.E.Range)
                .FirstOrDefault();

            if (Menus.LaneClearMenu["ELastHit"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady())
                /* if (SpellsManager.E.IsReady() && minione.IsValidTarget((SpellsManager.E.Range)) &&
                Prediction.Health.GetPrediction(minione, SpellsManager.E.CastDelay) <=
                SpellsManager.GetRealDamage(minione, SpellSlot.E))*/
                if (minione.Health < SpellsManager.GetRealDamage(minione, SpellSlot.E))
                {
                    SpellsManager.E.Cast(minione);
                }
        }
    }
}