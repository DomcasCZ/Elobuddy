﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Wladis_Kata.Menus;

namespace Wladis_Kata
{
    internal static class Combo
    {


        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }


        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    SpellsManager.Q.TryToCast(target, ComboMenu);
                }

            //Cast E
            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                {
                    SpellsManager.E.TryToCast(target, ComboMenu);
                }
            
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                {
                    SpellsManager.W.Cast();
                }

            //var R1 = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("R1"));
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
            if (ComboMenu["R1"].Cast<CheckBox>().CurrentValue)
            if (SpellsManager.R.IsReady() && target.IsValidTarget(275) && !target.HasUndyingBuff())
            {
                Orbwalker.DisableAttacking = true;
                    Orbwalker.DisableMovement = true;
                    SpellsManager.R.Cast();
                if (myhero.CountEnemiesInRange(500) >= 1)
                {
                            Orbwalker.DisableAttacking = true;
                            Orbwalker.DisableMovement = true;
                        }
            }
            

            if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range) && !target.HasUndyingBuff())
                {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
                        if (myhero.CountEnemiesInRange(500) >= 1)
                        {
                            Orbwalker.DisableAttacking = true;
                            Orbwalker.DisableMovement = true;
                        }
                    }

            if (ComboMenu["R3"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.W.Range) && !target.HasUndyingBuff())
                {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
                        if (myhero.CountEnemiesInRange(500) >= 1)
                        {
                            Orbwalker.DisableAttacking = true;
                            Orbwalker.DisableMovement = true;
                        }
                    }
            }
        }


    }
}