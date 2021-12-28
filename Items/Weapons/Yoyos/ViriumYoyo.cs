using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Yoyos;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Yoyos
{
    public class ViriumYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Yoyo");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.height = 46;
            item.width = 38;
            item.damage = 18;
            item.crit = 2;
            item.value = Item.sellPrice(silver: 10);
            item.rare = ItemRarityID.Blue;
            item.knockBack = 2f;
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 25;
            item.useTime = 23;
            item.shoot = ModContent.ProjectileType<ViriumYoyoProjectile>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 12);
            recipe.AddIngredient(ItemID.Cobweb, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}