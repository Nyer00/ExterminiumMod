using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.RuneWarrior;
using ExtinctionTalesMod.Items.Ores;
using ExtinctionTalesMod.Items.Weapons.BossDrops.RuneWarrior;
using ExtinctionTalesMod.NPCs.Bosses.RuneWarrior;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.TreasureBags
{
    public class RuneWarriorBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 32;
            item.height = 32;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            int choice = Main.rand.Next(4);
            if (choice == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<RuneBlade>());
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<PossessedPike>());
            }
            player.QuickSpawnItem(ModContent.ItemType<BrillianceOre>(), Main.rand.Next(15, 31));
            if (ExtinctionWorld.ExterminatorMode)
            {
                player.QuickSpawnItem(ModContent.ItemType<PossessedHelmet>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<RuneWarrior>();
    }
}