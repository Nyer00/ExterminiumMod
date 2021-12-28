using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class ViriumSword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 21;
            item.crit = 4;
            item.melee = true;
            item.autoReuse = true;
            item.width = 30;
            item.height = 38;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 40);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTime = 30;
            item.knockBack = 3f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}