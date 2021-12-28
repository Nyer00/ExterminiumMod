using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs.Debuffs
{
    public class BrokenBones : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Broken Bones");
            Description.SetDefault("Your body hurts");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetExtinctionGlobalNPC().brokenBonesEnemies = true;
            npc.stepSpeed -= 0.1f;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetExtinctionPlayer().brokenBonesPlayer = true;
            player.moveSpeed -= 0.1f;
        }
    }
}