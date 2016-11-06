using EloBuddy;
using System;
using static PetBuddy.Program;
using EloBuddy.SDK;
using System.Linq;

namespace PetBuddy
{
    class Pet
    {
        
        private static int AllyD;
        private static int AllyB;
        private static bool HasBaron = false;
        private static bool DoOnce = false;
        public static float QuadraDelay;
        public static float DoubleDelay;
        public static float TrippleDelay;
        public static float PentaDelay;
        public static float AceDelay;
        public static float WardDelay;
        public static float bDelay;
        

        public static int CurXP;
        public static int MaxXP;
        public static int Lvl;
        public static int Level;
        public static int Dmg;
        public static int Hp;
        public static string PetName;
        public static int XPMulti = 1;

        public static void Game_OnUpdate(EventArgs args)
        {
            Save.SaveData();
            Save.NewPet();
            LevelUp();
            Save.ManualSave();


            
        }

        public static void LevelUp()
        {

            if (CurXP >= MaxXP)
            {
                CurXP = (CurXP - MaxXP);
                MaxXP = (MaxXP * 2);
                Hp = (Hp + 5);
                Dmg = (Dmg + 2);
                Lvl++;
                Chat.Print("Your pet leveled up to level " + Pet.Lvl, System.Drawing.Color.Violet);
            }
        }

        internal static void OnGameNotify(GameNotifyEventArgs args)
        {
            var killer = args.NetworkId;

            switch (args.EventId) //Check for XP events
            {

                case GameEventId.OnChampionDoubleKill:

                    if (killer == myhero.NetworkId)
                    {
                            Pet.CurXP += (5);

                    }
                    break;
                case GameEventId.OnChampionPentaKill:

                    if (killer == myhero.NetworkId)
                    {
                            Pet.CurXP += (40);

                    }
                    break;
                case GameEventId.OnChampionQuadraKill:

                    if (killer == myhero.NetworkId)
                    {
                            Pet.CurXP += (20);
                    }
                    break;
                case GameEventId.OnChampionTripleKill:

                    if (killer == myhero.NetworkId)
                    {
                            Pet.CurXP += (15);
                    }
                    break;
                case GameEventId.OnAce:
                    
                    var aliveppl = myhero.CountEnemiesInRange(int.MaxValue) < 1;
                        if (aliveppl && !myhero.IsDead)
                        {
                            Pet.CurXP += (10);
                        }
                    break;
                case GameEventId.OnChampionKill:
                    
                    if (killer == myhero.NetworkId)
                        Pet.CurXP += (50);
                    Pet.Hp += (1);
                    break;
                case GameEventId.OnKillDragon:

                    var sdl = EntityManager.Heroes.Allies.FirstOrDefault(hero => !hero.IsDead);

                    if (killer == sdl.NetworkId || killer == myhero.NetworkId)
                        Pet.CurXP += (5);

                    break;
                case GameEventId.OnFirstBlood:
                    if (killer == myhero.NetworkId)
                        Pet.CurXP += (20);

                    break;
                case GameEventId.OnChampionDie:

                    Pet.Hp -= (1);
                    break;
                /*case GameEventId.OnKillDragon:
                    
                var Dragon =

                    if (EntityManager.MinionsAndMonsters.Get)
                    {
                    
                    }*/
            }
        }

        

        //End of game Save
        internal static void OnEnd(EventArgs args)
        {
            Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.Dmg, Pet.Hp);
        }

    }
}