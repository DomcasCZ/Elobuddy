using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Dark_Syndra
{
    internal class Loader
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Syndra) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

            Chat.Print( "Dark Syndra Loaded!");
            Chat.Print("Credits to ExRaZor, T2N1Scar, Definitely not Kappa, gero, MarioGK, 2Phones");
        }
    }
}