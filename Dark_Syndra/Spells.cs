using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace Dark_Syndra
{
    public static class Spells
    {
        public static Spell.Active Barrier = new Spell.Active(ReturnSlot("summonerbarrier"));
        public static Spell.Active Heal = new Spell.Active(ReturnSlot("summonerheal"), 850);
        public static Spell.Targeted Ignite = new Spell.Targeted(ReturnSlot("summonerdot"), 600);
        public static Spell.Targeted Smite = new Spell.Targeted(ReturnSlot(SmiteNames), 500);
        public static Spell.Active Cleanse = new Spell.Active(ReturnSlot("summonerboost"));

        private static string[] SmiteNames => new[]
        {
            "s5_summonersmiteplayerganker", "s5_summonersmiteduel",
            "s5_summonersmitequick", "itemsmiteaoe", "summonersmite"
        };

        private static SpellSlot ReturnSlot(string name)
        {
            return Player.Instance.GetSpellSlotFromName(name);
        }

        private static SpellSlot ReturnSlot(string[] name)
        {
            if (SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner1).Name.ToLower()))
                return SpellSlot.Summoner1;

            return SmiteNames.Contains(Player.Instance.Spellbook.GetSpell(SpellSlot.Summoner2).Name.ToLower()) ? SpellSlot.Summoner2 : SpellSlot.Unknown;
        }
    }
}