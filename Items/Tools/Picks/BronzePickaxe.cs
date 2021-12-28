using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Picks
{
    public class BronzePickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 7;
            item.melee = true;
            item.autoReuse = true;
            item.width = 34;
            item.height = 38;
            item.useAnimation = 30;
            item.useTime = 30;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(silver: 13);
            item.UseSound = SoundID.Item1;
            item.knockBack = 2.5f;
            item.pick = 55;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}