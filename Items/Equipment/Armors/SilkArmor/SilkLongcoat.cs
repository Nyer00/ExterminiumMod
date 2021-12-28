using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.SilkArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class SilkLongcoat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silk Longcoat");
            Tooltip.SetDefault("5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.defense = 5;
            item.height = 30;
            item.width = 18;
            item.value = Item.sellPrice(silver: 35);
            item.rare = ItemRarityID.Blue;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<SilkHat>() && legs.type == ModContent.ItemType<SilkPants>();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "3% increased assassin critical strike chance\nYou recieve sneakness upon time\nYour damage increases hitting an enemy during this state";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cobweb, 20);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}