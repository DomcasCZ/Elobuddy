using System;
using System.Linq;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;
using PetBuddy.Properties;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable PossibleLossOfFraction

namespace PetBuddy
{
    internal class Program
    {
        #region Images
        private static Sprite PetLevel1Sprite;
        private static Sprite PetLevel2Sprite;
        private static Sprite PetLevel5_MarksmanSprite;
        private static Sprite PetLevel10_MarksmanSprite;
        private static Sprite PetLevel15_MarksmanSprite;
        private static Sprite PetLevel20_MarksmanSprite;
        #endregion Images

        public static AIHeroClient myhero
        {
            get { return ObjectManager.Player; }
        }

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        
        public static readonly TextureLoader TextureLoader = new TextureLoader();

        
        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            /*var Bot = Bots();
            if (Bot)
            {
                Chat.Print("PetBuddy disabled for Bots!");
                return;
            }*/
            

            Chat.Print("PetBuddy", System.Drawing.Color.Red);

            PetBuddy.Menus.CreateMenu();
            //Game.OnNotify += Game_OnNotify;
            //Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnTick += Game_OnTick;
            Game.OnUpdate += Pet.Game_OnUpdate;
            Game.OnNotify += Pet.OnGameNotify;
            
        }


        private static void Game_OnTick(EventArgs args)
        {
            #region Images
            switch (Pet.Lvl)
            {
                case 1:
            if (Pet.Lvl == 1)
            {
                TextureLoader.Load("PetLevel1", Resources.Level1);
                PetLevel1Sprite = new Sprite(() => TextureLoader["PetLevel1"]);
            }
                    break;
                case 2:
            if (Pet.Lvl >= 2 && Pet.Lvl < 5)
            {
                PetLevel2Sprite = new Sprite(() => TextureLoader["PetLevel2"]);
                TextureLoader.Load("PetLevel2", Resources.Level2);
            }
                    break;
                case 3:
            if (Pet.Lvl >= 5 && Pet.Lvl < 10 && Menus.PetMenu["Marksman"].Cast<CheckBox>().CurrentValue)
            {
                TextureLoader.Load("PetLevel5_Marksman", Resources.Lvl5___Marksman);
                PetLevel5_MarksmanSprite = new Sprite(() => TextureLoader["PetLevel5_Marksman"]);
            }
                    break;
                case 4:
            if (Pet.Lvl >= 10 && Pet.Lvl < 15 && Menus.PetMenu["Marksman"].Cast<CheckBox>().CurrentValue)
            {
                TextureLoader.Load("PetLevel10_Marksman", Resources.Lvl10___Marksman);
                PetLevel10_MarksmanSprite = new Sprite(() => TextureLoader["PetLevel10_Marksman"]);
            }
                    break;
                case 5:
            if (Pet.Lvl >= 15 && Pet.Lvl < 20 && Menus.PetMenu["Marksman"].Cast<CheckBox>().CurrentValue)
            {
                TextureLoader.Load("PetLevel15_Marksman", Resources.Lvl15___Marksman);
                PetLevel15_MarksmanSprite = new Sprite(() => TextureLoader["PetLevel15_Marksman"]);
            }
                    break;
                case 6:
            if (Pet.Lvl >= 20 && Menus.PetMenu["Marksman"].Cast<CheckBox>().CurrentValue)
            {
                TextureLoader.Load("PetLevel20_Marksman", Resources.Lvl20___Marksman);
                PetLevel20_MarksmanSprite = new Sprite(() => TextureLoader["PetLevel20_Marksman"]);
            }
                    break;
        }
            
            #endregion Images
            
            var minion = EntityManager.MinionsAndMonsters.EnemyMinions.FirstOrDefault(x => x.IsValidTarget(600) && x.VisibleOnScreen);
                if (minion.IsDead)
                    Pet.CurXP += (1);

            var a = Menus.PetMenu.Add("Warrior", new CheckBox("Warrior", false));
            var b = Menus.PetMenu.Add("Marksman", new CheckBox("Marksman", false));
            var c = Menus.PetMenu.Add("Ninja", new CheckBox("Ninja", false));
            var d = Menus.PetMenu.Add("Mage", new CheckBox("Mage", false));

            if (a.CurrentValue == true)
            {
                b.Remove(b);
                c.Remove(c);
                d.Remove(d);
            }
            if (b.CurrentValue == true)
            {
                c.Remove(c);
                a.Remove(a);
                d.Remove(d);
            }
            if (c.CurrentValue == true)
            {
                b.Remove(b);
                a.Remove(a);
                d.Remove(d);
            }
            if (d.CurrentValue == true)
            {
                b.Remove(b);
                a.Remove(a);
                c.Remove(c);
            }
        }
        /*
        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnChampionPentaKill)
            {
                OhMyGodSound.Play();
            }

            if (args.EventId == GameEventId.OnAce)
            {
                WOWSound.Play();
            }

            if (args.EventId == GameEventId.OnFirstBlood)
            {
                FuckSound.Play();
                CanDrawBrazzerSprite = true;
                Core.DelayAction(() => CanDrawBrazzerSprite = false, 1500);
            }
        }

        private static void Obj_AI_Base_OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (sender.IsMe && args.Animation.Equals("Death"))
            {
                SadMusicSound.Play();
            }
        }*/

        private static void Drawing_OnDraw(EventArgs args)
        {

                var pos = new Vector2(1700, 130);
            if (Menus.SettingsMenu["PetVisible"].Cast<CheckBox>().CurrentValue)
            {
                PetLevel1Sprite.Draw(pos);
                var xpos = 1750;
                var ypos = 320;
                Drawing.DrawText(xpos, ypos + 20, System.Drawing.Color.Gold, "Pet Name: " + Pet.PetName);
                Drawing.DrawText(xpos, ypos + 40, System.Drawing.Color.Gold, "Level: " + Pet.Lvl);
                Drawing.DrawText(xpos, ypos + 60, System.Drawing.Color.Gold, "XP: " + Pet.CurXP + "/" + Pet.MaxXP);
                Drawing.DrawText(xpos, ypos + 80, System.Drawing.Color.Gold, "Damage: " + Pet.Dmg);
                Drawing.DrawText(xpos, ypos + 100, System.Drawing.Color.Gold, "Hp: " + Pet.Hp);
            }

        }


        /*private static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            var hero = sender as AIHeroClient;
            if (hero == null) return;

            var herospell = DunkSpells.Spells.FirstOrDefault(x => x.Hero == Player.Instance.Hero && x.Slot == args.Slot);
            if (hero.IsMe && herospell != null && args.Target.IsEnemy)
            {
                DunkSound.Play();
            }

            var heroakbar = AkbarSpells.Spells.FirstOrDefault(x => x.Hero == Player.Instance.Hero && x.Slot == args.Slot);
            if (hero.IsMe && heroakbar != null && args.Target.IsEnemy)
            {
                AkbarSound.Play();
            }
        }*/

        public static bool Bots()
        {
            var CountBots = 0;
            var bot = false;

            if (EntityManager.Heroes.AllHeroes.Count < 3)
            {
                bot = true;
            }
            else
            {
                foreach (var n in EntityManager.Heroes.AllHeroes)
                {
                    if (n.Name.Contains(" Bot"))
                        CountBots++;
                }
                if (CountBots > 1)
                {
                    bot = true;
                }
            }
            return bot;
        }
    }
}