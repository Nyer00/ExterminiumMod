using ExtinctionTalesMod.ExPlayer;
using ExtinctionTalesMod.Items;
using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.NPCs;
using ExtinctionTalesMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace ExtinctionTalesMod.Utilities
{
    public static class ExtinctionUtils
    {
        public static ExtinctionPlayer GetExtinctionPlayer(this Player player) => player.GetModPlayer<ExtinctionPlayer>();

        public static ExtinctionGlobalNPC GetExtinctionGlobalNPC(this NPC npc) => npc.GetGlobalNPC<ExtinctionGlobalNPC>();

        public static ExtinctionGlobalItem GetExtinctionGlobalItem(this Item item) => item.GetGlobalItem<ExtinctionGlobalItem>();

        public static ExtinctionGlobalProj GetExtinctionGlobalProj(this Projectile proj) => proj.GetGlobalProjectile<ExtinctionGlobalProj>();

        public static AssassinPlayer GetAssassinPlayer(this Player player) => player.GetModPlayer<AssassinPlayer>();

        public static bool IsUsingAlt(this Player player) => player.altFunctionUse == 2;

        public static void DisplayLocalText(string key, Color? textColor = null)
        {
            if (textColor == null)
            {
                textColor = Color.White;
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(Language.GetTextValue(key), textColor.Value);
                return;
            }
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromKey(key), textColor.Value);
            }
        }
    }
}