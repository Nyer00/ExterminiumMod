using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BrillianceArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class BrillianceMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Mask");
            Tooltip.SetDefault("10% increased melee damage and critical strike chance\n10% increased melee speed");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 32;
            item.value = Item.sellPrice(gold: 8);
            item.rare = ItemRarityID.Pink;
            item.defense = 26;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BrilliancePlateMail>() && legs.type == ModContent.ItemType<BrillianceGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.1f;
            player.meleeSpeed += 0.1f;
            player.meleeCrit += 10;
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