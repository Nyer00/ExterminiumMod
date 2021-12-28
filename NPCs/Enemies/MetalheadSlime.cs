using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.Placeables.Banners;
using ExtinctionTalesMod.NPCs.Bosses.CyborgSlime;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Enemies
{
    public class MetalheadSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Metalhead Slime");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 22;
            npc.aiStyle = 1;
            npc.damage = 20;
            npc.defense = 6;
            npc.lifeMax = 100;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            aiType = NPCID.BlueSlime;
            animationType = NPCID.BlueSlime;
            npc.knockBackResist = 1f;
            npc.value = 100f;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            banner = npc.type;
            bannerItem = ModContent.ItemType<MetalheadSlimeBanner>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f);
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneOverworldHeight && ExtinctionWorld.downedCyborgSlime && Main.dayTime)
                return 0.6f;
            if (spawnInfo.player.ZoneOverworldHeight && ExtinctionWorld.downedCyborgSlime && !Main.dayTime)
                return 0.1f;
            return 0f;
        }

        public override bool PreNPCLoot()
        {
            if (NPC.AnyNPCs(ModContent.NPCType<CyborgSlime>()))
            {
                return false;
            }
            return true;
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextBool())
            {
                Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(2, 5));
            }
            else
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<HardwareBit>(), Main.rand.Next(2, 4));
            }
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