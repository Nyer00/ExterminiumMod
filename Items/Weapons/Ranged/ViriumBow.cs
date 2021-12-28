using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class ViriumBow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 22;
            item.crit = 2;
            item.ranged = true;
            item.height = 50;
            item.width = 40;
            item.useTime = 30;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Blue;
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(silver: 32);
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 6f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-7, 0);
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