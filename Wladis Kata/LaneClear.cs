using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

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
            var minionw = EntityManager.MinionsAndMonsters.Get(EntityManager.MinionsAndMonsters.EntityType.Minion,
    EntityManager.UnitTeam.Enemy,
    Player.Instance.ServerPosition, SpellsManager.W.Range)
                        .FirstOrDefault();

            if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && SpellsManager.W.IsInRange(minionw))
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

            if (Menus.LastHitMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
            {
                SpellsManager.Q.Cast(SpellsManager.Q.GetlastHitMinion());
            }

            if (Menus.LastHitMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady())
            {
                SpellsManager.W.Cast(SpellsManager.W.GetlastHitMinion());
            }

            if (Menus.LastHitMenu["E"].Cast<CheckBox>().CurrentValue && SpellsManager.E.IsReady())
            {
                SpellsManager.E.Cast(SpellsManager.E.GetlastHitMinion());
            }
        }
    }
}