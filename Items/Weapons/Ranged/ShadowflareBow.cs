using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class ShadowflareBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflare Bow");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.crit = 4;
            item.ranged = true;
            item.width = 38;
            item.height = 64;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3f;
            item.value = Item.sellPrice(silver: 72);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}