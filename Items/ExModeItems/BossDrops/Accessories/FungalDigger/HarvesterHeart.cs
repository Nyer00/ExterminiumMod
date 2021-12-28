using ExtinctionTalesMod.Buffs.Debuffs;
using ExtinctionTalesMod.ExPlayer;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.FungalDigger
{
    public class HarvesterHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harvester Heart");
            Tooltip.SetDefault("Getting hit shoots Glowing Mushrooms\nImmunity to Fungal Infection\nExterminator Mode");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 48;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            item.value = Item.sellPrice(copper: 56);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<FungalInfection>()] = true;
            player.GetModPlayer<ExtinctionPlayer>().fungusHeart = true;
        }
    }
}