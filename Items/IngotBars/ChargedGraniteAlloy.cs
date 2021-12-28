using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.Ores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.IngotBars
{
    public class ChargedGraniteAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Alloy");
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 22;
            item.maxStack = 999;
            item.rare = ItemRarityID.Lime;
            item.consumable = true;
            item.value = Item.sellPrice(gold: 12);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteShards>(), 4);
            recipe.AddIngredient(ModContent.ItemType<ElementalGraniteCharge>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}