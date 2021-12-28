using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BronzeArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class BronzeChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Chestplate");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.value = Item.sellPrice(silver: 8);
            item.rare = ItemRarityID.Blue;
            item.defense = 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<BronzeHelmet>() && legs.type == ModContent.ItemType<BronzeLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases Defense by 2";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}