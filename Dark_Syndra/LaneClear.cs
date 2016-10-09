using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using System.Linq;

namespace Dark_Syndra
{
    internal static class LaneClear
    {
        public static void Execute2()
        {
            var minions =
    EntityManager.MinionsAndMonsters.GetLaneMinions()
        .Where(
            m => m.IsValidTarget(SpellsManager.W.Range))
        .ToArray();
            if (minions.Length == 0) return;

            var farmLocation = Prediction.Position.PredictCircularMissileAoe(minions, SpellsManager.E.Range, SpellsManager.E.Width,
                SpellsManager.E.CastDelay, SpellsManager.E.Speed).OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length).FirstOrDefault();

            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady())
            {
                var predictedMinion = farmLocation.GetCollisionObjects<Obj_AI_Minion>();
                if (predictedMinion.Length >= 2)
                {
                    SpellsManager.Q.Cast(farmLocation.CastPosition);
                }
            }

                if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady())
            {
                var predictedMinion = farmLocation.GetCollisionObjects<Obj_AI_Minion>();
                if (predictedMinion.Length >= 2)
                {
                    SpellsManager.W.Cast(Functions.GrabWPost(true));
                        SpellsManager.W.Cast(farmLocation.CastPosition);

                }
            }


            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.E.IsReady())
                    SpellsManager.E.CastOnBestFarmPosition();

        }
    }
}
