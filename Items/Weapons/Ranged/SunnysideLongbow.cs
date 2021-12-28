using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Arrows;
using ExtinctionTalesMod.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class SunnysideLongbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunnyside Longbow");
            Tooltip.SetDefault("Random chances to shoot a Sunfire Wheel");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 50;
            item.damage = 50;
            item.crit = 8;
            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.useTime = 24;
            item.useAnimation = 24;
            item.rare = ItemRarityID.Pink;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(gold: 32);
            item.UseSound = SoundID.Item20;
            item.knockBack = 4f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 16f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ModContent.ProjectileType<OverheatFire>();
            }
            if (type == ModContent.ProjectileType<OverheatFire>() && Main.rand.Next(3) == 0)
            {
                type = ModContent.ProjectileType<SunfireWheel>();
            }
            return true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("ExtinctionTalesMod/Items/Weapons/Ranged/SunnysideLongbow_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}