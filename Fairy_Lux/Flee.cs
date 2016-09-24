using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Fairy_Lux.Menus;

namespace Fairy_Lux
{
    internal class Flee
    {
        public static void Execute()
        {

            var qtarget = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);

            if ((qtarget == null) || qtarget.IsInvulnerable)
                return;
            //Cast Q
            if (FleeMenu["Q"].Cast<CheckBox>().CurrentValue)
                if (qtarget.IsValidTarget(SpellsManager.Q.Range) && SpellsManager.Q.IsReady())
                    SpellsManager.Q.TryToCast(qtarget, ComboMenu);

            var etarget = TargetSelector.GetTarget(SpellsManager.E.Range, DamageType.Magical);

            if ((etarget == null) || etarget.IsInvulnerable)
                return;
            //Cast E
            if (FleeMenu["E"].Cast<CheckBox>().CurrentValue)
                if (etarget.IsValidTarget(SpellsManager.E.Range) && SpellsManager.E.IsReady())
                    SpellsManager.E.TryToCast(etarget, ComboMenu);

        }
    }
}