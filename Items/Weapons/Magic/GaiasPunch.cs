using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Magic
{
    public class GaiasPunch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gaia's Punch");
            Tooltip.SetDefault("Shoots a granite punch");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 34;
            item.magic = true;
            item.damage = 84;
            item.noMelee = true;
            item.mana = 12;
            item.autoReuse = true;
            item.reuseDelay = 6;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item20;
            item.value = Item.sellPrice(gold: 4);
            item.rare = ItemRarityID.Lime;
            item.shoot = ModContent.ProjectileType<GaiasPunchProj>();
            item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}