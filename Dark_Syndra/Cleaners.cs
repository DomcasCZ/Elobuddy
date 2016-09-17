using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace Dark_Syndra
{
    public static class Cleansers
    {
        // Cleansers
        public static Item Mikael = new Item(ItemId.Mikaels_Crucible, 750);
        public static Item Qss = new Item(ItemId.Quicksilver_Sash);
        public static Item Mercurial = new Item(ItemId.Mercurial_Scimitar);

        public static List<Item> ItemList = new List<Item>
        {
            Mikael,
            Qss,
            Mercurial
        };
    }
}