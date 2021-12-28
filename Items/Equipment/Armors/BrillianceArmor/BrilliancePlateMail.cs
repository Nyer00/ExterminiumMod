using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BrillianceArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class BrilliancePlateMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Plate Mail");
            Tooltip.SetDefault("8% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 22;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Pink;
            item.defense = 17;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<BrillianceMask>() && legs.type == ModContent.ItemType<BrillianceGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.06f;
            player.meleeCrit += 7;
            player.magicCrit += 7;
            player.rangedCrit += 7;
            player.thrownCrit += 7;
            player.GetAssassinPlayer().assassinCrit += 7;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Placeholder";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}