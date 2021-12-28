using ExtinctionTalesMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.HostileProjectiles
{
    public class GlowingMushroom : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glowing Mushroom");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 24;
            projectile.damage = 14;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.light = 0.5f;
            projectile.timeLeft = 900;
            projectile.alpha = 90;
        }

        public override void AI()
        {
            projectile.rotation += 0.4f * projectile.direction;
            if (projectile.velocity.Length() < 32)
            {
                projectile.velocity *= 1.02f;
            }
            else
            {
                projectile.velocity = Vector2.Normalize(projectile.velocity) * 32;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
            target.AddBuff(ModContent.BuffType<FungalInfection>(), 300);
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