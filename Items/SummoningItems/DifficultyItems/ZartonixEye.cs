using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.SummoningItems.DifficultyItems
{
    public class ZartonixEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zartonix Eye");
            Tooltip.SetDefault(@"Actives Exterminator Mode
Automatically changes the world to Expert Mode
Increases difficulty, changing most of the enemies' AIS
Exclusive drops from bosses
Rebalances vanilla items
Debuffs deals more damage
Increases items drop chance from enemies
Increases spawn rates
Can't be used while fighting a boss
Exterminator Mode");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 34;
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.maxStack = 1;
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
            if (!ExtinctionWorld.ExterminatorMode)
            {
                ExtinctionWorld.ExterminatorMode = true;
                Main.expertMode = true;
                string text1 = "The unholy souls triggers upon your world...";
                Color textColor1 = Color.Crimson;
                ExtinctionUtils.DisplayLocalText(text1, new Color?(textColor1));
            }
            else
            {
                ExtinctionWorld.ExterminatorMode = false;
                string text2 = "The virtuous Ancients bless your path.";
                Color textColor2 = Color.Crimson;
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