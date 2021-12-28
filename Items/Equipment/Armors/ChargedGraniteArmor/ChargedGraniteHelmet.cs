using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.ChargedGraniteArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ChargedGraniteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Helmet");
            Tooltip.SetDefault("Increases maximum mana by 100\n18% increased magic damage");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 24;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8);
            item.defense = 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ChargedGraniteChestplate>() && legs.type == ModContent.ItemType<ChargedGraniteLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 100;
            player.magicDamage += 0.18f;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "16% increased magic damage\nReduces mana cost by 20%";
            player.magicDamage += 0.16f;
            player.manaCost -= 0.20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ElementalGraniteCharge>(), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}