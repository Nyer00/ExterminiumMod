using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Magic
{
    public class SoulsProj : ModProjectile
    {
        public override string Texture => "ExtinctionTalesMod/Projectiles/InvisibleProj";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hopeless Souls Projectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.penetrate = 1;
            projectile.aiStyle = -1;
            projectile.magic = true;
            projectile.light = 0.5f;
            projectile.timeLeft = 180;
            projectile.hostile = false;
            projectile.tileCollide = false;
        }

        private int counter;

        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.PurificationPowder, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100);
            Main.dust[dust].scale = 1.25f;
            Main.dust[dust].noGravity = true;
            counter++;
            if (counter >= 1440)
            {
                counter = -1440;
            }
            for (int i = 0; i < 1; i++)
            {
                float x = projectile.Center.X - projectile.velocity.X / 10f * i;
                float y = projectile.Center.Y - projectile.velocity.Y / 10f * i;

                int num2121 = Dust.NewDust(projectile.Center + new Vector2(0, (float)Math.Cos(counter / 4.2f) * 9.2f).RotatedBy(projectile.rotation), 6, 6, DustID.PurificationPowder, 0f, 0f, 0, default, 1f);
                Main.dust[num2121].velocity *= 0f;
                Main.dust[num2121].scale *= 1f;
                Main.dust[num2121].noGravity = true;
            }
            float num132 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            float num133 = projectile.localAI[0];
            if (num133 == 0f)
            {
                projectile.localAI[0] = num132;
                num133 = num132;
            }
            float num134 = projectile.position.X;
            float num135 = projectile.position.Y;
            float num136 = 300f;
            bool flag3 = false;
            int num137 = 0;
            if (projectile.ai[1] == 0f)
            {
                for (int num138 = 0; num138 < 200; num138++)
                {
                    if (Main.npc[num138].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == num138 + 1))
                    {
                        float num139 = Main.npc[num138].position.X + Main.npc[num138].width / 2;
                        float num140 = Main.npc[num138].position.Y + Main.npc[num138].height / 2;
                        float num141 = Math.Abs(projectile.position.X + projectile.width / 2 - num139) + Math.Abs(projectile.position.Y + projectile.height / 2 - num140);
                        if (num141 < num136 && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
                        {
                            num136 = num141;
                            num134 = num139;
                            num135 = num140;
                            flag3 = true;
                            num137 = num138;
                        }
                    }
                }
                if (flag3)
                {
                    projectile.ai[1] = num137 + 1;
                }
                flag3 = false;
            }
            if (projectile.ai[1] > 0f)
            {
                int num142 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
                {
                    float num143 = Main.npc[num142].position.X + Main.npc[num142].width / 2;
                    float num144 = Main.npc[num142].position.Y + Main.npc[num142].height / 2;
                    if (Math.Abs(projectile.position.X + projectile.width / 2 - num143) + Math.Abs(projectile.position.Y + projectile.height / 2 - num144) < 1000f)
                    {
                        flag3 = true;
                        num134 = Main.npc[num142].position.X + Main.npc[num142].width / 2;
                        num135 = Main.npc[num142].position.Y + Main.npc[num142].height / 2;
                    }
                }
                else
                {
                    projectile.ai[1] = 0f;
                }
            }
            if (!projectile.friendly)
            {
                flag3 = false;
            }
            if (flag3)
            {
                float num145 = num133;
                Vector2 vector10 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                float num146 = num134 - vector10.X;
                float num147 = num135 - vector10.Y;
                float num148 = (float)Math.Sqrt(num146 * num146 + num147 * num147);
                num148 = num145 / num148;
                num146 *= num148;
                num147 *= num148;
                int num149 = 8;
                projectile.velocity.X = (projectile.velocity.X * (num149 - 1) + num146) / num149;
                projectile.velocity.Y = (projectile.velocity.Y * (num149 - 1) + num147) / num149;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            Vector2 spinningpoint = new Vector2(0f, -3f).RotatedByRandom(3.14159274101257);
            float num1 = 18 * projectile.scale;
            Vector2 vector2 = new Vector2(1.1f, 1f);
            for (float num2 = 0.0f; (double)num2 < num1; ++num2)
            {
                int dustIndex = Dust.NewDust(projectile.Center, 0, 0, DustID.PurificationPowder, 0.0f, 0.0f, 0, default, 1f);
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