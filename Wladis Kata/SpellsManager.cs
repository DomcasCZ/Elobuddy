using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace Wladis_Kata
{
    internal static class SpellsManager
    {
        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Targeted E;
        public static Spell.Active R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 675);

            W = new Spell.Active(SpellSlot.W, 375);

            E = new Spell.Targeted(SpellSlot.E, 700);

            R = new Spell.Active(SpellSlot.R, 550);

            Obj_AI_Base.OnLevelUp += AutoLevel.Obj_AI_Base_OnLevelUp;
        }

        #region Damages

        public static float GetRealDamage(this Obj_AI_Base target, SpellSlot slot)
        {
            var damageType = DamageType.Mixed;
            var ap = Player.Instance.TotalMagicalDamage;
            var ad = Player.Instance.TotalAttackDamage;
            var sLevel = Player.GetSpell(slot).Level - 1;

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                        dmg += new float[] { 60, 85, 110, 135, 160 }[sLevel] + 0.45f * ap;
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                        dmg += new float[] { 40, 75, 110, 145, 180 }[sLevel] + 0.25f * ap + 0.6f * ad;
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                        dmg += new float[] { 40, 70, 100, 130, 160 }[sLevel] + 0.25f * ap;
                    break;                  //60, 105, 150, 195, 240
                case SpellSlot.R:
                    if (R.IsLearned && !R.IsOnCooldown)
                        dmg += new float[] { 250, 350, 450 }[sLevel] + 0.25f * ap + 0.375f * ad;
                    break;                  //300 400 500
            }
            
                return Player.Instance.CalculateDamageOnUnit(target, damageType, dmg - 10);
        }


        #endregion damages


    }
}