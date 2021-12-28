using ExtinctionTalesMod.Items.SummoningItems.DifficultyItems;
using ExtinctionTalesMod.Projectiles.Accessories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.ExPlayer
{
    public class ExtinctionPlayer : ModPlayer
    {
        public bool bossCurse;
        public bool overheatingPlayer;
        public bool energizedGelCore;
        public bool silkAssassinSet;
        public bool brillianceSet;
        public bool hellblazeSet;
        public bool fungusHeart;
        public bool sneakness;
        public bool slimeCorePet;
        public bool fInfection;
        public bool largeGem;
        public bool brokenBonesPlayer;
        public int sneaknessCooldown = 360;

        public override void ResetEffects()
        {
            bossCurse = false;
            brillianceSet = false;
            brokenBonesPlayer = false;
            energizedGelCore = false;
            silkAssassinSet = false;
            hellblazeSet = false;
            largeGem = false;
            fungusHeart = false;
            slimeCorePet = false;
            fInfection = false;
            overheatingPlayer = false;
        }

        public override void UpdateDead()
        {
            bossCurse = false;
            overheatingPlayer = false;
            fInfection = false;
            brokenBonesPlayer = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (fInfection)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 4;
            }

            if (brokenBonesPlayer)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 2;
            }
            if (overheatingPlayer)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 6;
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (energizedGelCore)
            {
                npc.AddBuff(BuffID.Slimed, 180, true);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            ExtinctionPlayerMiscEffects.ExtinctionPlayerPostUpdateMiscEffects(player, mod);
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (overheatingPlayer)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, DustID.Fire, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 2f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.2f;
                b *= 0.7f;
                fullBright = true;
            }
            if (fInfection)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, DustID.GlowingMushroom, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.2f;
                b *= 0.7f;
                fullBright = true;
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (fungusHeart && damage > 0)
            {
                double startAngle2 = Math.Atan2(player.velocity.X, player.velocity.Y) - (0.783f / 2f);
                double deltaAngle2 = 0.783f / 8f;
                int fDamage = Main.hardMode ? 16 : 8;
                if (player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        double offsetAngle2 = startAngle2 + (deltaAngle2 * (i + (i * i)) / 2.0) + (32f * i);
                        int spark = Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)(Math.Sin(offsetAngle2) * 5.0), (float)(Math.Cos(offsetAngle2) * 5.0), ModContent.ProjectileType<GlowingMushroomProj>(), (int)(float)fDamage, 1.25f, player.whoAmI, 0f, 0f);
                        int spark2 = Projectile.NewProjectile(player.Center.X, player.Center.Y, (float)(-(float)Math.Sin(offsetAngle2) * 5.0), (float)(-(float)Math.Cos(offsetAngle2) * 5.0), ModContent.ProjectileType<GlowingMushroomProj>(), (int)(float)fDamage, 1.25f, player.whoAmI, 0f, 0f);
                        Main.projectile[spark].timeLeft = 180;
                        Main.projectile[spark2].timeLeft = 180;
                    }
                }
            }
        }

        public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
        {
            Item item = new Item();
            item.SetDefaults(ModContent.ItemType<MisleadingHeart>());
            item.stack = 1;
            items.Add(item);

            item = new Item();
            item.SetDefaults(ModContent.ItemType<ZartonixEye>());
            item.stack = 1;
            items.Add(item);
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (silkAssassinSet)
            {
                sneakness = false;
                sneaknessCooldown = 360;
            }
        }

        public void SneakenessLevel()
        {
            int index = 0 + (player.bodyFrame.Y / 56);
            if (index >= Main.OffsetsPlayerHeadgear.Length)
            {
                index = 0;
            }

            Vector2 vector21 = Vector2.Zero;
            if (player.mount.Active && player.mount.Cart)
            {
                int num = Math.Sign(player.velocity.X);
                if (num == 0)
                {
                    num = player.direction;
                }

                vector21 = new Vector2(MathHelper.Lerp(0.0f, -8f, player.fullRotation / 0.7853982f),
                        MathHelper.Lerp(0.0f, 2f, Math.Abs(player.fullRotation / 0.7853982f)))
                    .RotatedBy(player.fullRotation);
                if (num == Math.Sign(player.fullRotation))
                {
                    vector21 *= MathHelper.Lerp(1f, 0.6f, Math.Abs(player.fullRotation / 0.7853982f));
                }
            }

            Vector2 spinningPoint1 =
                new Vector2((3 * player.direction) - (player.direction == 1 ? 1 : 0), -11.5f * player.gravDir) +
                (Vector2.UnitY * player.gfxOffY) + (player.Size / 2f) + Main.OffsetsPlayerHeadgear[index];
            Vector2 spinningPoint2 =
                new Vector2((3 * player.shadowDirection[1]) - (player.direction == 1 ? 1 : 0), -11.5f * player.gravDir) +
                (player.Size / 2f) + Main.OffsetsPlayerHeadgear[index];
            if (player.fullRotation != 0.0)
            {
                spinningPoint1 = spinningPoint1.RotatedBy(player.fullRotation, player.fullRotationOrigin);
                spinningPoint2 = spinningPoint2.RotatedBy(player.fullRotation, player.fullRotationOrigin);
            }

            float num1 = 0.0f;
            if (player.mount.Active)
            {
                num1 = player.mount.PlayerOffset;
            }

            Vector2 vector22 = player.position + spinningPoint1 + vector21;
            vector22.Y -= num1 / 2f;

            Vector2 vector23 = player.oldPosition + spinningPoint2 + vector21;
            vector23.Y -= num1 / 2f;

            int num3 = ((int)Vector2.Distance(vector22, vector23) / 3) + 1;
            if (Vector2.Distance(vector22, vector23) % 3.0 != 0.0)
            {
                ++num3;
            }

            for (float num4 = 1f; num4 <= (double)num3; ++num4)
            {
                Dust dust = Main.dust[Dust.NewDust(player.Center, 0, 0, DustID.Smoke, 0.0f, 0.0f, 0, new Color(129, 129, 129))];
                dust.position = Vector2.Lerp(vector23, vector22, num4 / num3);
                dust.noGravity = true;
                dust.velocity = Vector2.Zero;
                dust.customData = player;
                dust.scale = 1f;
                dust.shader = GameShaders.Armor.GetSecondaryShader(player.cYorai, player);
            }
        }

        public override void PostUpdateEquips()
        {
            if (silkAssassinSet)
            {
                if (sneaknessCooldown == 0)
                {
                    Main.PlaySound(new LegacySoundStyle(25, 1));
                }

                if (player.velocity.X != 0f)
                {
                    sneaknessCooldown--;
                }
                else
                {
                    sneaknessCooldown -= 2;
                }
            }
            else
            {
                sneakness = false;
                sneaknessCooldown = 420;
            }

            if (sneaknessCooldown <= 0)
            {
                sneakness = true;
                player.invis = true;
            }

            if (sneakness && silkAssassinSet)
            {
                SneakenessLevel();
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (sneakness)
            {
                for (int i = 0; i < 30; i++)
                {
                    int dust = Dust.NewDust(target.Center, target.width, target.height, DustID.Smoke, 0.0f, 0.0f, 0, new Color(129, 129, 129));
                    Main.dust[dust].velocity *= -1f;
                    Main.dust[dust].noGravity = true;

                    Vector2 vector21 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector21.Normalize();

                    Vector2 vector22 = vector21 * (Main.rand.Next(50, 100) * 0.04f);
                    Main.dust[dust].velocity = vector22;
                    vector22.Normalize();

                    Vector2 vector23 = vector22 * 20f;
                    Main.dust[dust].position = target.Center - vector23;
                }

                damage = (int)(damage * 1.2f);
                crit = true;
                sneakness = false;
                sneaknessCooldown = 300;
            }
            if (hellblazeSet)
            {
                target.AddBuff(BuffID.OnFire, 180);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (sneakness)
            {
                for (int i = 0; i < 30; i++)
                {
                    int dust = Dust.NewDust(target.Center, target.width, target.height, DustID.Smoke, 0.0f, 0.0f, 0, new Color(129, 129, 129));
                    Main.dust[dust].velocity *= -1f;
                    Main.dust[dust].noGravity = true;

                    Vector2 vector21 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector21.Normalize();

                    Vector2 vector22 = vector21 * (Main.rand.Next(50, 100) * 0.04f);
                    Main.dust[dust].velocity = vector22;
                    vector22.Normalize();

                    Vector2 vector23 = vector22 * 25f;
                    Main.dust[dust].position = target.Center - vector23;
                }

                damage = (int)(damage * 1.2f);
                crit = true;
                sneakness = false;
                sneaknessCooldown = 300;
            }
            if (hellblazeSet)
            {
                target.AddBuff(BuffID.OnFire, 180);
            }
        }
    }
}