using ExtinctionTalesMod.NPCs.Bosses.RuneWarrior;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.SummoningItems.Bosses
{
    public class WarriorsHorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warrior's Horn");
            Tooltip.SetDefault("Summons the Dungeon Warrior\nUse in the Dungeon");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.rare = ItemRarityID.Pink;
            item.maxStack = 20;
            item.useAnimation = 45;
            item.useTime = 45;
            item.value = Item.sellPrice(gold: 2);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<RuneWarrior>()) && player.ZoneDungeon)
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<RuneWarrior>());
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
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}