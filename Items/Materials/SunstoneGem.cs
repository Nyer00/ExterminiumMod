using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class SunstoneGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunstone");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.maxStack = 99;
            item.rare = ItemRarityID.LightRed;
            item.consumable = true;
            item.value = Item.sellPrice(silver: 98);
        }
    }
}