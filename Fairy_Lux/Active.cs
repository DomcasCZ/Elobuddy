using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Fairy_Lux.SpellsManager;
using static Fairy_Lux.Menus;

namespace Fairy_Lux
{
    class Active
    {
        public static void Execute6()
        {
            var playerMana = Player.Instance.ManaPercent;
            var herohealth = WMenu["dangerSlider"].Cast<Slider>().CurrentValue;
            if (W.IsReady() && WMenu["W"].Cast<CheckBox>().CurrentValue && myhero.HealthPercent < herohealth && playerMana > WMenu["manaSlider"].Cast<Slider>().CurrentValue && myhero.CountEnemiesInRange(500) >= 1)
            {
                W.Cast(myhero.Position);
            }
        }

        public static AIHeroClient myhero { get { return ObjectManager.Player; } }
    }

}
