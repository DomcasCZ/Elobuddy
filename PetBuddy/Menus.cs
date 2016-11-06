using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetBuddy
{
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu SettingsMenu;
        public static Menu PetMenu;



        public static void CreateMenu()
        {

            FirstMenu = MainMenu.AddMenu("Pet " + "Buddy", Player.Instance.ChampionName.ToLower() + "Buddy");
            SettingsMenu = FirstMenu.AddSubMenu("• Settings");
            PetMenu = FirstMenu.AddSubMenu("• Pet");

            SettingsMenu.AddGroupLabel("Settings");
            SettingsMenu.Add("PetVisible", new CheckBox("- Toggle pet visible"));
            SettingsMenu.Add("NewStart", new CheckBox("- Start from new", false));
            SettingsMenu.Add("NewStartt", new Slider("- Are you really sure????", 1, 1, 100));
            SettingsMenu.AddLabel("If you are, slide to the value 76");
            SettingsMenu.AddSeparator();
            SettingsMenu.Add("Safe", new CheckBox("Safe manuelly", false));

            PetMenu.AddGroupLabel("Your Pet");
            PetMenu.AddLabel("Choose your pet's class");
            PetMenu.AddLabel("You can choose it only 1 time");
           
            var a = PetMenu.Add("Warrior", new CheckBox("Warrior", false));
            var b = PetMenu.Add("Marksman", new CheckBox("Marksman", false));
            var c = PetMenu.Add("Ninja", new CheckBox("Ninja", false));
            var d = PetMenu.Add("Mage", new CheckBox("Mage", false));

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
    }
}
