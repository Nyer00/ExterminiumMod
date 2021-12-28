using ExtinctionTalesMod.NPCs.Bosses.FungalDigger;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.SummoningItems.Bosses
{
    public class MushroomBait : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Bait");
            Tooltip.SetDefault("Summons the ancient worm of the Fungus\nUse in the Glowing Mushroom Biome");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 32;
            item.maxStack = 20;
            item.rare = ItemRarityID.Green;
            item.useAnimation = 45;
            item.useTime = 45;
            item.value = Item.sellPrice(silver: 22);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<FungalDiggerHead>()) && player.ZoneGlowshroom)
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<FungalDiggerHead>());
            else if (Main.netMode == NetmodeID.MultiplayerClient && player == Main.LocalPlayer)
            {
                Vector2 spawnPos = player.Center;
                int tries = 0;
                int maxtries = 300;
                while ((Vector2.Distance(spawnPos, player.Center) <= 200 ||
                        WorldGen.SolidTile((int)spawnPos.X / 16, (int)spawnPos.Y / 16) ||
                        WorldGen.SolidTile2((int)spawnPos.X / 16, (int)spawnPos.Y / 16) ||
                        WorldGen.SolidTile3((int)spawnPos.X / 16, (int)spawnPos.Y / 16)) && tries <= maxtries)
                {
                    spawnPos = player.Center + Main.rand.NextVector2Circular(800, 800);
                    tries++;
                }
                if (tries >= maxtries)
                    return false;
            }

            Main.PlaySound(SoundID.Roar, player.Center, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GlowingMushroom, 25);
            recipe.AddIngredient(ItemID.RottenChunk, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}