using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace Spooky_Karthus
{
    internal class Loader
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Karthus) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

            Chat.Print("<font color='#0040FF'>Spooky Karthus loaded!</font><font color='#0B7D0B'>");
            Chat.Print("Credits to ExRaZor, T2N1Scar, 2Phones and Toyota7");
        }
    }
}