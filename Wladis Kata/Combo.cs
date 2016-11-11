using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Menus;
using static Wladis_Kata.ModeManager;
using static Wladis_Kata.Extensions;
using static Wladis_Kata.Functions;
using System.Linq;

namespace Wladis_Kata
{
    internal static class Combo
    {
        // normal Combo Q E W
        public static void Execute20()
        {
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);
            var Enemy = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(SpellsManager.E.Range) && x.IsValid);

            var minion = EntityManager.MinionsAndMonsters.GetLaneMinions().Where(m => m.IsValidTarget(SpellsManager.Q.Range)).OrderBy(m => m.Distance(Enemy) > 450).FirstOrDefault();

            var DaggerFirst = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(a => a.Name == "HiddenMinion" && a.IsValid);


            if ((target == null) || target.IsInvulnerable)
                return;
            
            // Q on minion
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue && minion.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady() && !target.IsInRange(myhero, SpellsManager.Q.Range) && ComboMenu["QMinion"].Cast<CheckBox>().CurrentValue)
                {
                     SpellsManager.Q.Cast(minion);
                }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(target);
                }
            //Cast E on dagger
            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && DaggerFirst.CountEnemiesInRange( 400 ) >= 1 && !DaggerFirst.IsDead)
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(DaggerFirst.Position), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                    else SpellsManager.E.Cast(DaggerFirst.Position);
                }

            // Cast E on target

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && (SpellsManager.Q.IsOnCooldown || !target.IsInRange(myhero, SpellsManager.Q.Range) && target.Distance(myhero) > 250 && ComboMenu["EDagger"].Cast<CheckBox>().CurrentValue == false && target.IsValidTarget(SpellsManager.E.Range)))
                // Cast E on enemy first, when dagger was collecte
                if (!Enemy.IsInRange(DaggerFirst, 400) || DaggerFirst.IsDead || !DaggerFirst.IsVisible) 
            {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                else SpellsManager.E.Cast(target);
            }


            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && myhero.IsInAutoAttackRange(target))
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
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ.IsValidTarget(Ignite.Range) && target.HealthPercent <= ComboMenu["IgniteHealth"].Cast<Slider>().CurrentValue)
                    if (target.Health >
                  target.GetRealDamage())
                        Ignite.Cast(Summ);

            //var R1 = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("R1"));
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                    if (SpellsManager.R.IsReady() && myhero.CountEnemiesInRange(ComboMenu["RSlider"].Cast<Slider>().CurrentValue) >= 1)
                    {
                        Orbwalker.DisableAttacking = true;
                        Orbwalker.DisableMovement = true;
                        SpellsManager.R.Cast();
                        rStart = Environment.TickCount;
                    }
            }


        }
        // AutoKill COmbo
        public static void Execute11()
        {
            var Enemy = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(SpellsManager.E.Range) && x.IsValid);

            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);

            if ((target == null) || target.IsInvulnerable)
                return;

            var DaggerFirst = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(a => a.Name == "HiddenMinion" && a.IsValid);

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(target);
                }
            //Cast E on dagger
            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && DaggerFirst.CountEnemiesInRange(400) >= 1 && !DaggerFirst.IsDead)
            {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.E.Cast(DaggerFirst.Position), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                else SpellsManager.E.Cast(DaggerFirst.Position);
            }

            // Cast E on target

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && (SpellsManager.Q.IsOnCooldown || !target.IsInRange(myhero, SpellsManager.Q.Range) && target.Distance(myhero) > 150 && ComboMenu["EDagger"].Cast<CheckBox>().CurrentValue == false && target.IsValidTarget(SpellsManager.E.Range)))
                // Cast E on enemy first, when dagger was collecte
                if (/*myhero.HasBuff("KatarinaWhaste") || */!Enemy.IsInRange(DaggerFirst, 400) || DaggerFirst.IsDead || !DaggerFirst.IsVisible)
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                    else SpellsManager.E.Cast(target);
                }


            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && myhero.IsInAutoAttackRange(target))
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
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ.IsValidTarget(Ignite.Range) && target.HealthPercent <= ComboMenu["IgniteHealth"].Cast<Slider>().CurrentValue)
                    if (target.Health >
                  target.GetRealDamage())
                        Ignite.Cast(Summ);

            //var R1 = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("R1"));
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                if (SpellsManager.R.IsReady() && myhero.CountEnemiesInRange(ComboMenu["RSlider"].Cast<Slider>().CurrentValue) >= 1)
                {
                    Orbwalker.DisableAttacking = true;
                    Orbwalker.DisableMovement = true;
                    SpellsManager.R.Cast();
                    rStart = Environment.TickCount;
                }
            }

        }
        // Combo  E Q W
        public static void Execute12()
        {
            var Enemy = EntityManager.Heroes.Enemies.FirstOrDefault(x => x.IsValidTarget(SpellsManager.E.Range) && x.IsValid);
            var target = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Mixed);
            var DaggerFirst = ObjectManager.Get<Obj_AI_Minion>().FirstOrDefault(a => a.Name == "HiddenMinion" && a.IsValid);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && DaggerFirst.CountEnemiesInRange(400) >= 1 && !DaggerFirst.IsDead)
            {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.E.Cast(DaggerFirst.Position), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                else SpellsManager.E.Cast(DaggerFirst.Position);
            }

            // Cast E on target

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && (SpellsManager.Q.IsOnCooldown || !target.IsInRange(myhero, SpellsManager.Q.Range) && target.Distance(myhero) > 150 && ComboMenu["EDagger"].Cast<CheckBox>().CurrentValue == false && target.IsValidTarget(SpellsManager.E.Range)))
                // Cast E on enemy first, when dagger was collecte
                if (/*myhero.HasBuff("KatarinaWhaste") || */!Enemy.IsInRange(DaggerFirst, 400) || DaggerFirst.IsDead || !DaggerFirst.IsVisible)
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                    else SpellsManager.E.Cast(target);
                }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (target.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(target), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(target);
                }


            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && myhero.IsInAutoAttackRange(target))
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
                if (Player.Instance.CountEnemiesInRange(600) >= 1 && Ignite.IsReady() && Ignite.IsLearned && Summ.IsValidTarget(Ignite.Range) && target.HealthPercent <= ComboMenu["IgniteHealth"].Cast<Slider>().CurrentValue)
                    if (target.Health >
                  target.GetRealDamage())
                        Ignite.Cast(Summ);

            //var R1 = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("R1"));
            if (ComboMenu["R"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsOnCooldown && SpellsManager.W.IsOnCooldown && SpellsManager.E.IsOnCooldown)
            {
                if (SpellsManager.R.IsReady() && myhero.CountEnemiesInRange(ComboMenu["RSlider"].Cast<Slider>().CurrentValue) >= 1)
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
    }
}