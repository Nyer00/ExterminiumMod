using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Yoyos;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Yoyos
{
    public class FiveWatts : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Five Watts");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.width = 44;
            item.height = 36;
            item.damage = 38;
            item.crit = 6;
            item.value = Item.sellPrice(silver: 32);
            item.rare = ItemRarityID.Blue;
            item.knockBack = 2f;
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 25;
            item.useTime = 23;
            item.shoot = ModContent.ProjectileType<FiveWattsProjectile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 14);
            recipe.AddIngredient(ItemID.Cobweb, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}