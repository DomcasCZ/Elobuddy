using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using static Wladis_Kata.Menus;

namespace Wladis_Kata
{
    class WarJumper
    {
        // From SATANIX From SATANIX From SATANIX From SATANIX
        // From SATANIX From SATANIX From SATANIX From SATANIX
        // From SATANIX From SATANIX From SATANIX From SATANIX
        // From SATANIX From SATANIX From SATANIX From SATANIX
        // From SATANIX From SATANIX From SATANIX From SATANIX
        // From SATANIX From SATANIX From SATANIX From SATANIX

        private static long _lastCheck;
        public static long LastWard;
        private static Vector3 _jumpPos;
        public static Menu WardjumpMenu;
        private static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }

        public static void GameObject_OnCreate(GameObject sender, EventArgs args)
        {
            if (sender.IsAlly && sender is Obj_AI_Base && sender.Name.ToLower().Contains("ward") && sender.Distance(_Player) < 600 && _jumpPos.Distance(sender) < 200)
            {
                SpellsManager.E.Cast((Obj_AI_Base)sender);
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (WardjumpMenu["drawWJ"].Cast<CheckBox>().CurrentValue && WardjumpMenu["wardjumpKeybind"].Cast<KeyBind>().CurrentValue)
            {
                Circle.Draw(Color.Teal, 100, _jumpPos);
                Circle.Draw(Color.White, 600, _Player.Position);
            }
        }

        public static void WardJump(Vector3 pos, bool max, bool cursorOnly)
        {
            if (WardjumpMenu["wardjumpKeybind"].Cast<KeyBind>().CurrentValue)
                Orbwalker.OrbwalkTo(Game.CursorPos.Extend(Game.CursorPos, 200).To3D());
            if (!_jumpPos.IsValid() || _lastCheck <= Environment.TickCount)
            {
                _jumpPos = pos;
                _lastCheck = Environment.TickCount + WardjumpMenu["checkTime"].Cast<Slider>().CurrentValue;
            }

            var jumpPoint = _jumpPos;
            if (max && jumpPoint.Distance(_Player.Position) > 600)
            {
                jumpPoint = _Player.Position.Extend(_jumpPos, 600).To3D();
            }
            else if (cursorOnly && jumpPoint.Distance(_Player.Position) > 600)
            {
                return;
            }

            _jumpPos = jumpPoint;
            var ward =
                ObjectManager.Get<Obj_AI_Base>()
                    .FirstOrDefault(a => a.IsAlly && a.Distance(_jumpPos) < 100);
            if (ward != null)
            {
                if (SpellsManager.E.IsReady())
                {
                    Player.CastSpell(SpellSlot.E, ward);
                }
            }
            else
            {
                var wardSpot = GetWardSlot();
                if (wardSpot == null)
                {
                    return;
                }
                if (SpellsManager.E.IsReady() && LastWard + 400 < Environment.TickCount)
                {
                    GetWardSlot().Cast(_jumpPos);
                    LastWard = Environment.TickCount;
                }
            }
        }

        public static InventorySlot GetWardSlot()
        {
            var wardIds = new[] { ItemId.Warding_Totem_Trinket, ItemId.Sightstone, ItemId.Ruby_Sightstone, ItemId.Vision_Ward, ItemId.Greater_Stealth_Totem_Trinket };
            return _Player.InventoryItems.FirstOrDefault(a => wardIds.Contains(a.Id) && a.IsWard && a.CanUseItem());
        }

    }
}
