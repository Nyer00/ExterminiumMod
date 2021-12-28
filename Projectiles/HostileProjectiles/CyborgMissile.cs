using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.HostileProjectiles
{
    public class CyborgMissile : ModProjectile
    {
        private int target;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyborg Missile");
        }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 38;
            projectile.hostile = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.light = 0.5f;
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            projectile.spriteDirection = projectile.direction;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100);
            Main.dust[dust].scale = 1.5f;
            Main.dust[dust].noGravity = true;
            projectile.ai[1]++;
            if (projectile.ai[1] < 99)
            {
                projectile.tileCollide = false;
            }
            else
            {
                projectile.tileCollide = true;
            }
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
                    projectile.velocity *= 1.1f;
                }
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            projectile.Kill();
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 1.4f;
            }
            for (int i = 0; i < 30; i++)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default, 2f);
                Main.dust[dustIndex].velocity *= 3f;
            }
            Main.PlaySound(SoundID.Item62, projectile.position);
        }
    }
}