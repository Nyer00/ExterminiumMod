using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.IngotBars
{
    public class AncientMarbleAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Marble Alloy");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.maxStack = 999;
            item.rare = ItemRarityID.Lime;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 12);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientMarbleShards>(), 4);
            recipe.AddIngredient(ModContent.ItemType<ElementalMarblePieces>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}