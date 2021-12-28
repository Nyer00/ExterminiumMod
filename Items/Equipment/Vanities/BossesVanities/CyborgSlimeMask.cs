using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Vanities.BossesVanities
{
    [AutoloadEquip(EquipType.Head)]
    public class CyborgSlimeMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyborg Slime Mask");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 2;
            item.maxStack = 99;
            item.value = Item.sellPrice(silver: 4);
            item.rare = ItemRarityID.Orange;
            item.vanity = true;
        }

        public override bool DrawHead()
        {
            return true;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
        }
    }
}