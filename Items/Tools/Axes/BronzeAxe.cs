using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Axes
{
    public class BronzeAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 9;
            item.width = 40;
            item.height = 44;
            item.melee = true;
            item.axe = 11;
            item.autoReuse = true;
            item.rare = ItemRarityID.Blue;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3f;
            item.value = Item.sellPrice(silver: 18);
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}