using ExtinctionTalesMod.Items.Classes.Assassin;
using Terraria;
using Terraria.ID;

namespace ExtinctionTalesMod.Items.Weapons.BossDrops.RuneWarrior
{
    public class PossessedPike : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Pike");
        }

        public override void SafeSetDefaults()
        {
            item.width = 36;
            item.height = 36;
            item.damage = 58;
            item.crit = 6;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.Pink;
            item.knockBack = 5f;
            item.useTime = 24;
            item.useAnimation = 24;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.Stabbing;
        }
    }
}