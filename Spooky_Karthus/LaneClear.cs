using System;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Combo;

namespace Spooky_Karthus
{
    internal static class LaneClear
    {
        public static void Execute2()
        {

            //Cast Q
            if (Menus.LaneClearMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(SpellsManager.Q.GetBestCircularFarmPosition(), Menus.LaneClearMenu);


            if (Menus.LaneClearMenu["E"].Cast<CheckBox>().CurrentValue)
                if (myhero.HasBuff("Defile"))
                    return;
            if (SpellsManager.E.IsReady() && myhero.CountEnemyMinionsInRange(SpellsManager.E.Range) >= 3)
            {
                SpellsManager.E.Cast();
            }
            
            if (myhero.HasBuff("Defile") && SpellsManager.E.IsReady() && myhero.CountEnemyMinionsInRange(SpellsManager.E.Range) <= 2)
            {
                SpellsManager.E.Cast();
            }

        }
    }
}

