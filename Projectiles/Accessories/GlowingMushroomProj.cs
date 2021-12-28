using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Accessories
{
    public class GlowingMushroomProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glowing Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 1;
            projectile.penetrate = 1;
            projectile.aiStyle = 0;
            projectile.light = 0.5f;
            projectile.timeLeft = 300;
            projectile.alpha = 90;
        }

        public override void AI()
        {
            projectile.rotation += 0.2f * projectile.direction;
            projectile.velocity *= 0.88f;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.GlowingMushroom, 0f, 0f, 10, default);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 2f;
            }

            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}