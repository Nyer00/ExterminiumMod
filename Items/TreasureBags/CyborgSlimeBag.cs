using ExtinctionTalesMod.Items.Equipment.Equipables.Pets;
using ExtinctionTalesMod.Items.Equipment.Vanities.BossesVanities;
using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.CyborgSlime;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.Weapons.BossDrops.CyborgSlime;
using ExtinctionTalesMod.NPCs.Bosses.CyborgSlime;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.TreasureBags
{
    public class CyborgSlimeBag : ModItem
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
            item.width = 30;
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
            int choice = Main.rand.Next(7);
            if (choice == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<CyborgSlimeMask>());
            }
            if (choice == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<SlimeCoreItem>());
            }
            if (choice == 3)
            {
                player.QuickSpawnItem(ModContent.ItemType<MechanicalDagger>());
            }
            player.QuickSpawnItem(ItemID.Gel, Main.rand.Next(15, 26));
            player.QuickSpawnItem(ModContent.ItemType<HardwareBit>(), Main.rand.Next(25, 36));
            if (ExtinctionWorld.ExterminatorMode)
            {
                player.QuickSpawnItem(ModContent.ItemType<EnergizedCore>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<CyborgSlime>();
    }
}