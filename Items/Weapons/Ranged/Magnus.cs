using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class Magnus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magnus");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 26;
            item.damage = 62;
            item.ranged = true;
            item.crit = 8;
            item.useTime = 14;
            item.knockBack = 4.5f;
            item.useAnimation = 14;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 45);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item41;
            item.noMelee = true;
            item.shoot = ProjectileID.Bullet;
            item.useAmmo = AmmoID.Bullet;
            item.shootSpeed = 16f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 5f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}