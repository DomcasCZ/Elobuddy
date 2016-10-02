using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Menus;
using static Wladis_Kata.Combo;

namespace Wladis_Kata
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Game.OnUpdate += Game_OnUpdate;
            Orbwalker.OnPreAttack += Orbwalker_PreAttack;
            Player.OnIssueOrder += Player_OnIssueOrder;
            //Spellbook.OnCastSpell += Spellbook_OnCastSpell;
        }
        public static float rStart;

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;
            
            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
                Harass.Execute1();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
                LaneClear.Execute10();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit))
                LaneClear.Execute8();

            if (HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue)
                Harass.Execute7();

            if (HarassMenu["AutoW"].Cast<CheckBox>().CurrentValue)
                Harass.Execute8();

            if (KillStealMenu["Q"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute2();

            if (KillStealMenu["W"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute3();

            if (KillStealMenu["E"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute4();

            if (KillStealMenu["R"].Cast<CheckBox>().CurrentValue)
                KillSteal.Execute5();

            if (MiscMenu["Z"].Cast<CheckBox>().CurrentValue)
                Combo.Execute6();
            
        }

        /*private static void Spellbook_OnCastSpell(Spellbook spellbook, SpellbookCastSpell spellbookCastSpellEventArgs)
        {
            if (sender.Owner.IsMe && Player.Instance.IsChannelling &&
                (args.Slot == SpellSlot.Q || args.Slot == SpellSlot.W || args.Slot == SpellSlot.E))
                args.Process = false;
        }*/
        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (sender.IsMe && Environment.TickCount < rStart + 300 && args.Order == GameObjectOrder.MoveTo)
            {
                args.Process = false;
            }
        }

        private static void Orbwalker_PreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (args.Target.IsMe)
            {
                args.Process = !myhero.HasBuff("KatarinaR");
            }
        }

        private static bool HasRBuff()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);
            return myhero.HasBuff("KatarinaR") || Player.Instance.Spellbook.IsChanneling ||
                   myhero.HasBuff("katarinarsound"); //|| target.HasBuff("Grevious") && sender.IsMe
        }
        

        private static void Game_OnUpdate(EventArgs args)
        {
            if (HasRBuff())
            {
                Orbwalker.DisableMovement = true;
                Orbwalker.DisableAttacking = true;
            }
            else
            {
                Orbwalker.DisableMovement = false;
                Orbwalker.DisableAttacking = false;
            }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) Execute();
        }
       

    }
}