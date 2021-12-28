using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.ViriumArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ViriumHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Helmet");
            Tooltip.SetDefault("3% increased melee speed" + "\n3% increased damage");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 24;
            item.value = Item.sellPrice(silver: 8);
            item.rare = ItemRarityID.Blue;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.03f;
            player.meleeSpeed += 0.03f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ViriumBreastplate>() && legs.type == ModContent.ItemType<ViriumLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.meleeSpeed += 0.05f;
            player.setBonus = "5% increased melee speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}