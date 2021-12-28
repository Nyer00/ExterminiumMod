using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class BronzeBroadsword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.crit = 2;
            item.melee = true;
            item.autoReuse = true;
            item.width = 40;
            item.height = 46;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 15);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 28;
            item.useTime = 28;
            item.knockBack = 2.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}