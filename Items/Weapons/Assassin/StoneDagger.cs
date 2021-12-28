using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.Projectiles.Assassin;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Assassin
{
    public class StoneDagger : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Dagger");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 16;
            item.crit = 6;
            item.width = 18;
            item.height = 24;
            item.knockBack = 1.5f;
            item.value = Item.sellPrice(silver: 28);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 25;
            item.useTime = 25;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = ModContent.ProjectileType<StoneDaggerProj>();
            item.shootSpeed = 20f;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
    }
}