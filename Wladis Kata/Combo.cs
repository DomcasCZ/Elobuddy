using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Menus;
using static Wladis_Kata.ModeManager;
using static Wladis_Kata.Extensions;
using System.Linq;

namespace Wladis_Kata
{
    internal static class Combo
    {

        // normal Combo Q E W
        public static void Execute20()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(target);
                }
            //Cast E
            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                    {
                if (!ComboMenu["El"].Cast<CheckBox>().CurrentValue || !Player.Instance.IsInAutoAttackRange(target))
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                    else SpellsManager.E.Cast(target);
                }
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.W.Cast(), HumanizeMenu["HumanizeW"].Cast<Slider>().CurrentValue);
                    else SpellsManager.W.Cast();
                }

            var Summ = TargetSelector.GetTarget(Ignite.Range, DamageType.Mixed);

            if ((Summ == null) || Summ.IsInvulnerable)
                return;
            //Ignite
            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ.IsValidTarget(Ignite.Range))
                    if (target.Health >
                  target.GetRealDamage())
                        Ignite.Cast(Summ);
            
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                if (ComboMenu["R1"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(300))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }


                if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }

                if (ComboMenu["R3"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }
            }


        }
        // AutoKill COmbo
        public static void Execute11()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;
            
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
               else SpellsManager.Q.Cast(target);
                }
            //Cast E
            if (SpellsManager.E.IsReady())
            {
                if (!ComboMenu["El"].Cast<CheckBox>().CurrentValue || !Player.Instance.IsInAutoAttackRange(target))
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                   else SpellsManager.E.Cast(target);
                }
            }
            
                if (SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.W.Cast(), HumanizeMenu["HumanizeW"].Cast<Slider>().CurrentValue);
                else SpellsManager.W.Cast();
                }


            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                if (ComboMenu["R1"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(300))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }


                if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }

                if (ComboMenu["R3"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }
            }

        }
        // Combo  E Q W
        public static void Execute12()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;
            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (!ComboMenu["El"].Cast<CheckBox>().CurrentValue || !Player.Instance.IsInAutoAttackRange(target))
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                   else SpellsManager.E.Cast(target);
                }
            }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(target);
                }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.W.Cast(), HumanizeMenu["HumanizerW"].Cast<Slider>().CurrentValue);
                   else SpellsManager.W.Cast();
                }

            var Summ = TargetSelector.GetTarget(Ignite.Range, DamageType.Mixed);

            if ((Summ == null) || Summ.IsInvulnerable)
                return;
            //Ignite
            if (ComboMenu["Ignite"].Cast<CheckBox>().CurrentValue)
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ.IsValidTarget(Ignite.Range) && target.HealthPercent <= ComboMenu["IgniteHealth"].Cast<Slider>().CurrentValue)
                    if (target.Health >
                  target.GetRealDamage())
                        Ignite.Cast(Summ);

            //var R1 = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("R1"));
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                if (ComboMenu["R1"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(300))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }


                if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }

                if (ComboMenu["R3"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                            Core.DelayAction(() => SpellsManager.R.Cast(), HumanizeMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                        else SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }
            }

        }

        public static void Execute6()
        {
            if (MiscMenu["Z"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(700) >= 1) && Zhonyas.IsOwned() && Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= MiscMenu["Zhealth"].Cast<Slider>().CurrentValue)
                        Zhonyas.Cast();
            }
        }
        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }
        public static Spell.Targeted Ignite = new Spell.Targeted(ReturnSlot("summonerdot"), 600);

        public static SpellSlot ReturnSlot(string Name)
        {
            return Player.Instance.GetSpellSlotFromName(Name);
        }

        public static string[] SmiteNames => new[]
{
            "s5_summonersmiteplayerganker", "s5_summonersmiteduel",
            "s5_summonersmitequick", "itemsmiteaoe", "summonersmite"
        };

        public static SpellSlot ReturnSlot(string[] Name)
        {
            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.ToLower()))
                return SpellSlot.Summoner1;

            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.ToLower()))
                return SpellSlot.Summoner2;

            return SpellSlot.Unknown;
        }
    }
}