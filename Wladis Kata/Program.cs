using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Wladis_Kata
{
    internal class Loader
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Katarina) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

            Chat.Print("Wladis Kata Loaded!");
            Chat.Print("Credits to ExRaZor and T2N1Scar");
        }
    }
}