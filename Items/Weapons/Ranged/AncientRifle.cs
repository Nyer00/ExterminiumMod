using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class AncientRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Rifle");
        }

        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 16;
            item.damage = 86;
            item.knockBack = 6f;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.reuseDelay = 12;
            item.autoReuse = true;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 5);
            item.ranged = true;
            item.UseSound = SoundID.Item40;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 14f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientMarbleAlloy>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}