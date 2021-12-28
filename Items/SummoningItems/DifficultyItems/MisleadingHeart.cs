using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.SummoningItems.DifficultyItems
{
    public class MisleadingHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Misleading Heart");
            Tooltip.SetDefault("Turn ON and OFF Expert mode");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 52;
            item.value = 2500;
            item.useAnimation = 45;
            item.useTime = 45;
            item.rare = ItemRarityID.Blue;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return true;
            }
            if (!Main.expertMode)
            {
                Main.expertMode = true;
                string text1 = "Expert Mode is now ON";
                Color textColor1 = Color.Purple;
                ExtinctionUtils.DisplayLocalText(text1, new Color?(textColor1));
            }
            else
            {
                Main.expertMode = false;
                string text2 = "Expert Mode is now OFF";
                Color textColor2 = Color.Purple;
                ExtinctionUtils.DisplayLocalText(text2, new Color?(textColor2));
            }
            ExtinctionNet.SyncMultiplayer();
            Main.PlaySound(SoundID.Roar, player.Center, 0);

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}