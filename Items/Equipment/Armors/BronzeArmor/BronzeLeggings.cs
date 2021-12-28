using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BronzeArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BronzeLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Leggings");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 20;
            item.value = Item.sellPrice(copper: 86);
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BronzeChestplate>() && head.type == ModContent.ItemType<BronzeHelmet>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Defense by 2";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}