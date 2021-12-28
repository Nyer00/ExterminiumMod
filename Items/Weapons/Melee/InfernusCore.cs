using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class InfernusCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infernus Core");
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 44;
            item.crit = 8;
            item.damage = 72;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(gold: 35);
            item.useTime = 26;
            item.useAnimation = 26;
            item.UseSound = SoundID.Item1;
            item.knockBack = 7.5f;
            item.autoReuse = true;
            item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MagmaBlade>());
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}