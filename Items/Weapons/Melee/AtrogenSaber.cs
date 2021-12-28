using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class AtrogenSaber : ModItem
    {
        private Vector2 newVect;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Saber");
            Tooltip.SetDefault("Shoots plasma rays");
        }

        public override void SetDefaults()
        {
            item.height = 50;
            item.width = 50;
            item.damage = 46;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 25;
            item.useTime = 25;
            item.melee = true;
            item.crit = 4;
            item.shoot = ModContent.ProjectileType<PlasmaRay>();
            item.shootSpeed = 18f;
            item.value = Item.sellPrice(silver: 92);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item15;
            item.autoReuse = true;
            item.knockBack = 5.5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(3) == 0)
            {
                Vector2 origVect = new Vector2(speedX, speedY);
                for (int X = 0; X < 1; X++)
                {
                    if (Main.rand.Next(2) == 1)
                    {
                        newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(300, 500) / 10));
                    }
                    else
                    {
                        newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(300, 500) / 10));
                    }
                    Projectile proj = Main.projectile[Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI)];
                    proj.friendly = true;
                    proj.hostile = false;
                    proj.netUpdate = true;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}