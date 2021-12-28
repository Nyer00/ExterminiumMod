using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Materials
{
    public class ElementalMarblePieces : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Marble Pieces");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 46;
            item.maxStack = 99;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8);
        }
    }
}