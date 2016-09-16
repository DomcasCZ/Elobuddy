using System.Drawing;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;
using static Spooky_Karthus.Combo;
using Color = System.Drawing.Color;

namespace Spooky_Karthus
{
    class Active
    {
        public static void Execute9()
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast R
            if (RMenu["R"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) && !orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && !rtarget.IsValidTarget(SpellsManager.Q.Range) && !rtarget.HasUndyingBuff() &&
                    Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    SpellsManager.R.TryToCast(rtarget, RMenu);
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 50,
                        Drawing.WorldToScreen(myhero.Position).Y + 10,
                        Color.Red, "Killsteal with R");
                }
        }

        public static void Execute10()
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast R
            if (RMenu["R1"].Cast<CheckBox>().CurrentValue) 
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget((SpellsManager.R.Range)) && !orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && !rtarget.IsValidTarget(SpellsManager.Q.Range) && !rtarget.HasUndyingBuff() && rtarget.IsTargetableToTeam &&
                Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    SpellsManager.R.TryToCast(rtarget, RMenu);
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 50,
    Drawing.WorldToScreen(myhero.Position).Y + 10,
    Color.Gold, "Killable target with R");
                }
        }

        public static void Execute11()
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

            if ((rtarget == null) || rtarget.IsInvulnerable)
                return;
            //Cast R
            if (RMenu["R2"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget((SpellsManager.R.Range)) && !orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && !rtarget.IsValidTarget(SpellsManager.Q.Range) && !rtarget.HasUndyingBuff() &&
                Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 50,
                        Drawing.WorldToScreen(myhero.Position).Y + 10,
                        Color.Gold, "Killable target with R");
                }
        }



    }
}
