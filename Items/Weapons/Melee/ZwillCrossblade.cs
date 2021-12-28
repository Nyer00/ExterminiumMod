using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class ZwillCrossblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zwill Crossblade");
            Tooltip.SetDefault("Twin-bladed dagger sought by a legendary adventurer");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.crit = 4;
            item.damage = 42;
            item.useTime = 22;
            item.useAnimation = 22;
            item.knockBack = 4f;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(gold: 2);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            item.melee = true;
        }
    }
}