using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Arrows;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Ammo
{
    public class ChargedArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Arrow");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.ranged = true;
            item.width = 18;
            item.height = 36;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 10;
            item.rare = ItemRarityID.Orange;
            item.shoot = ModContent.ProjectileType<HighVoltageArrow>();
            item.shootSpeed = 10f;
            item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 35);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 35);
            recipe.AddRecipe();
        }
    }
}