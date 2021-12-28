using ExtinctionTalesMod.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class Ropaz : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ropaz");
        }

        public override void SetDefaults()
        {
            item.damage = 23;
            item.crit = 4;
            item.melee = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.channel = true;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundID.Item1;
            item.knockBack = 4f;
            item.value = Item.sellPrice(silver: 22);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SwingofRuby>();
            item.shootSpeed = 44f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ruby, 12);
            recipe.AddIngredient(ItemID.Topaz, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}