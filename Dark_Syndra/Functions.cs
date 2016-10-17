using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using EloBuddy.SDK.Menu.Values;

namespace Dark_Syndra
{
    internal class Functions
    {
        public static object QE { get; internal set; }

        public static Vector3 GrabWPost(bool onlyQ)
        {
            var sphere =
                ObjectManager.Get<Obj_AI_Base>().FirstOrDefault(a => a.Name == "Seed" && a.IsValid);
            if (sphere != null)
            {
                return sphere.Position;
            }
            if (Menus.ComboMenu["W"].Cast<CheckBox>().CurrentValue)
            { 
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.IsValidTarget(SpellsManager.W.Range) && m.IsEnemy);
                if (minion != null)
                {
                    return minion.Position;
                }
            }
            return new Vector3();
        }


    }
}