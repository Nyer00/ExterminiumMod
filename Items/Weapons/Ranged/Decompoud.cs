using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class Decompoud : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Decompoud");
            Tooltip.SetDefault("Changes between Ichor arrows or Cursed arrows");
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 66;
            item.damage = 46;
            item.ranged = true;
            item.crit = 6;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 4f;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 12f;
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                if (Main.rand.NextBool())
                {
                    type = ProjectileID.IchorArrow;
                }
                else
                {
                    type = ProjectileID.CursedArrow;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShadowflareBow>());
            recipe.AddIngredient(ModContent.ItemType<BloodflareBow>());
            recipe.AddIngredient(ItemID.Ichor, 8);
            recipe.AddIngredient(ItemID.CursedFlame, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}