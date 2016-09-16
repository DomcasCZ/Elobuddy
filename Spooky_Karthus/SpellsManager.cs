using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Spooky_Karthus
{
    internal static class SpellsManager
    {
        public static Spell.Skillshot Q;
        public static Spell.Skillshot Q1;
        public static Spell.Skillshot W;
        public static Spell.Active E;
        public static Spell.Skillshot R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 875, SkillShotType.Circular, 1000, int.MaxValue, 160)
            {
                AllowedCollisionCount = int.MaxValue
            };
            Q1 = new Spell.Skillshot(SpellSlot.Q, 875, SkillShotType.Circular, 1000, int.MaxValue, 160)
            {
                AllowedCollisionCount = 0
            };
            W = new Spell.Skillshot(SpellSlot.W, 1000, SkillShotType.Circular, 500, int.MaxValue, 70)
            {
                AllowedCollisionCount = int.MaxValue
            };
            E = new Spell.Active(SpellSlot.E, 550);
            R = new Spell.Skillshot(SpellSlot.R, 40000, SkillShotType.Circular, 3000, int.MaxValue, int.MaxValue)
            {
                AllowedCollisionCount = int.MaxValue
            };

            Obj_AI_Base.OnLevelUp += AutoLevel.Obj_AI_Base_OnLevelUp;
        }

        #region #region Damages

        public static float GetRealDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Magical;
            var ap = Player.Instance.FlatMagicDamageMod;
            var sLevel = Player.GetSpell(slot).Level - 1;
            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                        dmg += new float[] {0, 0, 0, 0, 0}[sLevel] + 0.3f*ap;
                    break; //360
                case SpellSlot.W:
                    if (W.IsReady())
                        dmg += new float[] {0, 0, 0, 0, 0}[sLevel] + 0f*ap;
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                        dmg += new float[] {0, 0, 0, 0, 0}[sLevel] + 0.2f*ap;
                    break;
                case SpellSlot.R:
                    if (R.IsReady())
                        dmg += new float[] {725, 1150, 1600}[sLevel] + 0.6f*ap;
                    break;

            }
            return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }
#endregion damages
    }
}