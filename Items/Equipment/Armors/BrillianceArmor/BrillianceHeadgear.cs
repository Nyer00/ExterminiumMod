using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.BrillianceArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class BrillianceHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Headgear");
            Tooltip.SetDefault("Increases maximum mana by 100\n12% increased magic damage and critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Pink;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BrilliancePlateMail>() && legs.type == ModContent.ItemType<BrillianceGreaves>();
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.12f;
            player.magicCrit += 11;
            player.statManaMax2 += 100;
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