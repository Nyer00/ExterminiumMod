using ExtinctionTalesMod.Buffs.Debuffs;
using ExtinctionTalesMod.Projectiles.HostileProjectiles;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Bosses.FungalDigger
{
    public class FungalDiggerTail : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Fungal Digger");
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 64;
            npc.damage = 32;
            npc.defense = 12;
            npc.lifeMax = 9000;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.aiStyle = 6;
            npc.knockBackResist = 0f;
            npc.npcSlots = 6f;
            npc.boss = true;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
            npc.buffImmune[ModContent.BuffType<FungalInfection>()] = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            int parent = NPC.FindFirstNPC(ModContent.NPCType<FungalDiggerHead>());
            if (parent < 0 || parent >= Main.npc.Length)
            {
                npc.active = false;
                return;
            }
            if (!Main.npc[(int)npc.ai[1]].active)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
            }
            if (Main.npc[parent].ai[2] != 1)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.localAI[0] += Main.expertMode ? 2f : 1f;
                    if (npc.localAI[0] >= 200f)
                    {
                        npc.localAI[0] = 0f;
                        npc.TargetClosest(true);
                        if (Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                        {
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 12);
                            float num941 = 4f;
                            Vector2 vector104 = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                            float num942 = player.position.X + (player.width * 0.5f) - vector104.X + Main.rand.Next(-20, 21);
                            float num943 = player.position.Y + (player.height * 0.5f) - vector104.Y + Main.rand.Next(-20, 21);
                            float num944 = (float)Math.Sqrt((num942 * num942) + (num943 * num943));
                            num944 = num941 / num944;
                            num942 *= num944;
                            num943 *= num944;
                            vector104.X += num942 * 5f;
                            vector104.Y += num943 * 5f;
                            int num947 = Projectile.NewProjectile(vector104.X, vector104.Y, num942, num943, ModContent.ProjectileType<GlowingMushroom>(), NPCUtils.RealDamage(24, 1.5f), 0f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num947].timeLeft = 300;
                            npc.netUpdate = true;
                        }
                    }
                }
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    npc.localAI[0] += Main.expertMode ? 2f : 1f;
                    if (npc.localAI[0] >= 200f)
                    {
                        npc.localAI[0] = 0f;
                        if (Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                        {
                            Main.PlaySound(SoundID.Item, (int)npc.Center.X, (int)npc.Center.Y, 12);
                        }
                    }
                }
            }
            else
            {
                npc.localAI[0] = 0;
            }
            if (npc.ai[2] > 0)
            {
                npc.realLife = (int)npc.ai[2];
            }

            if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }

            if (npc.ai[1] < (double)Main.npc.Length)
            {
                Vector2 npcCenter = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height * 0.5f));
                float dirX = Main.npc[(int)npc.ai[1]].position.X + (Main.npc[(int)npc.ai[1]].width / 2) - npcCenter.X;
                float dirY = Main.npc[(int)npc.ai[1]].position.Y + (Main.npc[(int)npc.ai[1]].height / 2) - npcCenter.Y;
                npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;
                float length = (float)Math.Sqrt((dirX * dirX) + (dirY * dirY));
                float dist = (length - npc.width) / length;
                float posX = dirX * dist;
                float posY = dirY * dist;
                npc.velocity = Vector2.Zero;
                npc.position.X += posX;
                npc.position.Y += posY;
            }
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
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalDiggerTailGore"), 1f);
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