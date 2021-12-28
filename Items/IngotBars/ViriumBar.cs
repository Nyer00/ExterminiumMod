using ExtinctionTalesMod.Items.Ores;
using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.IngotBars
{
    public class ViriumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Bar");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 22;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(copper: 72);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.consumable = true;
            item.maxStack = 999;
            item.createTile = ModContent.TileType<ViriumBarTile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}