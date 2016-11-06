using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;
using SharpDX;
using EloBuddy;
using EloBuddy.Sandbox;
using static PetBuddy.Converters;
using EloBuddy.SDK.Menu.Values;

namespace PetBuddy
{
    public class Save
    {
        //File name setup for saving
        public static string FileName;
        public static readonly string ConfigFolderPath = Path.Combine(SandboxConfig.DataDirectory);

        public static void SaveData()
        {
            //Grab data from text file else create it
            FileName = "PetBuddy.txt";
            if (!File.Exists(ConfigFolderPath + FileName))
            {
                File.Create(ConfigFolderPath + FileName);
                FirstRun();

            }
            //else read the save
            else
            {
                ReadSave();

            }
        }
        //Used to read data
        public static void ReadSave()
        {
            string LvlStr = null;
            string CurXPStr = null;
            string MaxXPStr = null;
            string DmgStr = null;
            string HpStr = null;

            using (var sr = new System.IO.StreamReader(ConfigFolderPath + FileName, true))
            {
                string line;
                int currentLineNumber = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    switch (++currentLineNumber)
                    {
                        case 2:
                            LvlStr = line;
                            break;
                        case 3:
                            CurXPStr = line;
                            break;
                        case 4:
                            MaxXPStr = line;
                            break;
                        case 5:
                            DmgStr = line;
                            break;
                        case 6:
                            HpStr = line;
                            break;
                    }
                }
                Converters.ConvertString(LvlStr, CurXPStr, MaxXPStr, DmgStr, HpStr);
            }
        }

        //Used to save data
        public static void SaveData(string lvl, string currxp, string maxxp, string Dmg, string Hp)
        {
            File.WriteAllText(ConfigFolderPath + FileName, Pet.PetName + "\n");
            using (var file = new StreamWriter(ConfigFolderPath + FileName, true))
            {
                file.WriteLine(lvl);
                file.WriteLine(currxp);
                file.WriteLine(maxxp);
                file.WriteLine(Dmg);
                file.WriteLine(Hp);
                file.Close();
            }
        }

        public static void FirstRun()
        {
            RandomName();
            Pet.Lvl = 1;
            Pet.CurXP = 0;
            Pet.MaxXP = 100;
            Pet.Dmg = 10;
            Pet.Hp = 50;
            Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.Dmg, Pet.Hp);
        }

        //Name Gen Stuff
        public static void RandomName()
        {
            //Random Name Gen
            string[] NameDatabase1 = { "Ba", "Bax", "Dan", "Fi", "Fix", "Fiz", "Gi", "Gix", "Giz", "Gri", "Gree", "Greex", "Grex", "Ja", "Jax", "Jaz", "Jex", "Ji", "Jix", "Ka", "Kax", "Kay", "Kaz", "Ki", "Kix", "Kiz", "Klee", "Kleex", "Kwee", "Kweex", "Kwi", "Kwix", "Kwy", "Ma", "Max", "Ni", "Nix", "No", "Nox", "Qi", "Rez", "Ri", "Ril", "Rix", "Riz", "Ro", "Rox", "So", "Sox", "Vish", "Wi", "Wix", "Wiz", "Za", "Zax", "Ze", "Zee", "Zeex", "Zex", "Zi", "Zix", "Zot" };
            string[] NameDatabase2 = { "b", "ba", "be", "bi", "d", "da", "de", "di", "e", "eb", "ed", "eg", "ek", "em", "en", "eq", "ev", "ez", "g", "ga", "ge", "gi", "ib", "id", "ig", "ik", "im", "in", "iq", "iv", "iz", "k", "ka", "ke", "ki", "m", "ma", "me", "mi", "n", "na", "ni", "q", "qa", "qe", "qi", "v", "va", "ve", "vi", "z", "za", "ze", "zi", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string[] NameDatabase3 = { "ald", "ard", "art", "az", "azy", "bit", "bles", "eek", "eka", "et", "ex", "ez", "gaz", "geez", "get", "giez", "iek", "igle", "ik", "il", "in", "ink", "inkle", "it", "ix", "ixle", "lax", "le", "lee", "les", "lex", "lyx", "max", "maz", "mex", "mez", "mix", "miz", "mo", "old", "rax", "raz", "reez", "rex", "riez", "tee", "teex", "teez", "to", "uek", "x", "xaz", "xeez", "xik", "xink", "xiz", "xonk", "yx", "zeel", "zil" };

            Random RandName = new Random();
            string Temp = NameDatabase1[RandName.Next(0, NameDatabase1.Length)] + NameDatabase2[RandName.Next(0, NameDatabase2.Length)] + NameDatabase3[RandName.Next(0, NameDatabase3.Length)];
            Pet.PetName = Temp;
        }
        

        public static void NewPet()
        {
            if (Menus.SettingsMenu["NewStart"].Cast<CheckBox>().CurrentValue && Menus.SettingsMenu["NewStartt"].Cast<Slider>().CurrentValue == 76)
            {
                FirstRun();
                Chat.Print("PetBuddy: New Pet Created!", System.Drawing.Color.Violet);
                Menus.SettingsMenu["NewStart"].Cast<CheckBox>().CurrentValue = false;
            }
        }

        public static void ManualSave()
        {
            if (Menus.SettingsMenu["Safe"].Cast<CheckBox>().CurrentValue)
            {
                Chat.Print("PetBuddy: Saving...", System.Drawing.Color.Violet);
                Converters.ConvertInt(Pet.Lvl, Pet.CurXP, Pet.MaxXP, Pet.Dmg, Pet.Hp);
                Chat.Print("Petbuddy: Progress Saved!", System.Drawing.Color.Violet);
                Menus.SettingsMenu["Safe"].Cast<CheckBox>().CurrentValue = !true ;
            }

        }

    }
}
