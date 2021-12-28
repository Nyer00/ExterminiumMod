using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.NPCs.Bosses.CyborgSlime;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.SummoningItems.Bosses
{
    public class SlimyRemote : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Remote");
            Tooltip.SetDefault("Summons Cyborg Slime");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 50;
            item.maxStack = 20;
            item.rare = ItemRarityID.Orange;
            item.useAnimation = 45;
            item.useTime = 45;
            item.value = Item.sellPrice(silver: 42);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<CyborgSlime>()) && NPC.downedBoss3 && player.ZoneOverworldHeight)
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<CyborgSlime>());
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
            recipe.AddIngredient(ItemID.Gel, 30);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}