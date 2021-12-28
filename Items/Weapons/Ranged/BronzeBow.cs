using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class BronzeBow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.crit = 2;
            item.ranged = true;
            item.height = 48;
            item.width = 40;
            item.useTime = 30;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Blue;
            item.knockBack = 3f;
            item.value = Item.sellPrice(silver: 32);
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4, 0);
        }
    }
}