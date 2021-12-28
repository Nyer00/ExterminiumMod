using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Picks
{
    public class ViriumPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.autoReuse = true;
            item.height = 36;
            item.width = 34;
            item.useAnimation = 28;
            item.useTime = 28;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(silver: 21);
            item.UseSound = SoundID.Item1;
            item.knockBack = 4f;
            item.pick = 60;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}