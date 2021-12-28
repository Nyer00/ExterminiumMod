using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs.Debuffs
{
    public class Overheating : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Overheating");
            Description.SetDefault("Your body is warm");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetExtinctionGlobalNPC().overheatingEnemies = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetExtinctionPlayer().overheatingPlayer = true;
        }
    }
}