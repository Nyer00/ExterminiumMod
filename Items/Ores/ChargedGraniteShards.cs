using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Ores
{
    public class ChargedGraniteShards : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Shards");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 24;
            item.maxStack = 999;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
            item.autoReuse = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.createTile = ModContent.TileType<ChargedGraniteTile>();
            item.UseSound = SoundID.Item1;
        }
    }
}