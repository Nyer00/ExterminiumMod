using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.AtrogenArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AtrogenLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Leggings");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = Item.sellPrice(silver: 23);
            item.rare = ItemRarityID.Orange;
            item.defense = 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<AtrogenHelmet>() && body.type == ModContent.ItemType<AtrogenChestplate>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "6% increased damage\nAllows the player to dash\nDouble tap a direction";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}