using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.HellblazeArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class HellblazeHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellblaze Helmet");
            Tooltip.SetDefault("6% increased assassin damage\n5% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = Item.sellPrice(silver: 35);
            item.rare = ItemRarityID.Orange;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HellblazeChestplate>() && legs.type == ModContent.ItemType<HellblazeLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetAssassinPlayer().assassinDamageAdd += 0.06f;
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.GetAssassinPlayer().assassinCrit += 5;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.GetExtinctionPlayer().hellblazeSet = true;
            player.moveSpeed += 0.05f;
            player.setBonus = "Weapons now put enemies on fire\n5% increased movement speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}