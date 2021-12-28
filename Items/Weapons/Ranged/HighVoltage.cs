using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Arrows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class HighVoltage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("High Voltage");
            Tooltip.SetDefault("Charges up Wooden Arrows");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.crit = 4;
            item.ranged = true;
            item.width = 32;
            item.height = 48;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3.5f;
            item.value = Item.sellPrice(silver: 85);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<HighVoltageArrow>();
            }
            return true;
        }
    }
}