using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BronzeArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class BronzeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Helmet");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = Item.sellPrice(silver: 2);
            item.rare = ItemRarityID.Blue;
            item.defense = 5;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BronzeChestplate>() && legs.type == ModContent.ItemType<BronzeLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.statDefense += 2;
            player.setBonus = "Increases Defense by 2";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}