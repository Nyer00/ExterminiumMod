using ExtinctionTalesMod.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.ExPlayer
{
    public static class ExtinctionPlayerMiscEffects
    {
        public static void ExtinctionPlayerPostUpdateMiscEffects(Player player, Mod mod)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].boss)
                    {
                        player.AddBuff(ModContent.BuffType<BossCurse>(), 2, false);
                    }
                }
            }
        }
    }
}