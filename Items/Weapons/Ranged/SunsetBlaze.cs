using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class SunsetBlaze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunset Blaze");
        }

        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 22;
            item.ranged = true;
            item.damage = 50;
            item.useTime = 8;
            item.useAnimation = 8;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2f;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item11;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 14f;
            item.autoReuse = true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("ExtinctionTalesMod/Items/Weapons/Ranged/SunsetBlaze_Glow"),
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
            return new Vector2(-8, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 10f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CarbineRifle>());
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}