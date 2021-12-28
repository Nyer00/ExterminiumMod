using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class OnyxGem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyx");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 16;
            item.maxStack = 99;
            item.autoReuse = true;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.value = Item.sellPrice(copper: 28);
            item.rare = ItemRarityID.Blue;
            item.consumable = true;
            item.createTile = mod.TileType("OnyxGem");
            item.UseSound = SoundID.Item1;
        }
    }
}