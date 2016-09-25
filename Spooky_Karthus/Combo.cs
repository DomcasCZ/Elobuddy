using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;
using static Spooky_Karthus.ModeManager;

namespace Spooky_Karthus
{
    internal static class Combo
    {
        

        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }



        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((target == null) || target.IsInvulnerable)
                return;
            //Cast W
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                {
                    SpellsManager.W.TryToCast(target, ComboMenu);
                }
            
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range + 20) && SpellsManager.Q.IsReady())
            {
                var prediction = SpellsManager.Q.GetPrediction(target);
                    SpellsManager.Q.TryToCast(target, ComboMenu);
                }

            if (myhero.HasBuff("Defile")) return;
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
               if (SpellsManager.E.IsReady() && target.IsValidTarget(SpellsManager.E.Range))
            {
                SpellsManager.E.Cast();
            }

            if (SpellsManager.E.IsReady() && myhero.HasBuff("Defile") && myhero.CountEnemiesInRange(SpellsManager.E.Range) == 0)
            {
                SpellsManager.E.Cast();
                BlockE = false;
            }


        }


    }
}
