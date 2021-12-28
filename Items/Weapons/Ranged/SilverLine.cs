using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class SilverLine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Line");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 50;
            item.rare = ItemRarityID.Lime;
            item.ranged = true;
            item.noMelee = true;
            item.damage = 88;
            item.crit = 6;
            item.knockBack = 5f;
            item.useTime = 26;
            item.useAnimation = 26;
            item.autoReuse = true;
            item.UseSound = SoundID.Item5;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 16f;
            item.value = Item.sellPrice(gold: 6);
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientMarbleAlloy>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}