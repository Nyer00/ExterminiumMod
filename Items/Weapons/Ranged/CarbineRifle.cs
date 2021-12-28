using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class CarbineRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carbine Rifle");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.ranged = true;
            item.width = 60;
            item.height = 26;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 1.5f;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.White;
            item.UseSound = SoundID.Item11;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 35f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}