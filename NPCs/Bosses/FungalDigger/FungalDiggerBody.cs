using ExtinctionTalesMod.Buffs.Debuffs;
using ExtinctionTalesMod.Projectiles.HostileProjectiles;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Bosses.FungalDigger
{
    public class FungalDiggerBody : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Fungal Digger");
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 48;
            npc.lifeMax = 9000;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.defense = 24;
            npc.damage = 32;
            npc.knockBackResist = 0f;
            npc.npcSlots = 1f;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.dontCountMe = true;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.aiStyle = -1;
            npc.buffImmune[ModContent.BuffType<FungalInfection>()] = true;
        }

        public bool Exposed => npc.localAI[0] == 1;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(npc.localAI[0]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            npc.localAI[0] = reader.ReadSingle();
        }

        private NPC Head => Main.npc[(int)npc.ai[2]];

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override bool PreAI()
        {
            var exposedBodies = Main.npc.Where(x => x.active && (x.type == ModContent.NPCType<FungalDiggerBody>() || x.type == ModContent.NPCType<FungalDiggerTail>()) && x.localAI[0] > 0).Count();
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (exposedBodies < 7 && Main.rand.NextBool(50) || (++npc.localAI[1] % 60 == 0 && Main.rand.NextBool(50)))
                {
                    if (!Exposed)
                    {
                        npc.localAI[0] = 1;
                        npc.netUpdate = true;
                    }
                }

                if (exposedBodies > 10 || (npc.localAI[1] % 60 == 0 && Main.rand.NextBool(50)))
                {
                    if (Exposed)
                    {
                        npc.localAI[0] = 0;
                        npc.netUpdate = true;
                    }
                }
                if (npc.localAI[2] >= 601)
                {
                    npc.localAI[2] = 0f;
                }
            }
            if (Exposed)
            {
                npc.defense = 22;
                npc.dontTakeDamage = false;
            }

            Player player = Main.player[npc.target];
            if (Head.ai[2] == 1)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    if (--npc.ai[3] == 0)
                    {
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 9);
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                        if (Main.rand.NextBool(2))
                        {
                            float num941 = 1f;
                            Vector2 vector104 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height / 2);
                            float num942 = player.position.X + player.width * 0.5f - vector104.X + Main.rand.Next(-20, 21);
                            float num943 = player.position.Y + player.height * 0.5f - vector104.Y + Main.rand.Next(-20, 21);
                            float num944 = (float)Math.Sqrt(num942 * num942 + num943 * num943);
                            num944 = num941 / num944;
                            num942 *= num944;
                            num943 *= num944;
                            num942 += Main.rand.Next(-10, 11) * 0.0125f;
                            num943 += Main.rand.Next(-10, 11) * 0.0125f;
                            int num946 = ModContent.ProjectileType<GlowingMushroom>();
                            vector104.X += num942 * 4f;
                            vector104.Y += num943 * 2.5f;
                            int num947 = Projectile.NewProjectile(vector104.X, vector104.Y, num942, num943, num946, NPCUtils.RealDamage(25, 1.25f), 0f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num947].timeLeft = 350;
                        }
                    }
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    if (--npc.ai[3] == 0)
                    {
                        Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 9);
                    }
                }
            }
            else
            {
                npc.ai[3] = Main.rand.Next(175, 190);
            }

            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            if (npc.ai[2] > 0)
            {
                npc.realLife = (int)npc.ai[2];
            }

            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }

            if (Main.player[npc.target].dead && npc.timeLeft > 300)
            {
                npc.timeLeft = 300;
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                Vector2 npcCenter = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);

                float dirX = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - npcCenter.Y;

                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;

                float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);

                float dist = (length - (float)npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;

                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + posX;
                npc.position.Y = npc.position.Y + posY;
            }
            return true;
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 10; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * hitDirection, -2.5f, 0, new Color(22, 26, 54), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalDiggerBodyGore"), 1f);
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<FungalInfection>(), 120);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
        }
    }
}