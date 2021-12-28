using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class BronzeShortsword : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 13;
            item.crit = 1;
            item.melee = true;
            item.autoReuse = true;
            item.width = 30;
            item.height = 34;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 8);
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useAnimation = 25;
            item.useTime = 25;
            item.knockBack = 2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}