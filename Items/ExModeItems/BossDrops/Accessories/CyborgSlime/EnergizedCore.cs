using ExtinctionTalesMod.Buffs;
using ExtinctionTalesMod.NPCs.Enemies;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.CyborgSlime
{
    public class EnergizedCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energized Core");
            Tooltip.SetDefault(@"Energy flows from you
Slimes become friendly
Getting hit inflicts Slimed to enemies
Exterminator Mode");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 36;
            item.expert = true;
            item.value = Item.sellPrice(copper: 67);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.FindBuffIndex(ModContent.BuffType<EnergizedBuff>()) == -1)
            {
                player.AddBuff(ModContent.BuffType<EnergizedBuff>(), 3600);
            }
            player.npcTypeNoAggro[NPCID.BlueSlime] = true;
            player.npcTypeNoAggro[NPCID.IceSlime] = true;
            player.npcTypeNoAggro[NPCID.SandSlime] = true;
            player.npcTypeNoAggro[NPCID.IlluminantSlime] = true;
            player.npcTypeNoAggro[NPCID.UmbrellaSlime] = true;
            player.npcTypeNoAggro[NPCID.MotherSlime] = true;
            player.npcTypeNoAggro[NPCID.DungeonSlime] = true;
            player.npcTypeNoAggro[NPCID.RainbowSlime] = true;
            player.npcTypeNoAggro[NPCID.LavaSlime] = true;
            player.npcTypeNoAggro[ModContent.NPCType<MetalheadSlime>()] = true;
            player.GetExtinctionPlayer().energizedGelCore = true;
        }
    }
}