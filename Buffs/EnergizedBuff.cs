using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs
{
    public class EnergizedBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Energized");
            Description.SetDefault("Movement Speed and Damage increased by 5%");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.05f;
            player.allDamage += 0.05f;
        }
    }
}