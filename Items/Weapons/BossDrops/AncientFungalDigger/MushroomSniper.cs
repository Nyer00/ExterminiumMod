using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.BossDrops.AncientFungalDigger
{
    public class MushroomSniper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushroom Sniper");
        }

        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 18;
            item.ranged = true;
            item.noMelee = true;
            item.damage = 26;
            item.useTime = 26;
            item.useAnimation = 26;
            item.autoReuse = true;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item41;
            item.reuseDelay = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.Green;
            item.value = Item.sellPrice(silver: 65);
            item.shoot = ProjectileID.Bullet;
            item.useAmmo = AmmoID.Bullet;
            item.shootSpeed = 14f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8, 0);
        }
    }
}