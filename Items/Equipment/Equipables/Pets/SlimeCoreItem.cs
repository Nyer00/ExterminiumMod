using ExtinctionTalesMod.Buffs.Pets;
using ExtinctionTalesMod.Projectiles.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Equipables.Pets
{
    public class SlimeCoreItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Slime Core");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BoneKey);
            item.width = 30;
            item.height = 30;
            item.shoot = ModContent.ProjectileType<SlimeCore>();
            item.buffType = ModContent.BuffType<SlimeCoreBuff>();
            item.rare = ItemRarityID.Orange;
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}