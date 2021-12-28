using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class HardwareBit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hardware Pieces");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 23;
            item.maxStack = 999;
            item.value = Item.sellPrice(copper: 61);
            item.rare = ItemRarityID.Orange;
        }
    }
}