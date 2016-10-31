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
                Player.Instance.ServerPosition, SpellsManager.Q.Range)
                                    .Last();
            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && SpellsManager.Q.IsInRange(minionq))
            {
                SpellsManager.Q.Cast(minionq);
            }

            if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && SpellsManager.Q.IsOnCooldown && 
                    myhero.CountEnemyMinionsInRange(SpellsManager.W.Range) >= LaneClearMenu["WX"].Cast<Slider>().CurrentValue)
            {
                Core.DelayAction(() => SpellsManager.W.Cast(), 200);
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
                        .FirstOrDefault(m => SpellsManager.Q.IsReady() && m.IsValidTarget((SpellsManager.Q.Range)) &&
                Prediction.Health.GetPrediction(m, SpellsManager.Q.CastDelay) <=
                SpellsManager.GetRealDamage(m, SpellSlot.Q));

            if (Menus.LastHitMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
            {
                SpellsManager.Q.Cast(minionq);
            }
            var minionw = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
          EntityManager.UnitTeam.Enemy,
          Player.Instance.ServerPosition, SpellsManager.W.Range)
         .FirstOrDefault(m => m.Health < SpellsManager.GetRealDamage(m, SpellSlot.W) && !(m.Health < SpellsManager.GetRealDamage(m, SpellSlot.Q)));

            if (Menus.LastHitMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && SpellsManager.Q.IsOnCooldown && minionw.IsValidTarget(SpellsManager.W.Range))
            {
                SpellsManager.W.Cast();
            }
            var minione = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
           EntityManager.UnitTeam.Enemy,
           Player.Instance.ServerPosition, SpellsManager.E.Range)
           .FirstOrDefault(m => m.Health < SpellsManager.GetRealDamage(m, SpellSlot.E));

            if (Menus.LastHitMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady())
            {
                SpellsManager.E.Cast(minione);
            }
        }
    }
}
