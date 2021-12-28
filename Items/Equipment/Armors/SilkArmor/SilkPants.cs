using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.SilkArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SilkPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silk Pants");
        }

        public override void SetDefaults()
        {
            item.height = 18;
            item.width = 22;
            item.defense = 4;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 18);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<SilkHat>() && body.type == ModContent.ItemType<SilkLongcoat>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "3% increased assassin critical strike chance\nYou recieve sneakness upon time\nYour damage increases hitting an enemy during this state";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cobweb, 15);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}