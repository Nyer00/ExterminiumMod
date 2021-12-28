using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.AtrogenArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AtrogenHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Helmet");
            Tooltip.SetDefault("6% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;
            item.value = Item.sellPrice(silver: 43);
            item.rare = ItemRarityID.Orange;
            item.defense = 9;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AtrogenChestplate>() && legs.type == ModContent.ItemType<AtrogenLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.06f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "6% increased damage\nAllows the player to dash\nDouble tap a direction";
            player.allDamage += 0.06f;
            player.dash = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}