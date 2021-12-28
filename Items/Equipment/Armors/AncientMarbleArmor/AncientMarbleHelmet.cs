using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.AncientMarbleArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientMarbleHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Marble Helmet");
            Tooltip.SetDefault("18% increased melee damage\n8% increased melee critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 26;
            item.defense = 15;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 6);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AncientMarbleBreastplate>() && legs.type == ModContent.ItemType<AncientMarbleLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.18f;
            player.meleeCrit += 7;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadowBasilisk = true;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "18% increased melee damage\n12% increased melee critical strike chance\n8% increased melee speed";
            player.meleeDamage += 0.18f;
            player.meleeCrit += 11;
            player.meleeSpeed += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientMarbleAlloy>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ElementalMarblePieces>(), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}