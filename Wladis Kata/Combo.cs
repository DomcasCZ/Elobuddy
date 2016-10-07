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


        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    SpellsManager.Q.Cast(target);
                }
            //Cast E
            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                    {
                if (!ComboMenu["El"].Cast<CheckBox>().CurrentValue || !Player.Instance.IsInAutoAttackRange(target))
                {
                    SpellsManager.E.Cast(target);
                }
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
                {
                    SpellsManager.W.Cast();
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
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (ComboMenu["R1"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(300) && target.HealthPercent <= ComboMenu["Rhealth"].Cast<Slider>().CurrentValue) 
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }


                if (ComboMenu["R2"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.R.Range) && target.HealthPercent <= ComboMenu["Rhealth"].Cast<Slider>().CurrentValue)
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }

                if (ComboMenu["R3"].Cast<CheckBox>().CurrentValue)
                    if (SpellsManager.R.IsReady() && target.IsValidTarget(SpellsManager.W.Range) && target.HealthPercent <= ComboMenu["Rhealth"].Cast<Slider>().CurrentValue)
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
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