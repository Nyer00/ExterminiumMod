using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class ViriumShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Shield");
            Tooltip.SetDefault("Increases Defense by 2\nIncreases Life Regen by 1");
        }

        public override void SetDefaults()
        {
            item.width = 58;
            item.height = 34;
            item.value = Item.sellPrice(silver: 24);
            item.rare = ItemRarityID.Blue;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 2;
            player.lifeRegen = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 8);
            recipe.AddIngredient(ItemID.IronskinPotion);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}