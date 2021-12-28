using ExtinctionTalesMod.Buffs.Debuffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs.Enemies
{
    public class FungalScorpion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fungal Scorpion");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 20;
            npc.lifeMax = 35;
            npc.defense = 5;
            npc.damage = 20;
            if (ExtinctionWorld.ExterminatorMode)
            {
                npc.lifeMax = (int)(npc.lifeMax * 1.5);
            }
            npc.aiStyle = 3;
            aiType = NPCID.Scorpion;
            animationType = NPCID.Scorpion;
            npc.knockBackResist = 1f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 75f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneGlowshroom)
                return 0.45f;
            return 0f;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<FungalInfection>(), 120);
        }
    }
}