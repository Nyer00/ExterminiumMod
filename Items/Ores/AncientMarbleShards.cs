using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Ores
{
    public class AncientMarbleShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Marble Shards");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.maxStack = 999;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
            item.autoReuse = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<AncientMarbleTile>();
            item.UseSound = SoundID.Item1;
        }
    }
}