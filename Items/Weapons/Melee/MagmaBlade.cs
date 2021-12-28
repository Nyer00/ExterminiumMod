using ExtinctionTalesMod.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class MagmaBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Blade");
            Tooltip.SetDefault("Shoots an infernal sphere");
        }

        public override void SetDefaults()
        {
            item.shoot = ModContent.ProjectileType<InfernalSphere>();
            item.shootSpeed = 22f;
            item.width = 40;
            item.height = 40;
            item.damage = 50;
            item.crit = 6;
            item.melee = true;
            item.useAnimation = 26;
            item.value = Item.sellPrice(gold: 2);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTime = 26;
            item.knockBack = 6f;
            item.autoReuse = true;
            item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 14);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 1;
            float rotation = MathHelper.ToRadians(0);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 15f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 0))) * .7f;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }*/
    }
}