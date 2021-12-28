using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Assassin
{
    public class StoneDaggerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Dagger");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 24;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 600;
            projectile.hostile = false;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
            projectile.ai[0]++;
            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}