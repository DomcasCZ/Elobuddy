using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;
using Color = System.Drawing.Color;
using static Spooky_Karthus.SpellsManager;

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
            var wtarget = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);

            if ((wtarget == null) || wtarget.IsInvulnerable)
                return;
            //Cast W
            if (ComboMenu["W"].Cast<CheckBox>().CurrentValue)
                if (wtarget.IsValidTarget(SpellsManager.W.Range) && SpellsManager.W.IsReady())
                    SpellsManager.W.TryToCast(wtarget, ComboMenu);

            var q1target = TargetSelector.GetTarget(SpellsManager.Q1.Range, DamageType.Magical);

            if ((q1target == null) || q1target.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q1"].Cast<CheckBox>().CurrentValue)
                if (q1target.IsValidTarget(SpellsManager.Q1.Range + 20) && SpellsManager.Q1.IsReady())
                    SpellsManager.Q1.GetPrediction(q1target);
            SpellsManager.Q1.TryToCast(q1target, ComboMenu);

            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (ComboMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range + 20) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.GetPrediction(qtarget);
            SpellsManager.Q.TryToCast(qtarget, ComboMenu);

            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;


            if (ComboMenu["E"].Cast<CheckBox>().CurrentValue)
                if (myhero.HasBuff("Defile")) return;
            if (SpellsManager.E.IsReady() && etarget.IsValidTarget(SpellsManager.E.Range))
            {
                SpellsManager.E.TryToCast(etarget, ComboMenu);
            }
            if (myhero.HasBuff("Defile") && SpellsManager.E.IsReady() && etarget.IsInvulnerable)
            {
                SpellsManager.E.Cast();
            }


        }
        private static bool BlockE;
        private static void OnBuffLoss(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (sender.IsMe && args.Buff.Name.Equals("Defile")) BlockE = false;
        }
        public static void OnCast(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            if (!sender.Owner.IsMe) return;

            if (args.Slot == SpellSlot.E && orbMode.HasFlag(Orbwalker.ActiveModes.Combo) &&
                orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && orbMode.HasFlag(Orbwalker.ActiveModes.Harass))
            {
                if (!BlockE)
                {
                    BlockE = true;
                }
                else
                {
                    args.Process = false;
                }
            }
        }

    }
}
