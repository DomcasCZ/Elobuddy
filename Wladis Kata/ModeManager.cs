using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Menus;
using static Wladis_Kata.Combo;
using static Wladis_Kata.Loader;

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
            Spellbook.OnCastSpell += Spellbook_OnCastSpell;
        }
        public static float rStart;

        private static bool HasRBuff()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);
            return myhero.HasBuff("KatarinaR") || Player.Instance.Spellbook.IsChanneling ||
                   myhero.HasBuff("katarinarsound"); //|| target.HasBuff("Grevious") && sender.IsMe
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (ComboMenu["ComboLogic"].Cast<ComboBox>().CurrentValue == 0))
                Execute20();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && (ComboMenu["ComboLogic"].Cast<ComboBox>().CurrentValue == 1))
                Execute12();

            if (ComboMenu["AutoKill"].Cast<CheckBox>().CurrentValue)
                if (target.CountAlliesInRange(450) <= ComboMenu["AutoKillenemysinrange"].Cast<Slider>().CurrentValue)
                    if (target.Health <= target.GetRealDamage()) 
                           Execute11();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
                Harass.Execute1();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
                LaneClear.Execute10();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit))
                LaneClear.Execute8();

            if (HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue)
                Harass.Execute7();

            if (HarassMenu["PokeHarass"].Cast<KeyBind>().CurrentValue)
                Harass.PokeHarass();

            if (KillStealMenu["Q"].Cast<CheckBox>().CurrentValue && !(HasRBuff()))
                KillSteal.Execute2();

            if (KillStealMenu["W"].Cast<CheckBox>().CurrentValue && !(HasRBuff()))
                KillSteal.Execute3();

            if (KillStealMenu["E"].Cast<CheckBox>().CurrentValue && !(HasRBuff()))
                KillSteal.Execute4();

            if (MiscMenu["Z"].Cast<CheckBox>().CurrentValue)
                Execute6();


        }
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
        
        private static void Spellbook_OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            var target = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (ComboMenu["Rblock"].Cast<CheckBox>().CurrentValue)
                if (sender.Owner.IsMe && Player.Instance.Spellbook.IsChanneling &&
                    (args.Slot == SpellSlot.Q || args.Slot == SpellSlot.W || args.Slot == SpellSlot.E))
                    args.Process = false;
            if (target.Distance(myhero) < SpellsManager.R.Range) args.Process = true;

            if (ComboMenu["Rblock"].Cast<CheckBox>().CurrentValue && ComboMenu["Rendblock"].Cast<CheckBox>().CurrentValue)
                if (sender.Owner.IsMe && Player.Instance.Spellbook.IsChanneling &&
                (args.Slot == SpellSlot.Q || args.Slot == SpellSlot.W || args.Slot == SpellSlot.E))
                    args.Process = false;
            if (SpellsManager.Q.IsReady() && SpellsManager.W.IsReady() && SpellsManager.E.IsReady()) args.Process = true;
            else if (target.Distance(myhero) < SpellsManager.R.Range) args.Process = true;


            if (sender.Owner.IsMe && (int)args.Slot == 3 && Player.GetSpell(args.Slot).IsReady)
                {
                    if (LockedSpellCasts)
                    {
                        args.Process = false;
                    }
                    else
                    {
                        LockedSpellCasts = true;
                    }
                }
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
        }
       

    }
}