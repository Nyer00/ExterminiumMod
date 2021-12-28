using Terraria;
using Terraria.ID;

namespace ExtinctionTalesMod
{
    public static class ExtinctionNet
    {
        public static void SyncMultiplayer()
        {
            if (Main.netMode != NetmodeID.SinglePlayer)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }
    }
}