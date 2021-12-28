using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Melee
{
    public class SwingofRuby : ModProjectile
    {
        private int red = 0;

        private int greenAndBlue = 100;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swing of Ruby");
            Main.projFrames[projectile.type] = 28;
        }

        public override void SetDefaults()
        {
            projectile.width = 45;
            projectile.height = 45;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.aiStyle = 20;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 5;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.soundDelay = int.MaxValue;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 0) * (1f - (projectile.alpha / 255f));
        }

        public override void AI()
        {
            projectile.velocity *= 0.98f;
            if (++projectile.frameCounter >= 1)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 28)
                {
                    projectile.frame = 0;
                }
            }

            projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi;
            }

            Vector2 vector2 = projectile.Center + (projectile.velocity * 1.5f);
            Lighting.AddLight(vector2, (float)(red * 0.001), 0.1f, 0.1f);
            if (Main.rand.NextBool(3))
            {
                int num3 = Dust.NewDust(vector2 - (projectile.Size / 2f), projectile.width, projectile.height, DustID.Rainbow, projectile.velocity.X, projectile.velocity.Y, 100, new Color(red, greenAndBlue, greenAndBlue), 1f);
                Main.dust[num3].noGravity = true;
                Dust obj = Main.dust[num3];
                obj.position -= projectile.velocity;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int startY = frameHeight * projectile.frame;
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;
            origin.X = projectile.spriteDirection == 1 ? sourceRectangle.Width - 20 : 20;

            Color drawColor = projectile.GetAlpha(lightColor);
            Main.spriteBatch.Draw(texture,
                projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
                sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

            return false;
        }
    }
}