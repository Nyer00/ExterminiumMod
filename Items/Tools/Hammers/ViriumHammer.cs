using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Hammers
{
    public class ViriumHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Hammer");
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.melee = true;
            item.knockBack = 6.5f;
            item.hammer = 55;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 34);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTime = 26;
            item.width = 42;
            item.height = 40;
            item.useAnimation = 26;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}