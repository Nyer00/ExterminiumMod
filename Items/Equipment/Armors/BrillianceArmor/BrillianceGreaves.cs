using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BrillianceArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BrillianceGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Greaves");
            Tooltip.SetDefault("9% increased damage\n10% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 16;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Pink;
            item.defense = 13;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BrilliancePlateMail>() && head.type == ModContent.ItemType<BrillianceMask>();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
            player.allDamage += 0.09f;
            player.GetAssassinPlayer().assassinDamageAdd += 0.09f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Placeholder";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}