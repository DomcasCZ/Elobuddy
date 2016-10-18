using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static Wladis_Kata.Menus;
using EloBuddy.SDK.Menu.Values;

namespace Wladis_Kata
{
    internal class Loader
    {
        private static bool _lockedSpellcasts;

        public static bool LockedSpellCasts
        {
            get { return _lockedSpellcasts; }
            set
            {
                _lockedSpellcasts = value;
                if (value)
                {
                    _lockedTime = Core.GameTickCount;
                }
            }
        }

        private static int _lockedTime;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs bla)
        {
            if (Player.Instance.Hero != Champion.Katarina) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

                Obj_AI_Base.OnProcessSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
                {
                        if (sender.IsMe && (int)args.Slot == 3 && (int)args.Slot == 0)
                    {
                        LockedSpellCasts = true;
                    }
                };

            Obj_AI_Base.OnSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                    if (sender.IsMe && (int)args.Slot == 3 && (int)args.Slot == 0)
                    {
                        LockedSpellCasts = false;
                    }
            };
                Game.OnTick += delegate
                {
                        if (_lockedTime > 0 && LockedSpellCasts && Core.GameTickCount - _lockedTime > 250)
                    {
                        LockedSpellCasts = false;
                    }
                };
            
                Chat.Print("<font color='#FA5858'>Wladis Kata loaded</font>");
            Chat.Print("Credits to Tarakan and Hellsing");
        }
    }
}
