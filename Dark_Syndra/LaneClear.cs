using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using Vectors = T2IN1_Lib.Vectors;

namespace Dark_Syndra
{
    internal static class LaneClear
    {
        public static void Execute()
        {

            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(SpellsManager.Q.GetBestCircularFarmPosition(), Menus.LaneClearMenu);

            if (Menus.LaneClearMenu["W"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.W.IsReady() && SpellsManager.Q.IsOnCooldown)
                    SpellsManager.W.Cast(Functions.GrabWPost(true));
            SpellsManager.W.TryToCast(Vectors.GetBestCircularFarmPosition(SpellsManager.W), Menus.LaneClearMenu);

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(SpellsManager.E.GetBestCircularFarmPosition(), Menus.LaneClearMenu);

        }
    }
}
