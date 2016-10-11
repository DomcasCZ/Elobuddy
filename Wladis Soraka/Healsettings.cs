using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using static Wladis_Soraka.Combo;
using static Wladis_Soraka.Menus;
using System;

namespace Wladis_Soraka
{
    class HealSettings
    {
        public static void Execute6()
        {
            var test = EntityManager.Heroes.Allies.Where(hero => !hero.IsMe && !hero.IsDead && !hero.IsInShopRange() && !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.W.Range);

            var sdl = EntityManager.Heroes.Allies.FirstOrDefault(hero => !hero.IsMe && !hero.IsInShopRange() && !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.W.Range);

            var target = TargetSelector.GetTarget(SpellsManager.Q.Range, DamageType.Magical);
            
            if (HealMenu["AutoW"].Cast<CheckBox>().CurrentValue && SpellsManager.W.IsReady() && myhero.HealthPercent > HealMenu["Myhealth"].Cast<Slider>().CurrentValue && sdl.HealthPercent < HealMenu["WAllyHealth"].Cast<Slider>().CurrentValue)
            {
                SpellsManager.W.Cast(sdl);
            }
        }

        public static void Execute8()
        {
            var test = EntityManager.Heroes.Allies.Where(hero => !hero.IsMe && !hero.IsDead && !hero.IsInShopRange() && !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.R.Range);
            var allytoheal = test.FirstOrDefault(x => !x.IsInShopRange());
            var sdl = EntityManager.Heroes.Allies.FirstOrDefault(hero => !hero.IsMe && !hero.IsInShopRange() && !hero.IsZombie && hero.Distance(myhero) <= SpellsManager.R.Range);

            if (SpellsManager.R.IsReady() && HealMenu["R"].Cast<CheckBox>().CurrentValue && sdl.HealthPercent < HealMenu["RAllyHealth"].Cast<Slider>().CurrentValue && sdl.CountEnemiesInRange(HealMenu["REnemyInRange"].Cast<Slider>().CurrentValue) >= 1)
            {
                SpellsManager.R.Cast();
            }
            
                if (SpellsManager.R.IsReady() && HealMenu["RYou"].Cast<CheckBox>().CurrentValue && myhero.HealthPercent < HealMenu["RAllyHealth"].Cast<Slider>().CurrentValue && myhero.CountEnemiesInRange(HealMenu["REnemyInRange"].Cast<Slider>().CurrentValue) >= 1)
                {
                    SpellsManager.R.Cast();
                }
        }
        
    }

}