using EloBuddy;
using EloBuddy.SDK.Menu.Values;

namespace Dark_Syndra
{
    internal class Flee
    {
        public static void Execute()
        {

            if (Menus.FleeMenu["E"].Cast<CheckBox>().CurrentValue)
                if (SpellsManager.Q.IsReady() && SpellsManager.E.IsReady())
                {
                    var b = SpellsManager.Q.Cast(Game.CursorPos);
                    SpellsManager.E.Cast(Game.CursorPos);
                }

        }
    }
}