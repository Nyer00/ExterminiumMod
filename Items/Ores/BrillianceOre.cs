using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Ores
{
    public class BrillianceOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Ore");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.maxStack = 999;
            item.autoReuse = true;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.consumable = true;
            item.createTile = ModContent.TileType<BrillianceOreTile>();
            item.UseSound = SoundID.Item1;
        }
    }
}