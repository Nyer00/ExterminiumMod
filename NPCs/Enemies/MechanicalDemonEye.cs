using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Enemies
{
    public class MechanicalDemonEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mecha Eye");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 22;
            npc.damage = 22;
            npc.defense = 4;
            npc.lifeMax = 95;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 80f;
            npc.knockBackResist = 1f;
            npc.aiStyle = 2;
            aiType = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
            banner = Item.NPCtoBanner(NPCID.DemonEye);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneOverworldHeight && !Main.dayTime)
                return 0.1f;
            return 0f;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f);
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(2));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 10; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, DustID.Electric, 0f, 0f, 0, default, 1f);
                }
            }
        }
    }
}