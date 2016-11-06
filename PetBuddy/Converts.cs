using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX;
using EloBuddy;

namespace PetBuddy
{
    class Converters
    {
        //Convert Int
        public static void ConvertInt(int lvl, int currxp, int maxxp, int Dmg, int Hp)
        {
            string level = Pet.Lvl.ToString();
            string currentXP = Pet.CurXP.ToString();
            string MaximumXP = Pet.MaxXP.ToString();
            string Damage = Pet.Dmg.ToString();
            string HealthPoints = Pet.Hp.ToString();
            Save.SaveData(level, currentXP, MaximumXP, Damage, HealthPoints);
        }

        //Convert String
        public static void ConvertString(string lvl, string currxp, string maxxp, string Dmg, string Hp)
        {

            int level = int.Parse(lvl);
            int currentXP = int.Parse(currxp);
            int maximumXP = int.Parse(maxxp);
            int Damage = int.Parse(Dmg);
            int HealthPoints = int.Parse(Hp);

            Pet.Lvl = level;
            Pet.CurXP = currentXP;
            Pet.MaxXP = maximumXP;
            Pet.Dmg = Damage;
            Pet.Hp = HealthPoints;
        }
    }
}