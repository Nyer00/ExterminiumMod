using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.HellblazeArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class HellblazeChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellblaze Chestplate");
            Tooltip.SetDefault("5% increased assassin damage\n7% increased assassin critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.value = Item.sellPrice(silver: 45);
            item.rare = ItemRarityID.Orange;
            item.defense = 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<HellblazeHelmet>() && legs.type == ModContent.ItemType<HellblazeLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetAssassinPlayer().assassinDamageAdd += 0.05f;
            player.GetAssassinPlayer().assassinCrit += 6;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Weapons now put enemies on fire\n5% increased movement speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 20);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}