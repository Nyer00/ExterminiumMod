using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Ores
{
    public class ViriumOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Ore");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 14;
            item.maxStack = 999;
            item.autoReuse = true;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.value = Item.sellPrice(copper: 32);
            item.rare = ItemRarityID.Blue;
            item.consumable = true;
            item.createTile = ModContent.TileType<ViriumOreTile>();
            item.UseSound = SoundID.Item1;
        }
    }
}