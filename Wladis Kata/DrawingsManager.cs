using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;
using System.Drawing;
using EloBuddy.SDK;
using static Wladis_Kata.Menus;
using static Wladis_Kata.SpellsManager;

namespace Wladis_Kata

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
            var readyDraw = DrawingsMenu.GetCheckBoxValue("readyDraw");
            var target = TargetSelector.GetTarget(SpellsManager.E.Range+20000, DamageType.Mixed);
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

            if (DrawingsMenu.GetCheckBoxValue("rDraw"))
                DrawingsMenu.GetCheckBoxValue("rDraw");
                Circle.Draw(EColorSlide.GetSharpColor(), R.Range, 1f, Player.Instance);

            if (!(target.Health <=
                  target.GetRealDamage())) return;
            Drawing.DrawText(Drawing.WorldToScreen(target.Position).X - 60,
                Drawing.WorldToScreen(target.Position).Y + 10,
                Color.Gold, "Killable with Combo");
        }
        public static void DrawText(string msg, AIHeroClient Hero, Color color)
        {
            var wts = Drawing.WorldToScreen(Hero.Position);
            Drawing.DrawText(wts[0] - (msg.Length) * 5, wts[1], color, msg);


        }



        private static void Drawing_OnEndScene(EventArgs args)
        {
        }
    }

}