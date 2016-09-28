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
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Orbwalker.OnPreAttack += Orbwalker_PreAttack;
        }

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
                LaneClear.Execute10();

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
            
        }
        private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
            {
                if (args.Slot == SpellSlot.R)
                {
                    Orbwalker.DisableMovement = true;
                    Orbwalker.DisableAttacking = true;
                    Core.DelayAction(() => Orbwalker.DisableMovement = false, 1550);
                }
            }
        }

        private static void Orbwalker_PreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (args.Target.IsMe)
            {
                args.Process = !myhero.HasBuff("KataRbuff");
            }
        }

        private static bool DeathLotus()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);
            return myhero.HasBuff("KataRbuff") || Player.Instance.Spellbook.IsChanneling ||
                   myhero.HasBuff("katarinarsound"); //|| target.HasBuff("Grevious") && sender.IsMe
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (DeathLotus())
            {
                Orbwalker.DisableMovement = true;
                Orbwalker.DisableAttacking = true;
            }
            else
            {
                Orbwalker.DisableMovement = false;
                Orbwalker.DisableAttacking = false;
            }
        }

    }
}