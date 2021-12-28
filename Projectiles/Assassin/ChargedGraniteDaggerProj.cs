using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles.Assassin
{
    public class ChargedGraniteDaggerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Dagger Projectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.penetrate = 2;
            projectile.aiStyle = -1;
            projectile.light = 0.5f;
            projectile.timeLeft = 600;
            projectile.hostile = false;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (projectile.ai[0] == 1f)
            {
                int npcIndex = (int)projectile.ai[1];
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                    {
                        drawCacheProjsBehindNPCsAndTiles.Add(index);
                    }
                    else
                    {
                        drawCacheProjsBehindNPCs.Add(index);
                    }

                    return;
                }
            }
            drawCacheProjsBehindProjectiles.Add(index);
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = height = 10;
            return true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(45f)).ToRotationVector2();
            usePos += rotVector * 16f;
            const int NUM_DUSTS = 20;
            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, DustID.Glass);
                dust.position = (dust.position + projectile.Center) / 2f;
                dust.velocity += rotVector * 2f;
                dust.velocity *= 0.5f;
                dust.noGravity = true;
                usePos -= rotVector * 8f;
            }
        }

        public bool IsStickingToTarget
        {
            get => projectile.ai[0] == 1f;
            set => projectile.ai[0] = value ? 1f : 0f;
        }

        public int TargetWhoAmI
        {
            get => (int)projectile.ai[1];
            set => projectile.ai[1] = value;
        }

        private const int MAX_STICKY_JAVELINS = 3;
        private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS];

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            IsStickingToTarget = true;
            TargetWhoAmI = target.whoAmI;
            projectile.velocity =
                (target.Center - projectile.Center) *
                0.75f;
            projectile.netUpdate = true;
            projectile.damage = 0;
            UpdateStickyJavelins(target);
        }

        private void UpdateStickyJavelins(NPC target)
        {
            int currentJavelinIndex = 0;

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile currentProjectile = Main.projectile[i];
                if (i != projectile.whoAmI
                    && currentProjectile.active
                    && currentProjectile.owner == Main.myPlayer
                    && currentProjectile.type == projectile.type
                    && currentProjectile.modProjectile is ChargedGraniteDaggerProj javelinProjectile
                    && javelinProjectile.IsStickingToTarget
                    && javelinProjectile.TargetWhoAmI == target.whoAmI)
                {
                    _stickingJavelins[currentJavelinIndex++] = new Point(i, currentProjectile.timeLeft);
                    if (currentJavelinIndex >= _stickingJavelins.Length)
                        break;
                }
            }

            if (currentJavelinIndex >= MAX_STICKY_JAVELINS)
            {
                int oldJavelinIndex = 0;
                for (int i = 1; i < MAX_STICKY_JAVELINS; i++)
                {
                    if (_stickingJavelins[i].Y < _stickingJavelins[oldJavelinIndex].Y)
                    {
                        oldJavelinIndex = i;
                    }
                }
                Main.projectile[_stickingJavelins[oldJavelinIndex].X].Kill();
            }
        }

        private const int MAX_TICKS = 45;

        private const int ALPHA_REDUCTION = 25;

        public override void AI()
        {
            UpdateAlpha();
            if (IsStickingToTarget) StickyAI();
            else NormalAI();
        }

        private void UpdateAlpha()
        {
            if (projectile.alpha > 0)
            {
                projectile.alpha -= ALPHA_REDUCTION;
            }

            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
        }

        private void NormalAI()
        {
            TargetWhoAmI++;
            if (TargetWhoAmI >= MAX_TICKS)
            {
                const float velXmult = 0.98f;
                const float velYmult = 0.35f;
                TargetWhoAmI = MAX_TICKS;
                projectile.velocity.X *= velXmult;
                projectile.velocity.Y += velYmult;
            }
            projectile.rotation =
                projectile.velocity.ToRotation() +
                MathHelper.ToRadians(45f);

            if (Main.rand.NextBool(3))
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, DustID.Glass,
                    projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
                dust.velocity += projectile.velocity * 0.3f;
                dust.velocity *= 0.2f;
            }
            if (Main.rand.NextBool(4))
            {
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, DustID.Granite,
                    0, 0, 254, Scale: 0.3f);
                dust.velocity += projectile.velocity * 0.5f;
                dust.velocity *= 0.5f;
            }
        }

        private void StickyAI()
        {
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            const int aiFactor = 15;
            projectile.localAI[0]++;
            bool hitEffect = projectile.localAI[0] % 30f == 0f;
            int projTargetIndex = (int)TargetWhoAmI;
            if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
            {
                projectile.Kill();
            }
            else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
            {
                projectile.Center = Main.npc[projTargetIndex].Center - (projectile.velocity * 2f);
                projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                if (hitEffect)
                {
                    Main.npc[projTargetIndex].HitEffect(0, 1.0);
                }
            }
            else
            {
                projectile.Kill();
            }
        }
    }
}