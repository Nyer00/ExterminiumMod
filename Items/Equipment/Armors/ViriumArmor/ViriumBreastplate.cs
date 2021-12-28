using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.Items.IngotBars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.ViriumArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class ViriumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Virium Breastplate");
            Tooltip.SetDefault("2% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 18;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 19);
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<ViriumHelmet>() && legs.type == ModContent.ItemType<ViriumLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 1;
            player.magicCrit += 1;
            player.rangedCrit += 1;
            player.thrownCrit += 1;
            player.GetModPlayer<AssassinPlayer>().assassinCrit += 1;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "5% increased melee speed";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ViriumBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}