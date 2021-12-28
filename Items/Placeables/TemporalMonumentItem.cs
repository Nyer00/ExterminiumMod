using ExtinctionTalesMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Placeables
{
    public class TemporalMonumentItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Temporal Monument");
            Tooltip.SetDefault("Changes between Day and Night");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 40;
            item.maxStack = 99;
            item.autoReuse = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Pink;
            item.value = Item.sellPrice(gold: 2);
            item.createTile = ModContent.TileType<TemporalMonument>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddRecipeGroup("ExtinctionTalesMod:AnyTier1HMBar", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}