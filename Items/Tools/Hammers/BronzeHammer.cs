using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Hammers
{
    public class BronzeHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Hammer");
        }

        public override void SetDefaults()
        {
            item.damage = 6;
            item.melee = true;
            item.knockBack = 4f;
            item.hammer = 50;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 15);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTime = 28;
            item.width = 34;
            item.height = 38;
            item.useAnimation = 28;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}