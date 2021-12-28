using ExtinctionTalesMod.Items.Ores;
using ExtinctionTalesMod.Items.TreasureBags;
using ExtinctionTalesMod.Items.Weapons.BossDrops.RuneWarrior;
using ExtinctionTalesMod.Projectiles.HostileProjectiles;
using ExtinctionTalesMod.Tiles;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Bosses.RuneWarrior
{
    [AutoloadBossHead]
    public class RuneWarrior : ModNPC
    {
        private int speedX = 0;
        private int speedY = 0;
        private bool swordLaunch = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Warrior");
            Main.npcFrameCount[npc.type] = 5;
        }

        public override void SetDefaults()
        {
            npc.width = 120;
            npc.height = 144;
            npc.damage = 52;
            npc.defense = 32;
            npc.lifeMax = 32000;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.boss = true;
            npc.value = 66000;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.npcSlots = 5f;

            music = MusicID.Boss3;
            bossBag = ModContent.ItemType<RuneWarriorBag>();
        }

        public override bool PreNPCLoot()
        {
            ExtinctionWorld.downedRuneWarrior = true;
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

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.3f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }

        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
            float lifeRatio = (float)npc.life / npc.lifeMax;
            npc.TargetClosest(true);

            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y -= 2000;
            }
            if (player.ZoneDungeon)
            {
                npc.damage = 50;
                npc.defense = 32;
            }
            else
            {
                npc.damage = 36;
                npc.defense = 24;
            }

            npc.ai[0]++;
            if (npc.ai[0] < 120 || (npc.ai[0] > 120 && npc.ai[0] < 890) || (npc.ai[0] > 1060 && npc.ai[0] < 1100) || (npc.ai[0] > 1380 && npc.ai[0] < 1980))
            {
                swordLaunch = false;
                float value12 = (float)Math.Cos(Main.GlobalTime % 2.4f / 2.4f * 6.28318548f) * 60f;
                if (npc.Center.X >= player.Center.X && speedX >= -37)
                {
                    speedX--;
                }
                else if (npc.Center.X <= player.Center.X && speedX <= 37)
                {
                    speedX++;
                }

                npc.velocity.X = speedX * 0.16f;
                npc.rotation = npc.velocity.X * 0.04f;

                if (npc.Center.Y >= player.Center.Y - 80f + value12 && speedY >= -20)
                {
                    speedY--;
                }
                else if (npc.Center.Y <= player.Center.Y - 80f + value12 && speedY <= 20)
                {
                    speedY++;
                }

                npc.velocity.Y = speedY * 0.12f;
            }

            if (npc.ai[0] > 900 && npc.ai[0] < 1050)
            {
                npc.velocity = Vector2.Zero;
                if (npc.ai[0] % 15 == 0)
                {
                    if (!swordLaunch && lifeRatio >= 0.5f)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Main.PlaySound(SoundID.Item20, npc.Center);
                            int p = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-60, 60), npc.Center.Y + Main.rand.Next(-60, 60), Main.rand.NextFloat(-5.3f, 5.3f), Main.rand.NextFloat(-5.3f, 5.3f), ModContent.ProjectileType<RuneWarriorSword>(), NPCUtils.RealDamage(38, 1.5f), 1, Main.myPlayer, 0, 0);
                            if (Main.projectile[p].velocity == Vector2.Zero)
                            {
                                Main.projectile[p].velocity = new Vector2(2.25f, 2.25f);
                            }
                            if ((Main.projectile[p].velocity.X < 2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(1)) || (Main.projectile[p].velocity.X > -2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(-1)))
                            {
                                Main.projectile[p].velocity.X *= 2.15f;
                            }
                            swordLaunch = true;
                        }
                    }
                    if (!swordLaunch && lifeRatio <= 0.5f)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Main.PlaySound(SoundID.Item20, npc.Center);
                            int p = Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-60, 60), npc.Center.Y + Main.rand.Next(-60, 60), Main.rand.NextFloat(-5.3f, 5.3f), Main.rand.NextFloat(-5.3f, 5.3f), ModContent.ProjectileType<RuneWarriorSword>(), NPCUtils.RealDamage(38, 1.5f), 1, Main.myPlayer, 0, 0);
                            if (Main.projectile[p].velocity == Vector2.Zero)
                            {
                                Main.projectile[p].velocity = new Vector2(2.25f, 2.25f);
                            }
                            if ((Main.projectile[p].velocity.X < 2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(1)) || (Main.projectile[p].velocity.X > -2.25f && Math.Sign(Main.projectile[p].velocity.X) == Math.Sign(-1)))
                            {
                                Main.projectile[p].velocity.X *= 2.15f;
                            }
                            swordLaunch = true;
                        }
                    }
                }
            }

            if (npc.ai[0] >= 1120 && npc.ai[0] < 1370)
            {
                swordLaunch = false;
                npc.direction = Math.Sign(player.Center.X - npc.Center.X);
                if (npc.ai[0] < 1280)
                {
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                    Vector2 playerCenter = player.Center;
                    playerCenter.X += (npc.Center.X < player.Center.X) ? -240 : 240;
                    playerCenter.Y -= 15;

                    float vel = MathHelper.Clamp(npc.Distance(playerCenter) / 12, 8, 30);
                    npc.velocity = Vector2.Lerp(npc.velocity, npc.DirectionTo(playerCenter) * vel, 0.08f);
                }
                else
                {
                    npc.rotation = npc.velocity.X * 0.02f;
                    if (npc.ai[0] < 1320)
                    {
                        npc.velocity.X = -npc.spriteDirection;
                        npc.velocity.Y = 0;
                    }
                    else if (npc.ai[0] == 1320 || npc.ai[0] == 1360)
                    {
                        Main.PlaySound(new LegacySoundStyle(SoundID.Roar, 0), npc.Center);
                        npc.velocity.X = MathHelper.Clamp(Math.Abs((player.Center.X - npc.Center.X) / 10), 20, 26) * npc.spriteDirection;
                        npc.netUpdate = true;
                    }
                    else if (npc.direction != npc.spriteDirection || npc.ai[1] > 0)
                    {
                        npc.ai[1]++;
                        npc.velocity.X = MathHelper.Lerp(npc.velocity.X, 0, 0.06f);
                    }
                }
            }

            if (npc.ai[0] > 2000)
            {
                npc.ai[0] = 0;
                npc.ai[1] = 0;
                npc.ai[2] = 0;
                npc.netUpdate = true;
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override void NPCLoot()
        {
            if (!ExtinctionWorld.brillianceOreGen)
            {
                string text = "A light from the sky spread trough your world.";
                Color textColor = Color.Yellow;
                ExtinctionUtils.DisplayLocalText(text, new Color?(textColor));
                ExtinctionWorld.brillianceOreGen = true;
                for (double num = 0.0; num < (Main.maxTilesX - 200) * (Main.maxTilesY - 150 - (int)Main.rockLayer) / 8000.0; ++num)
                {
                    WorldGen.OreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 8), (ushort)ModContent.TileType<BrillianceOreTile>());
                }
                ExtinctionNet.SyncMultiplayer();
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
                return;
            }
            int choice = Main.rand.Next(4);
            Item.NewItem(npc.getRect(), ModContent.ItemType<BrillianceOre>(), Main.rand.Next(15, 26));
            if (choice == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<RuneBlade>());
            }
            if (choice == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<PossessedPike>());
            }
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            float lifeRatio = (float)npc.life / npc.lifeMax;
            if (lifeRatio < 0.5f)
            {
                npc.damage = (int)(npc.damage * 1.5);
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 15; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Gold, 0f, 0f, 0, default, 1f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RuneWarriorGore"), 1f);
            }
        }
    }
}