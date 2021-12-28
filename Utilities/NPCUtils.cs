using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Utilities
{
    public static class NPCUtils
    {
        public static int RealDamage(float damagevalue, float expertscaling = 1)
        {
            damagevalue = Main.expertMode ? damagevalue / 4 * expertscaling : (damagevalue / 2);
            return (int)damagevalue;
        }

        public static void PlayDeathSound(this NPC npc, string Sound)
        {
            if (Main.netMode != NetmodeID.Server && npc.modNPC != null)
            {
                Main.musicFade[npc.modNPC.music] = 0.3f;
                Main.soundVolume = (Main.soundVolume == 0) ? 1 : Main.soundVolume;
                Main.PlaySound(SoundLoader.customSoundType, npc.position, ExtinctionMod.Instance.GetSoundSlot(SoundType.Custom, "Sounds/DeathSounds/" + Sound));
            }
        }
    }
}