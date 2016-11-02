using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Cassiopeia.Menus;
using static Wladis_Cassiopeia.Loader;
using static Wladis_Cassiopeia.ModeManager;
using System.Linq;

namespace Wladis_Cassiopeia
{
    internal static class Combo
    {
        // W > Q > E > R
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (SpellsManager.R.IsReady() && ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (!ComboMenu["ROnly"].Cast<CheckBox>().CurrentValue)
                {
                    if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.R.Cast(target), HumanizerMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                    else SpellsManager.R.Cast(target);
                }
            }

            if (SpellsManager.R.IsReady() && ComboMenu["R"].Cast<CheckBox>().CurrentValue && ComboMenu["ROnly"].Cast<CheckBox>().CurrentValue && !target.IsFleeing)
            {
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.R.Cast(target), HumanizerMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                else SpellsManager.R.Cast(target);
            }


            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
            {
                var prediction = SpellsManager.W.GetPrediction(target);
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.W.Cast(prediction.CastPosition), HumanizerMenu["HumanizeW"].Cast<Slider>().CurrentValue);
                else SpellsManager.W.Cast(prediction.CastPosition);
            }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && target.IsValidTarget(SpellsManager.Q.Range))
            {
                var prediction = SpellsManager.Q.GetPrediction(target);
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.Q.Cast(prediction.CastPosition), HumanizerMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                else SpellsManager.Q.Cast(prediction.CastPosition);
            }

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue && target.IsValidTarget(SpellsManager.E.Range))
            {
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizerMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                else SpellsManager.E.Cast(target);
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
        }




        // Combo  q w e r
        public static void Execute1()
        {
            var target = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((target == null) || target.IsInvulnerable)
                return;

            if (SpellsManager.R.IsReady() && ComboMenu["R"].Cast<CheckBox>().CurrentValue)
            {
                if (!ComboMenu["ROnly"].Cast<CheckBox>().CurrentValue)
                {
                    if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.R.Cast(target), HumanizerMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                    else SpellsManager.R.Cast(target);
                }
            }

            if (SpellsManager.R.IsReady() && ComboMenu["R"].Cast<CheckBox>().CurrentValue && ComboMenu["ROnly"].Cast<CheckBox>().CurrentValue && target.IsFacing(myhero))
            {
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.R.Cast(target), HumanizerMenu["HumanizeR"].Cast<Slider>().CurrentValue);
                else SpellsManager.R.Cast(target);
            }

            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue && SpellsManager.Q.IsReady() && target.IsValidTarget(SpellsManager.Q.Range))
            {
                var prediction = SpellsManager.Q.GetPrediction(target);
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.Q.Cast(prediction.CastPosition), HumanizerMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                else SpellsManager.Q.Cast(prediction.CastPosition);
            }

            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && target.IsValidTarget(SpellsManager.W.Range))
            {
                var prediction = SpellsManager.W.GetPrediction(target);
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.W.Cast(prediction.CastPosition), HumanizerMenu["HumanizeW"].Cast<Slider>().CurrentValue);
                else SpellsManager.W.Cast(prediction.CastPosition);
            }

            if (SpellsManager.E.IsReady() && ComboMenu["E"].Cast<CheckBox>().CurrentValue)
            {
                if (HumanizerMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.E.Cast(target), HumanizerMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                else SpellsManager.E.Cast(target);
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

        }

        public static void Execute11()
        {
            if (MiscMenu["Z"].Cast<CheckBox>().CurrentValue)
            {
                if (Player.Instance.IsDead) return;

                if ((Player.Instance.CountEnemiesInRange(700) >= 1) && Zhonyas.IsOwned() && Zhonyas.IsReady())
                    if (Player.Instance.HealthPercent <= MiscMenu["Zhealth"].Cast<Slider>().CurrentValue)
                        Zhonyas.Cast();
            }
        }
    }
}
    
