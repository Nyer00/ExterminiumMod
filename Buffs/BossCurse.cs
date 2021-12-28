using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs
{
    public class BossCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Boss Curse");
            Description.SetDefault("Enemies spawnrates are reduced");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetExtinctionPlayer().bossCurse = true;
        }
    }
}