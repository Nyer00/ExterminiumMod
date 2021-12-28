using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs.Debuffs
{
    public class FungalInfection : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fungal Infection");
            Description.SetDefault("Your flesh is erupting");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetExtinctionPlayer().fInfection = true;
        }
    }
}