using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Melee
{
    public class InfernalSphere : ModProjectile
    {
        public override string Texture => "ExtinctionTalesMod/Projectiles/InvisibleProj";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernal Sphere");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 0;
            projectile.light = 0.5f;
            projectile.melee = true;
            projectile.timeLeft = 600;
            projectile.hostile = false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 120, true);
        }

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100);
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 35; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 10, default, 2f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 3f;
            }
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}