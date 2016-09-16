using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using T2IN1_Lib;
using static Fairy_Lux.SpellsManager;

namespace Fairy_Lux
{
    class Active
    {
        public static void Execute6()
        {
            if (W.IsReady())

                if (myhero.IsInDanger(80))
                {
                    W.Cast(myhero.Position);
                }

        }

        public static AIHeroClient myhero { get { return ObjectManager.Player; } }
    }

}
