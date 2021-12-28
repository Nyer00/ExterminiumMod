using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.BossDrops.RuneWarrior
{
    public class RuneBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Blade");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.damage = 64;
            item.knockBack = 4.5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 24;
            item.useAnimation = 24;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 2);
            item.autoReuse = true;
            item.crit = 6;
        }
    }
}