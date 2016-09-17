using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;

namespace Dark_Syndra
{
    public static class AutoLevel
    {
        //This event is triggered when a unit levels up
        public static void Obj_AI_Base_OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (Menus.MiscMenu.GetCheckBoxValue("activateAutoLVL") && sender.IsMe)
            {
                var delay = Menus.MiscMenu.GetSliderValue("delaySlider");
                Core.DelayAction(LevelUpSpells, delay);
            }
        }

        //It will level up the spell using the values of the comboboxes on the menu as a priority
        private static void LevelUpSpells()
        {
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(SpellSlot.R))
                Player.Instance.Spellbook.LevelSpell(SpellSlot.R);

            var firstFocusSlot = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("firstFocus"));
            var secondFocusSlot = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("secondFocus"));
            var thirdFocusSlot = GetSlotFromComboBox(Menus.MiscMenu.GetComboBoxValue("thirdFocus"));

            var secondSpell = Player.GetSpell(secondFocusSlot);
            var thirdSpell = Player.GetSpell(thirdFocusSlot);

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(firstFocusSlot))
            {
                if (!secondSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
                if (!thirdSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(secondFocusSlot))
            {
                if (!thirdSpell.IsLearned)
                    Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
                Player.Instance.Spellbook.LevelSpell(firstFocusSlot);
                Player.Instance.Spellbook.LevelSpell(secondFocusSlot);
            }

            if (Player.Instance.Spellbook.CanSpellBeUpgraded(thirdFocusSlot))
                Player.Instance.Spellbook.LevelSpell(thirdFocusSlot);
        }

        /// It will transform the value of the combobox into a SpellSlot
        private static SpellSlot GetSlotFromComboBox(this int value)
        {
            switch (value)
            {
                case 0:
                    return SpellSlot.Q;
                case 1:
                    return SpellSlot.E;
                case 2:
                    return SpellSlot.W;
            }
            Chat.Print("Failed getting slot");
            return SpellSlot.Unknown;
        }
    }
}