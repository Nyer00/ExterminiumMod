using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class ElementalGraniteCharge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Granite Charge");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 28;
            item.maxStack = 99;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8);
        }
    }
}