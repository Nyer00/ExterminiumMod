using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Picks
{
    public class WoodenPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 2;
            item.melee = true;
            item.height = 32;
            item.width = 32;
            item.useTime = 30;
            item.useAnimation = 30;
            item.pick = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2f;
            item.value = Item.sellPrice(copper: 37);
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}