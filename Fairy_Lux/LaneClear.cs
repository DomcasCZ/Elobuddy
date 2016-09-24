using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Fairy_Lux.Combo;

namespace Fairy_Lux
{
    internal static class LaneClear
    {
        public static void Execute()
        {

            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(SpellsManager.Q.GetBestLinearFarmPosition(2), Menus.LaneClearMenu);

            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(SpellsManager.E.GetBestCircularFarmPosition(), Menus.LaneClearMenu);
            if (myhero.HasBuff("Detonate"))
            {
                SpellsManager.E.Cast();
            }

        }
    }
}