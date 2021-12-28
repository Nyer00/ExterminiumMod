using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class MetallicGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's really harsh");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 14;
            item.maxStack = 999;
            item.value = Item.sellPrice(copper: 78);
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<HardwareBit>(), 2);
            recipe.AddIngredient(ItemID.Gel, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}