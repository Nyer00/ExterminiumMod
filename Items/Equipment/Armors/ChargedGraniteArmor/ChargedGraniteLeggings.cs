using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.ChargedGraniteArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ChargedGraniteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Leggings");
            Tooltip.SetDefault("10% increased critical strike chance\n7% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.07f;
            player.magicCrit += 9;
            player.meleeCrit += 9;
            player.rangedCrit += 9;
            player.thrownCrit += 9;
            player.GetAssassinPlayer().assassinCrit += 9;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ChargedGraniteChestplate>() && head.type == ModContent.ItemType<ChargedGraniteHelmet>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "16% increased magic damage\nReduces mana cost by 20%";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ElementalGraniteCharge>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}