using ExtinctionTalesMod.Items.Equipment.Equipables.Pets;
using ExtinctionTalesMod.Items.Equipment.Vanities.BossesVanities;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.TreasureBags;
using ExtinctionTalesMod.Items.Weapons.BossDrops.CyborgSlime;
using ExtinctionTalesMod.NPCs.Enemies;
using ExtinctionTalesMod.Projectiles.HostileProjectiles;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Bosses.CyborgSlime
{
    [AutoloadBossHead]
    public class CyborgSlime : ModNPC
    {
        private bool exploded = false;
        private bool shot;
        private bool trail;
        private bool text = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyborg Slime");
            Main.npcFrameCount[npc.type] = 6;
            NPCID.Sets.TrailCacheLength[npc.type] = 3;
            NPCID.Sets.TrailingMode[npc.type] = 0;
        }

        public override void SetDefaults()
        {
            npc.width = 150;
            npc.height = 100;
            npc.damage = 46;
            npc.defense = 26;
            npc.lifeMax = 7500;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 33000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            animationType = NPCID.KingSlime;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = false;
            npc.noGravity = false;
            npc.npcSlots = 5f;

            music = MusicID.Boss1;
            bossBag = ModContent.ItemType<CyborgSlimeBag>();
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
                return;
            }
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(10, 21));
            Item.NewItem(npc.getRect(), ModContent.ItemType<HardwareBit>(), Main.rand.Next(10, 21));
            int choice = Main.rand.Next(7);
            if (choice == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<CyborgSlimeMask>());
            }
            if (choice == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<SlimeCoreItem>());
            }
            if (choice == 2)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<MechanicalDagger>());
            }
        }

        public override bool PreNPCLoot()
        {
            ExtinctionWorld.downedCyborgSlime = true;
            ExtinctionNet.SyncMultiplayer();
            return true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override bool CheckActive()
        {
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
                return false;
            return true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(npc.ai[0]);
            writer.Write(npc.ai[1]);
            writer.Write(npc.ai[2]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            npc.ai[0] = reader.ReadSingle();
            npc.ai[1] = reader.ReadSingle();
            npc.ai[2] = reader.ReadSingle();
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            float lifeRatio = (float)npc.life / npc.lifeMax;
            int jumpHeight = Main.rand.Next(5);
            npc.TargetClosest(true);
            Vector2 range = npc.Center - player.Center;
            range.Normalize();
            if (npc.velocity.Y == 0)
            {
                npc.velocity.X = 0f;
            }

            if (!player.active || player.dead)
            {
                npc.ai[1] = 0;
                npc.ai[2] = 0;
                npc.TargetClosest(false);
                npc.noTileCollide = true;
                npc.velocity.Y++;
            }

            if (npc.velocity.Y > 0 && npc.position.Y < player.Center.Y - (npc.height + 125) && !npc.collideX && !npc.collideY)
            {
                npc.noTileCollide = true;
            }
            else
            {
                npc.noTileCollide = false;
            }

            if (npc.ai[0] == 0)
            {
                trail = false;
                npc.ai[2]++;
                if (npc.ai[2] >= 600)
                {
                    npc.ai[0] = 1;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
                npc.ai[1]++;
                if (npc.ai[1] >= 180 && npc.velocity.Y == 0)
                {
                    if (npc.Center.X >= player.Center.X)
                    {
                        npc.velocity.X -= 5;
                    }
                    if (npc.Center.X <= player.Center.X)
                    {
                        npc.velocity.X += 5;
                    }
                    if (jumpHeight < 3)
                    {
                        npc.velocity.Y -= 12;
                    }
                    else
                    {
                        npc.velocity.Y -= 11;
                    }

                    npc.ai[1] = 0;
                }
            }

            if (npc.ai[0] == 1)
            {
                trail = false;
                text = false;
                npc.ai[2]++;
                if (npc.ai[2] >= 70 && lifeRatio >= 0.5 || npc.ai[2] >= 130 && lifeRatio < 0.5)
                {
                    npc.ai[0] = 2;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
                npc.ai[1]++;
                if (npc.ai[1] == 60 && !text)
                {
                    CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(20, 100, 100), "Releasing Missiles");
                    text = true;
                }
                if (npc.ai[1] >= 60 && npc.velocity.Y == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Main.PlaySound(SoundID.Item61, npc.Center);
                        int p = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-60, 60), npc.Center.Y + Main.rand.Next(-60, 60), Main.rand.NextFloat(-5.3f, 5.3f), Main.rand.NextFloat(-5.3f, 5.3f), ModContent.ProjectileType<CyborgMissile>(), NPCUtils.RealDamage(20, 1.5f), 1, Main.myPlayer, 0, 0);
                        if (Main.projectile[p].velocity == Vector2.Zero)
                        {
                            Main.projectile[p].velocity = new Vector2(2.5f, 2.5f);
                        }
                        if (Main.projectile[p].velocity.X < 2.5f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(1) || Main.projectile[p].velocity.X > -2.5f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(-1))
                        {
                            Main.projectile[p].velocity.X *= 2.35f;
                        }
                    }
                    npc.ai[1] = 0;
                }
            }

            if (npc.ai[0] == 2)
            {
                trail = false;
                npc.ai[2]++;
                if (npc.ai[2] >= 480)
                {
                    npc.ai[0] = 3;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }

                npc.ai[1]++;
                if (npc.ai[1] >= 120 && npc.velocity.Y == 0)
                {
                    if (npc.Center.X >= player.Center.X)
                    {
                        npc.velocity.X -= 5;
                    }

                    if (npc.Center.X <= player.Center.X)
                    {
                        npc.velocity.X += 5;
                    }
                    if (jumpHeight < 3)
                    {
                        npc.velocity.Y -= 12;
                    }
                    else npc.velocity.Y -= 11;
                    npc.ai[1] = 0;
                }
            }

            if (npc.ai[0] == 3)
            {
                trail = true;
                if (!exploded)
                {
                    npc.position.Y = player.Center.Y - 600f;
                    npc.position.X = player.Center.X - npc.width * 0.5f;
                    npc.velocity.X = 0;
                    for (int z = 0; z < 30; z++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric, 0f, 0f, 0, default, 2f);
                    }
                    shot = true;
                    exploded = true;
                    Main.PlaySound(SoundID.Item14);
                    npc.ai[1] = 0;
                }
                if (npc.ai[1] < 30)
                {
                    npc.velocity.Y = 0;
                }
                if (npc.ai[1] > 30 && npc.velocity.Y == 0 && shot)
                {
                    if (lifeRatio >= 0.5f)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 12);
                            Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.4f, 6, 0, ModContent.ProjectileType<SlimeRay>(), NPCUtils.RealDamage(24, 1.5f), 1);
                            Projectile.NewProjectile(npc.Center.X - npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.4f, -6, 0, ModContent.ProjectileType<SlimeRay>(), NPCUtils.RealDamage(24, 1.5f), 1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 12);
                            Projectile.NewProjectile(npc.Center.X + npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.4f, 8, (i - 1) * 1.3f, ModContent.ProjectileType<SlimeRay>(), NPCUtils.RealDamage(24, 1.5f), 1);
                            Projectile.NewProjectile(npc.Center.X - npc.width / 2, npc.Center.Y + npc.height / 2 - i * npc.height * 0.4f, -8, (i - 1) * 1.3f, ModContent.ProjectileType<SlimeRay>(), NPCUtils.RealDamage(24, 1.5f), 1);
                        }
                    }
                    shot = false;
                }

                npc.ai[1]++;
                npc.ai[2]++;
                if (npc.ai[1] >= 200)
                {
                    exploded = false;
                    NPC.NewNPC((int)npc.Center.X + Main.rand.Next(15) - Main.rand.Next(15), (int)npc.Center.Y + Main.rand.Next(15) - Main.rand.Next(15), ModContent.NPCType<MetalheadSlime>());
                    NPC.NewNPC((int)npc.Center.X + Main.rand.Next(15) - Main.rand.Next(15), (int)npc.Center.Y + Main.rand.Next(15) - Main.rand.Next(15), ModContent.NPCType<MetalheadSlime>());
                    npc.ai[0] = 0;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric, 0f, 0f, 0, default, 1f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CyborgSlimeGore"), 1f);
            }
        }

        public override bool CheckDead()
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 a = new Vector2(npc.Center.X + Main.rand.Next(20) - Main.rand.Next(20), npc.Center.Y + Main.rand.Next(20) - Main.rand.Next(20));
                NPC.NewNPC((int)a.X, (int)a.Y, ModContent.NPCType<MetalheadSlime>());
            }

            return true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(npc.spriteDirection, npc.gfxOffY - 5).RotatedBy(npc.rotation), npc.frame,
                             lightColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);

            if (trail)
            {
                Vector2 drawOrigin = npc.frame.Size() / 2;
                for (int k = 0; k < npc.oldPos.Length; k++)
                {
                    Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + new Vector2(npc.width / 2, npc.height / 2) + new Vector2(npc.spriteDirection, npc.gfxOffY - 5).RotatedBy(npc.rotation);
                    Color color = npc.GetAlpha(lightColor) * (float)((float)(npc.oldPos.Length - k) / npc.oldPos.Length / 2);
                    spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, new Microsoft.Xna.Framework.Rectangle?(npc.frame), color, npc.rotation, drawOrigin, npc.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}