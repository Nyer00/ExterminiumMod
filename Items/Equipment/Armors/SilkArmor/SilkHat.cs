using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.SilkArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class SilkHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silk Hat");
            Tooltip.SetDefault("5% increased assassin damage");
        }

        public override void SetDefaults()
        {
            item.defense = 4;
            item.height = 22;
            item.width = 34;
            item.value = Item.sellPrice(silver: 22);
            item.rare = ItemRarityID.Blue;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<SilkLongcoat>() && legs.type == ModContent.ItemType<SilkPants>();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetAssassinPlayer().assassinDamageAdd += 0.05f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "3% increased assassin critical strike chance\nYou recieve sneakness upon time\nYour damage increases hitting an enemy during this state";
            player.GetAssassinPlayer().assassinCrit += 2;
            player.GetExtinctionPlayer().silkAssassinSet = true;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cobweb, 10);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}