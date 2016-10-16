using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Kata.Menus;

namespace Wladis_Kata
{
    internal static class Harass
    {
        public static void Execute1()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (Menus.HarassMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.Q.Cast(qtarget), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                    else SpellsManager.Q.Cast(qtarget);
                }

            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (Menus.HarassMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.W.Cast(), HumanizeMenu["HumanizeW"].Cast<Slider>().CurrentValue);
                    else SpellsManager.W.Cast();
                }

            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (Menus.HarassMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                {
                    if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                        Core.DelayAction(() => SpellsManager.E.Cast(etarget), HumanizeMenu["HumanizeE"].Cast<Slider>().CurrentValue);
                    else SpellsManager.E.Cast(etarget);
                }


        }

        public static void Execute7()
        {
            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;

                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
            {
                if (HumanizeMenu["Humanize"].Cast<CheckBox>().CurrentValue)
                    Core.DelayAction(() => SpellsManager.Q.Cast(qtarget), HumanizeMenu["HumanizeQ"].Cast<Slider>().CurrentValue);
                else SpellsManager.Q.Cast(qtarget);
            }
        }

        public static void Execute9()
        {
            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Mixed);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                SpellsManager.W.Cast(wtarget);
        }

    }
}