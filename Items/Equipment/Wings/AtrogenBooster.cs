using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Wings
{
    [AutoloadEquip(EquipType.Wings)]
    public class AtrogenBooster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Booster");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.value = Item.sellPrice(gold: 2);
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 70;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 1f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 6.5f;
            acceleration *= 1.25f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 20);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);
            recipe.AddTile(TileID.SkyMill);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}