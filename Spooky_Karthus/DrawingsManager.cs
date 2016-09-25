using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;
using System.Drawing;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Spooky_Karthus.Menus;
using static Spooky_Karthus.SpellsManager;
using static Spooky_Karthus.Combo;

namespace Spooky_Karthus

{
    internal class DrawingsManager
    {
        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            DamageIndicator.Init();
        }




        private static void Drawing_OnDraw(EventArgs args)
        {
            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);
            var orbMode = Orbwalker.ActiveModesFlags;
            var readyDraw = DrawingsMenu.GetCheckBoxValue("readyDraw");
            //Drawings
            if (DrawingsMenu.GetCheckBoxValue("qDraw") && readyDraw
                ? Q.IsReady()
                : DrawingsMenu.GetCheckBoxValue("qDraw"))
                Circle.Draw(QColorSlide.GetSharpColor(), Q.Range, 1f, Player.Instance);

            if (DrawingsMenu.GetCheckBoxValue("wDraw") && readyDraw
                ? W.IsReady()
                : DrawingsMenu.GetCheckBoxValue("wDraw"))
                Circle.Draw(WColorSlide.GetSharpColor(), W.Range, 1f, Player.Instance);

            if (DrawingsMenu.GetCheckBoxValue("eDraw") && readyDraw
                ? E.IsReady()
                : DrawingsMenu.GetCheckBoxValue("eDraw"))
                Circle.Draw(EColorSlide.GetSharpColor(), E.Range, 1f, Player.Instance);

            if (RMenu["R"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget(SpellsManager.R.Range) &&
                    !orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && !rtarget.IsValidTarget(SpellsManager.Q.Range) &&
                    !rtarget.HasUndyingBuff() &&
                    Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                    SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 60,
                      Drawing.WorldToScreen(myhero.Position).Y + 10,
                      Color.Red, "Killsteal with R");
                }

            if (RMenu["R1"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget((SpellsManager.R.Range)) && !orbMode.HasFlag(Orbwalker.ActiveModes.Combo) && !rtarget.IsValidTarget(SpellsManager.Q.Range) && !rtarget.HasUndyingBuff() && rtarget.IsTargetableToTeam &&
                Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 60,
    Drawing.WorldToScreen(myhero.Position).Y + 10,
    Color.Gold, "Killable target with R");
                }

            if (RMenu["R2"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.R.IsReady() && rtarget.IsValidTarget((SpellsManager.R.Range)) && !rtarget.HasUndyingBuff() &&
                Prediction.Health.GetPrediction(rtarget, SpellsManager.R.CastDelay) <=
                SpellsManager.GetRealDamage(rtarget, SpellSlot.R))
                {
                    Drawing.DrawText(Drawing.WorldToScreen(myhero.Position).X - 60,
                        Drawing.WorldToScreen(myhero.Position).Y + 10,
                        Color.Gold, "Killable target with R");
                }



        }
        public static void DrawText(string msg, AIHeroClient Hero, Color color)
        {
            var wts = Drawing.WorldToScreen(Hero.Position);
            Drawing.DrawText(wts[0] - (msg.Length) * 5, wts[1], color, msg);
            var rtarget = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);
            var orbMode = Orbwalker.ActiveModesFlags;


        }



        private static void Drawing_OnEndScene(EventArgs args)
        {
        }
    }

}