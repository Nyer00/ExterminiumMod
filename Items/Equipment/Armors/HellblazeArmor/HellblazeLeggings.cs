using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.HellblazeArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class HellblazeLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellblaze Leggings");
            Tooltip.SetDefault("5% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.value = Item.sellPrice(silver: 25);
            item.rare = ItemRarityID.Orange;
            item.defense = 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<HellblazeHelmet>() && body.type == ModContent.ItemType<HellblazeChestplate>();
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Weapons now put enemies on fire\n5% increased movement speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}