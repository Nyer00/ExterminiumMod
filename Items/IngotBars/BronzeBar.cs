using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.IngotBars
{
    public class BronzeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Bar");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(copper: 68);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = ModContent.TileType<BronzeBarTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TinBar);
            recipe.AddIngredient(ItemID.CopperBar, 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}