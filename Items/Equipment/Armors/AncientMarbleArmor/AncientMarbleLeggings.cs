using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.AncientMarbleArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientMarbleLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Marble Leggings");
            Tooltip.SetDefault("10% increased critical strike chance\n7% increased movement speed");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 16;
            item.defense = 15;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<AncientMarbleHelmet>() && body.type == ModContent.ItemType<AncientMarbleBreastplate>();
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 9;
            player.moveSpeed += 0.07f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "18% increased melee damage\n12% increased melee critical strike chance\n8% increased melee speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientMarbleAlloy>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ElementalMarblePieces>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}