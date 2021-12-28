using ExtinctionTalesMod.Items.Classes.Assassin;
using Terraria;
using Terraria.ID;

namespace ExtinctionTalesMod.Items.Weapons.BossDrops.CyborgSlime
{
    public class MechanicalDagger : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Dagger");
        }

        public override void SafeSetDefaults()
        {
            item.width = 34;
            item.height = 38;
            item.useTime = 24;
            item.damage = 32;
            item.useAnimation = 24;
            item.rare = ItemRarityID.Orange;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(silver: 89);
            item.UseSound = SoundID.Item1;
            item.knockBack = 3.5f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.crit = 4;
        }
    }
}