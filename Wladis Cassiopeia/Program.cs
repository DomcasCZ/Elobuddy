using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;
using System.Linq;

namespace Wladis_Cassiopeia
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
            if (Player.Instance.Hero != Champion.Cassiopeia) return;
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();

            Obj_AI_Base.OnProcessSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                if (sender.IsMe && (int)args.Slot < 3)
                {
                    LockedSpellCasts = true;
                }
            };

            Obj_AI_Base.OnSpellCast += delegate (Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
            {
                if (sender.IsMe && (int)args.Slot < 3)
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

            Chat.Print("<font color='#FA5858'>Wladis Cassiopeia loaded</font>");
            Chat.Print("Credits to Hellsing and Ouija");
        }
        public static Item Zhonyas = new Item(ItemId.Zhonyas_Hourglass);
        public static Item Seraph = new Item(ItemId.Seraphs_Embrace);
        public static Item Solari = new Item(ItemId.Locket_of_the_Iron_Solari, 600);
        public static Item Face = new Item(ItemId.Face_of_the_Mountain, 600);

        public static List<Item> ItemList = new List<Item>
                  {
                     Zhonyas,
                     Seraph,
                     Solari,
                     Face
                 };

        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }
        public static Spell.Targeted Ignite = new Spell.Targeted(ReturnSlot("summonerdot"), 600);

        public static SpellSlot ReturnSlot(string Name)
        {
            return Player.Instance.GetSpellSlotFromName(Name);
        }

        public static string[] SmiteNames => new[]
{
            "s5_summonersmiteplayerganker", "s5_summonersmiteduel",
            "s5_summonersmitequick", "itemsmiteaoe", "summonersmite"
        };

        public static SpellSlot ReturnSlot(string[] Name)
        {
            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.ToLower()))
                return SpellSlot.Summoner1;

            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.ToLower()))
                return SpellSlot.Summoner2;

            return SpellSlot.Unknown;
        }
    }
}