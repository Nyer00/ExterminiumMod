using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Ranged
{
    public class BloodflareBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodflare Bow");
        }

        public override void SetDefaults()
        {
            item.damage = 28;
            item.crit = 4;
            item.ranged = true;
            item.width = 36;
            item.height = 56;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 3f;
            item.value = Item.sellPrice(silver: 65);
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}