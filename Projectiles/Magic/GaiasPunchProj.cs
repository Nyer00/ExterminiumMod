using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Magic
{
    public class GaiasPunchProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's Punch Projectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 0;
            projectile.light = 0.5f;
            projectile.timeLeft = 600;
            projectile.hostile = false;
        }

        public override void AI()
        {
            if (projectile.direction == -1)
            {
                projectile.spriteDirection = -1;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(180);
            }
            else
            {
                projectile.spriteDirection = 1;
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(0);
            }
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Glass, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100);
            Main.dust[dust].scale = 1f;
            Main.dust[dust].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item62, projectile.position);
            for (int i = 0; i < 20; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Granite, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 1.2f;
            }
            for (int i = 0; i < 30; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Glass, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 3f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Glass, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 1.5f;
            }
        }
    }
}