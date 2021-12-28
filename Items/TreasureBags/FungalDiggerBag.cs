using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.FungalDigger;
using ExtinctionTalesMod.Items.Weapons.BossDrops.AncientFungalDigger;
using ExtinctionTalesMod.NPCs.Bosses.FungalDigger;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.TreasureBags
{
    public class FungalDiggerBag : ModItem
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
            item.width = 42;
            item.height = 40;
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
                player.QuickSpawnItem(ModContent.ItemType<MushroomSniper>());
            }
            player.QuickSpawnItem(ItemID.GlowingMushroom, Main.rand.Next(15, 26));
            if (ExtinctionWorld.ExterminatorMode)
            {
                player.QuickSpawnItem(ModContent.ItemType<HarvesterHeart>());
            }
        }

        public override int BossBagNPC => ModContent.NPCType<FungalDiggerHead>();
    }
}