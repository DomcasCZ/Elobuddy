using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;
using static Fairy_Lux.Menus;
using static Fairy_Lux.SpellsManager;
using EloBuddy.SDK;
using System.Drawing;

namespace Fairy_Lux

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
            var target = TargetSelector.GetTarget(SpellsManager.R.Range, DamageType.Magical);

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

            if (DrawingsMenu.GetCheckBoxValue("rDraw") && readyDraw
                ? R.IsReady()
                : DrawingsMenu.GetCheckBoxValue("rDraw"))
                Circle.Draw(RColorSlide.GetSharpColor(), R.Range, 1f, Player.Instance);

            if (!(target.Health <=
      target.GetRealDamage(SpellSlot.R))) return;
            Drawing.DrawText(Drawing.WorldToScreen(target.Position).X - 60,
                Drawing.WorldToScreen(target.Position).Y + 10,
                Color.Gold, "Killable with Ult");
        }



        private static void Drawing_OnEndScene(EventArgs args)
        {
        }
    }

}