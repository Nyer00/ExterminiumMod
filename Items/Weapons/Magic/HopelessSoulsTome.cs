using ExtinctionTalesMod.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Magic
{
    public class HopelessSoulsTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hopeless Souls Tome");
            Tooltip.SetDefault("Creates 3 souls that follow enemies");
        }

        public override void SetDefaults()
        {
            item.height = 46;
            item.width = 44;
            item.magic = true;
            item.damage = 32;
            item.noMelee = true;
            item.knockBack = 2.5f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 38;
            item.useAnimation = 38;
            item.autoReuse = true;
            item.mana = 10;
            item.value = Item.sellPrice(silver: 46);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.NPCDeath6;
            item.shoot = ModContent.ProjectileType<SoulsProj>();
            item.shootSpeed = 6f;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("ExtinctionTalesMod/Items/Weapons/Magic/HopelessSoulsTome_Glow"),
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

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 2; i++)
            {
                int p = Projectile.NewProjectile(player.Center.X + Main.rand.Next(-60, 60), player.Center.Y + Main.rand.Next(-60, 60), Main.rand.NextFloat(-5.3f, 5.3f), Main.rand.NextFloat(-5.3f, 5.3f), type, damage, knockBack, player.whoAmI);
                if (Main.projectile[p].velocity == Vector2.Zero)
                {
                    Main.projectile[p].velocity = new Vector2(2.25f, 2.25f);
                }
                if (Main.projectile[p].velocity.X < 2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(1) || Main.projectile[p].velocity.X > -2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(-1))
                {
                    Main.projectile[p].velocity.X *= 2.15f;
                }
            }
            return true;
        }
    }
}