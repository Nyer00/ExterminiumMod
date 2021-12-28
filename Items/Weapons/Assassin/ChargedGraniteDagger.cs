using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Assassin;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Assassin
{
    public class ChargedGraniteDagger : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Dagger");
            Tooltip.SetDefault("Sticks to enemies");
        }

        public override void SafeSetDefaults()
        {
            item.width = 38;
            item.height = 38;
            item.damage = 84;
            item.knockBack = 4f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.crit = 6;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 24;
            item.useAnimation = 24;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 3);
            item.noUseGraphic = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<ChargedGraniteDaggerProj>();
            item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<StoneDagger>(), 30);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}