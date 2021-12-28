using ExtinctionTalesMod.Buffs.Debuffs;
using ExtinctionTalesMod.Items.TreasureBags;
using ExtinctionTalesMod.Items.Weapons.BossDrops.AncientFungalDigger;
using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Bosses.FungalDigger
{
    [AutoloadBossHead]
    public class FungalDiggerHead : ModNPC
    {
        private int timer = 20;
        public bool flies = true;
        public bool directional = false;
        public float speed = 10.5f;
        public float turnSpeed = 0.19f;
        public bool tail = false;
        public int minLength = 29;
        public int maxLength = 30;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Fungal Digger");
        }

        public override void SetDefaults()
        {
            npc.damage = 34;
            npc.lifeMax = 9000;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.width = 54;
            npc.height = 62;
            npc.defense = 12;
            npc.knockBackResist = 0f;
            npc.npcSlots = 6f;
            npc.boss = true;
            npc.value = 40000;
            npc.behindTiles = true;
            npc.noGravity = true;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
            npc.buffImmune[ModContent.BuffType<FungalInfection>()] = true;

            music = MusicID.Boss3;
            bossBag = ModContent.ItemType<FungalDiggerBag>();
        }

        private int chargeTimer;

        private bool charge
        {
            get => npc.ai[2] == 1;
            set => npc.ai[2] = value ? 1 : 0;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(chargeTimer);
            writer.Write(npc.localAI[0]);
            writer.Write(npc.localAI[1]);
            writer.Write(npc.localAI[2]);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            chargeTimer = reader.ReadInt32();
            npc.localAI[0] = reader.ReadSingle();
            npc.localAI[1] = reader.ReadSingle();
            npc.localAI[2] = reader.ReadSingle();
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }

        public override bool CheckActive()
        {
            return true;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (!charge)
            {
                timer++;
                if (timer == 10 || timer == 400)
                {
                    if (Main.expertMode)
                    {
                        Main.PlaySound(SoundID.Pixie, (int)npc.position.X, (int)npc.position.Y, 91);
                        Vector2 direction = Main.player[npc.target].Center - npc.Center;
                        direction.Normalize();
                        direction.X *= 4f;
                        direction.Y *= 4f;
                    }
                }
            }
            if (timer == 700)
            {
                timer = 0;
                npc.netUpdate = true;
            }
            chargeTimer++;
            if (npc.active)
            {
                npc.aiStyle = 6;
                aiType = -1;
                if (player.Distance(npc.Center) > 1800 && chargeTimer < 700 && player.active && !player.dead && player.ZoneGlowshroom)
                    chargeTimer = 700;

                if (chargeTimer == 700)
                {
                    npc.netUpdate = true;
                    Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                }
                if (chargeTimer >= 700 && chargeTimer <= 900)
                {
                    charge = true;
                }
                else if (chargeTimer > 900)
                {
                    charge = false;
                    chargeTimer = 0;
                }
                if (npc.ai[3] > 0f)
                {
                    npc.realLife = (int)npc.ai[3];
                }

                if (npc.target < 0 || npc.target == 255 || player.dead)
                {
                    npc.velocity.Y += 800f;
                }

                npc.velocity.Length();
                if (npc.alpha != 0)
                {
                    for (int num934 = 0; num934 < 2; num934++)
                    {
                        int num935 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, DustID.Electric, 0f, 0f, 100, default, 2f);
                        Main.dust[num935].noGravity = true;
                        Main.dust[num935].noLight = true;
                    }
                }
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (!tail && npc.ai[0] == 0f)
                {
                    int after = npc.whoAmI;
                    for (int num36 = 0; num36 < maxLength; num36++)
                    {
                        int before;
                        if (num36 >= 0 && num36 < minLength)
                        {
                            before = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), ModContent.NPCType<FungalDiggerBody>(), npc.whoAmI);
                        }
                        else
                        {
                            before = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), ModContent.NPCType<FungalDiggerTail>(), npc.whoAmI);
                        }
                        Main.npc[before].realLife = npc.whoAmI;
                        Main.npc[before].ai[2] = npc.whoAmI;
                        Main.npc[before].ai[1] = after;
                        Main.npc[after].ai[0] = before;
                        npc.netUpdate = true;
                        after = before;
                    }
                    tail = true;
                }
                if (!npc.active && Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }
            }
            int num180 = (int)(npc.position.X / 16f) - 1;
            int num181 = (int)((npc.position.X + npc.width) / 16f) + 2;
            int num182 = (int)(npc.position.Y / 16f) - 1;
            int num183 = (int)((npc.position.Y + npc.height) / 16f) + 2;

            if (num180 < 0)
            {
                num180 = 0;
            }

            if (num181 > Main.maxTilesX)
            {
                num181 = Main.maxTilesX;
            }

            if (num182 < 0)
            {
                num182 = 0;
            }

            if (num183 > Main.maxTilesY)
            {
                num183 = Main.maxTilesY;
            }

            npc.localAI[1] = 0f;
            if (directional)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.spriteDirection = -1;
                }
            }
            if (player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.velocity.Y--;

                if (npc.position.Y < 0)
                {
                    npc.active = false;
                }
            }
            float num188 = speed;
            float num189 = turnSpeed;
            Vector2 vector18 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num191 = player.position.X + player.width / 2;
            float num192 = player.position.Y + player.height / 2;
            int num42 = -1;
            int num43 = (int)(player.Center.X / 16f);
            int num44 = (int)(player.Center.Y / 16f);
            for (int num45 = num43 - 2; num45 <= num43 + 2; num45++)
            {
                for (int num46 = num44; num46 <= num44 + 15; num46++)
                {
                    if (WorldGen.SolidTile2(num45, num46))
                    {
                        num42 = num46;
                        break;
                    }
                }
                if (num42 > 0)
                    break;
            }
            if (num42 > 0)
            {
                npc.defense = 15;
                num42 *= 16;
                float num47 = num42 - 560;
                if (player.position.Y > num47 && !charge)
                {
                    num192 = num47;
                    if (Math.Abs(npc.Center.X - player.Center.X) < 170f)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            num191 = player.Center.X + 170f;
                        }
                        else
                        {
                            num191 = player.Center.X - 170f;
                        }
                    }
                }
                else if (charge && player.position.Y < num47)
                {
                    num192 = num47;
                    if (Math.Abs(npc.Center.X - player.Center.X) < 450f)
                    {
                        if (npc.velocity.X > 0f)
                        {
                            num191 = player.Center.X + 450f;
                        }
                        else
                        {
                            num191 = player.Center.X - 450f;
                        }
                    }
                }
            }
            else
            {
                npc.defense = 0;
                num188 = Main.expertMode ? 12.5f : 10f;
                num189 = Main.expertMode ? 0.25f : 0.2f;
            }
            float num48 = num188 * 1.23f;
            float num49 = num188 * 0.7f;
            float num50 = npc.velocity.Length();
            if (num50 > 0f)
            {
                if (num50 > num48)
                {
                    npc.velocity.Normalize();
                    npc.velocity *= num48;
                }
                else if (num50 < num49)
                {
                    npc.velocity.Normalize();
                    npc.velocity *= num49;
                }
            }
            num191 = (int)(num191 / 16f) * 16;
            num192 = (int)(num192 / 16f) * 16;
            vector18.X = (int)(vector18.X / 16f) * 16;
            vector18.Y = (int)(vector18.Y / 16f) * 16;
            num191 -= vector18.X;
            num192 -= vector18.Y;
            float num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector18 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num191 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector18.X;
                    num192 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector18.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2(num192, num191) + 1.57f;
                num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
                int num194 = npc.width;
                num193 = (num193 - num194) / num193;
                num191 *= num193;
                num192 *= num193;
                npc.velocity = Vector2.Zero;
                npc.position.X = npc.position.X + num191;
                npc.position.Y = npc.position.Y + num192;
                if (directional)
                {
                    if (num191 < 0f)
                    {
                        npc.spriteDirection = 1;
                    }

                    if (num191 > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (charge && player.active && !player.dead)
                {
                    timer = 0;
                    if (chargeTimer == 700)
                    {
                        npc.localAI[0] = npc.velocity.ToRotation();
                    }
                    float toplayer = (chargeTimer > 750) ? npc.AngleTo(player.Center) : npc.AngleFrom(player.Center);
                    toplayer = MathHelper.WrapAngle(toplayer);

                    float lerpspeed = (chargeTimer > 770) ? 0.0275f : 0.1f;
                    float length = Math.Min((chargeTimer - 700) / 5, 24) + 5;
                    length *= (chargeTimer > 750) ? MathHelper.Clamp(1, npc.Distance(player.Center) / 1200, 2) : 0.8f;
                    npc.localAI[0] = Utils.AngleLerp(npc.localAI[0], toplayer, lerpspeed);
                    npc.velocity = Vector2.UnitX.RotatedBy(npc.localAI[0]) * length;
                }
                num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
                float num196 = Math.Abs(num191);
                float num197 = Math.Abs(num192);
                float num198 = num188 / num193;
                num191 *= num198;
                num192 *= num198;
                bool flag21 = false;
                if (!flag21)
                {
                    if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
                    {
                        if (npc.velocity.X < num191)
                        {
                            npc.velocity.X = npc.velocity.X + num189;
                        }
                        else
                        {
                            if (npc.velocity.X > num191)
                            {
                                npc.velocity.X = npc.velocity.X - num189;
                            }
                        }

                        if (npc.velocity.Y < num192)
                        {
                            npc.velocity.Y = npc.velocity.Y + num189;
                        }
                        else
                        {
                            if (npc.velocity.Y > num192)
                            {
                                npc.velocity.Y = npc.velocity.Y - num189;
                            }
                        }

                        if (Math.Abs(num192) < num188 * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
                        {
                            if (npc.velocity.Y > 0f)
                            {
                                npc.velocity.Y = npc.velocity.Y + num189 * 2f;
                            }
                            else
                            {
                                npc.velocity.Y = npc.velocity.Y - num189 * 2f;
                            }
                        }
                        if (Math.Abs(num191) < num188 * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
                        {
                            if (npc.velocity.X > 0f)
                            {
                                npc.velocity.X = npc.velocity.X + num189 * 2f;
                            }
                            else
                            {
                                npc.velocity.X = npc.velocity.X - num189 * 2f;
                            }
                        }
                    }
                    else
                    {
                        if (num196 > num197)
                        {
                            if (npc.velocity.X < num191)
                            {
                                npc.velocity.X = npc.velocity.X + num189 * 1.1f;
                            }
                            else if (npc.velocity.X > num191)
                            {
                                npc.velocity.X = npc.velocity.X - num189 * 1.1f;
                            }

                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num188 * 0.5)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y = npc.velocity.Y + num189;
                                }
                                else
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189;
                                }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < num192)
                            {
                                npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
                            }
                            else if (npc.velocity.Y > num192)
                            {
                                npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
                            }

                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num188 * 0.5)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X = npc.velocity.X + num189;
                                }
                                else
                                {
                                    npc.velocity.X = npc.velocity.X - num189;
                                }
                            }
                        }
                    }
                }
            }
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            float lifeRatio = (float)npc.life / npc.lifeMax;
            if (lifeRatio < 0.45f)
            {
                damage = (int)(damage * 1.2f);
            }
        }

        public override bool PreNPCLoot()
        {
            ExtinctionWorld.downedFungalDigger = true;
            ExtinctionNet.SyncMultiplayer();
            return true;
        }

        public override void NPCLoot()
        {
            if (Main.expertMode)
            {
                npc.DropBossBags();
                return;
            }
            int choice = Main.rand.Next(4);
            if (choice == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<MushroomSniper>());
            }
            Item.NewItem(npc.getRect(), ItemID.GlowingMushroom, Main.rand.Next(15, 21));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 10; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, 2.5f * hitDirection, -2.5f, 0, new Color(22, 26, 54), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/FungalDiggerHeadGore"), 1f);
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