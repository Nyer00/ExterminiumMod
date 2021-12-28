using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.AtrogenArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class AtrogenChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Chestplate");
            Tooltip.SetDefault("3% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 18;
            item.value = Item.sellPrice(silver: 52);
            item.rare = ItemRarityID.Orange;
            item.defense = 9;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<AtrogenHelmet>() && legs.type == ModContent.ItemType<AtrogenLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 2;
            player.magicCrit += 2;
            player.rangedCrit += 2;
            player.thrownCrit += 2;
            player.GetAssassinPlayer().assassinCrit += 2;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "6% increased damage\nAllows the player to dash\nDouble tap a direction";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}