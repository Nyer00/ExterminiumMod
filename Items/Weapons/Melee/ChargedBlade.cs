using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class ChargedBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Blade");
            Tooltip.SetDefault("Shoots a granite dust");
        }

        public override void SetDefaults()
        {
            item.width = 56;
            item.height = 56;
            item.damage = 90;
            item.melee = true;
            item.useTime = 22;
            item.useAnimation = 22;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            item.UseSound = SoundID.Item15;
            item.crit = 6;
            item.shoot = ModContent.ProjectileType<ChargedGraniteBolt>();
            item.shootSpeed = 24f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}