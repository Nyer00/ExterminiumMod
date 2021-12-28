using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Consumables.Foods
{
    public class Nugget : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nugget");
            Tooltip.SetDefault("Minor improvement to all stats");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTime = 15;
            item.useAnimation = 15;
            item.maxStack = 30;
            item.useTurn = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 45);
            item.UseSound = SoundID.Item2;
            item.buffType = BuffID.WellFed;
            item.buffTime = 36000;
        }
    }
}