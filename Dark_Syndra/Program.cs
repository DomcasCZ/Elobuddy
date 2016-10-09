using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using static Dark_Syndra.Menus;
using EloBuddy.SDK.Menu.Values;

namespace Dark_Syndra
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
            if (Player.Instance.Hero != Champion.Syndra) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            

            Obj_AI_Base.OnProcessSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                    if (sender.IsMe && (int)args.Slot < 4)
                    {
                        LockedSpellCasts = true;
                    }
            };

            Obj_AI_Base.OnSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                    if (sender.IsMe && (int)args.Slot < 4)
                    {
                        LockedSpellCasts = false;
                    }
            };

            Spellbook.OnCastSpell += delegate (Spellbook sender, SpellbookCastSpellEventArgs args)
            {
                    if (sender.Owner.IsMe && (int)args.Slot < 4 && Player.GetSpell(args.Slot).IsReady)
                    {
                        if (LockedSpellCasts)
                        {
                            args.Process = false;
                        }
                        else
                        {
                            LockedSpellCasts = true;
                        }

                    }
            };

            Game.OnTick += delegate
            {
                    if (_lockedTime > 0 && LockedSpellCasts && Core.GameTickCount - _lockedTime > 250)
                    {
                        LockedSpellCasts = false;
                    }
            };


            Chat.Print("<font color='#FA5858'>Wladis Syndra loaded</font>");
            Chat.Print("Credits to ExRaZor, T2N1Scar, Definitely not Kappa, gero, MarioGK, 2Phones");
        }
    }
}