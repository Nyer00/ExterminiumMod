using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.HostileProjectiles
{
    public class RuneWarriorSword : ModProjectile
    {
        private int target;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Warrior Sword");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 54;
            projectile.height = 54;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.light = 0.5f;
            projectile.penetrate = -1;
            projectile.aiStyle = -1;
            projectile.timeLeft = 600;
        }

        public override void AI()
        {
            projectile.rotation += 0.4f * projectile.direction;
            projectile.ai[1]++;
            if (projectile.ai[1] < 60)
            {
                projectile.velocity *= .98f;
            }
            else
            {
                if (projectile.ai[1] > 60 && projectile.ai[1] < 99)
                {
                    if (projectile.ai[0] == 0)
                    {
                        target = -1;
                        float distance = 2000f;
                        for (int k = 0; k < 255; k++)
                        {
                            if (Main.player[k].active && !Main.player[k].dead)
                            {
                                Vector2 center = Main.player[k].Center;
                                float currentDistance = Vector2.Distance(center, projectile.Center);
                                if (currentDistance < distance || target == -1)
                                {
                                    distance = currentDistance;
                                    target = k;
                                }
                            }
                        }
                        if (target != -1)
                        {
                            projectile.ai[0] = 1;
                        }
                    }
                    else if (target >= 0 && target < Main.maxPlayers)
                    {
                        Player targetPlayer = Main.player[target];
                        if (!targetPlayer.active || targetPlayer.dead)
                        {
                            target = -1;
                            projectile.ai[0] = 0;
                        }
                        else
                        {
                            float currentRot = projectile.velocity.ToRotation();
                            Vector2 direction = targetPlayer.Center - projectile.Center;
                            float targetAngle = direction.ToRotation();
                            if (direction == Vector2.Zero)
                                targetAngle = currentRot;

                            float desiredRot = currentRot.AngleLerp(targetAngle, 0.1f);
                            projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy(desiredRot);
                        }
                    }
                    projectile.velocity *= 1.058f;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
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
                int dustIndex = Dust.NewDust(projectile.Center, 0, 0, DustID.Gold, 0.0f, 0.0f, 0, default, 1f);
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

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}