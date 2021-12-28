using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BrillianceArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class BrillianceHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Helmet");
            Tooltip.SetDefault("15% increased ranged damage\n8% increased ranged critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 26;
            item.defense = 11;
            item.value = Item.sellPrice(gold: 6);
            item.rare = ItemRarityID.Pink;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BrilliancePlateMail>() && legs.type == ModContent.ItemType<BrillianceGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.15f;
            player.rangedCrit += 8;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Placeholder";
            player.GetExtinctionPlayer().brillianceSet = true;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}