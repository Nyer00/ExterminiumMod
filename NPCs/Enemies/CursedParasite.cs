using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Enemies
{
    public class CursedParasite : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Parasite");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 16;
            npc.height = 26;
            npc.lifeMax = 30;
            npc.defense = 5;
            npc.damage = 20;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.2);
            }
            npc.aiStyle = 2;
            aiType = NPCID.BeeSmall;
            animationType = NPCID.BeeSmall;
            npc.knockBackResist = 1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 50f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneCorrupt)
                return 0.45f;
            return 0f;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Corruption, 0f, 0f, 0, default);
            Main.dust[dust].scale *= 1.25f;
            Main.dust[dust].velocity *= 1f;
        }
    }
}