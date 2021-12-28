using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class MagmaCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Crystal");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.maxStack = 99;
            item.value = Item.sellPrice(silver: 35);
            item.rare = ItemRarityID.Blue;
        }
    }
}