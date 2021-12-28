using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Melee
{
    public class ChargedGraniteBolt : ModProjectile
    {
        public override string Texture => "ExtinctionTalesMod/Projectiles/InvisibleProj";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
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

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Glass, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100);
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 spinningpoint = new Vector2(0f, -3f).RotatedByRandom(3.14159274101257);
            float num1 = 18 * projectile.scale;
            Vector2 vector2 = new Vector2(1.1f, 1f);
            for (float num2 = 0.0f; (double)num2 < num1; ++num2)
            {
                int dustIndex = Dust.NewDust(projectile.Center, 0, 0, DustID.Glass, 0.0f, 0.0f, 0, default, 1f);
                Main.dust[dustIndex].position = projectile.Center;
                Main.dust[dustIndex].velocity = spinningpoint.RotatedBy(6.28318548202515 * num2 / num1, new Vector2()) * vector2 * (float)(0.800000011920929 + Main.rand.NextFloat() * 0.400000005960464);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].scale = 2f;
                Main.dust[dustIndex].fadeIn = Main.rand.NextFloat() * 2f;
                Dust dust = Dust.CloneDust(dustIndex);
                dust.scale /= 2f;
                dust.fadeIn /= 2f;
            }

            Main.PlaySound(SoundID.Item10, projectile.position);
        }
    }
}