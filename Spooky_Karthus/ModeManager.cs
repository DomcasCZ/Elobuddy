using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using T2IN1_Lib;
using static Spooky_Karthus.Menus;
using static Spooky_Karthus.Combo;

namespace Spooky_Karthus
{
    internal class ModeManager
    {
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
            Obj_AI_Base.OnBuffLose += OnBuffLoss;
            Spellbook.OnCastSpell += OnCast;

        }
        public static bool BlockE;
        public static void OnBuffLoss(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (sender.IsMe && args.Buff.Name.Equals("Defile")) BlockE = false;
            
        }

        public static void OnCast(Spellbook sender, SpellbookCastSpellEventArgs args)
        {

            var orbMode = Orbwalker.ActiveModesFlags;
            if (!sender.Owner.IsMe) return;

            if (args.Slot == SpellSlot.E && orbMode.HasFlag(Orbwalker.ActiveModes.Combo) || orbMode.HasFlag(Orbwalker.ActiveModes.Harass) || orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                if (!BlockE)
                {
                    BlockE = true;
                }
                else
                {
                    args.Process = false;

                }
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            var target = TargetSelector.GetTarget(SpellsManager.W.Range, DamageType.Magical);


            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
                Combo.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass) && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Harass.Execute1();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Flee) && (playerMana > FleeMenu.GetSliderValue("manaSlider")))
                Flee.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && (playerMana > LaneClearMenu.GetSliderValue("manaSlider")))
                LaneClear.Execute2();

            if (HarassMenu["AutoQ"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute7();

            if (HarassMenu["AutoE"].Cast<CheckBox>().CurrentValue && (playerMana > HarassMenu.GetSliderValue("manaSlider")))
                Autoharass.Execute8();

            if (RMenu["R"].Cast<CheckBox>().CurrentValue)
                Active.Execute9();

            if (RMenu["R1"].Cast<CheckBox>().CurrentValue)
                Active.Execute10();

            if (RMenu["R2"].Cast<CheckBox>().CurrentValue)
                Active.Execute11();
            
        }

    }
}