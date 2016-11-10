using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Wladis_Kata
{
    internal static class SpellsManager
    {
        public static Spell.Targeted Q;
        public static Spell.Active W;
        public static Spell.Skillshot E;
        public static Spell.Active R;
        public static List<Spell.SpellBase> SpellList = new List<Spell.SpellBase>();

        public static void InitializeSpells()
        {
            Q = new Spell.Targeted(SpellSlot.Q, 625);

            W = new Spell.Active(SpellSlot.W, 375);

            E = new Spell.Skillshot(SpellSlot.E, 725, SkillShotType.Circular, 0, 0, 20);

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
            var Plevel = Player.Instance.Level - 1;

            var dmg = 0f;

            switch (slot)
            {
                case SpellSlot.Q:
                    if (Q.IsReady())
                        dmg += new float[] { 75, 105, 135, 165, 195 }[sLevel] + 0.3f * ap;
                    break;
                case SpellSlot.W:
                    if (W.IsReady())
                        dmg += new float[] { 75, 130, 170, 160, 220}[sLevel] + 0.5f * ap + 1.00f *ad;
                    break;
                case SpellSlot.E:
                    if (E.IsReady())
                        dmg += new float[] { 30, 45, 60, 75, 90 }[sLevel]+ 0.65f * ad + 0.25f * ap;
                    break;                  
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