using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Projectiles.Assassin;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Assassin
{
    public class HellfireKunai : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellfire Kunai");
            Tooltip.SetDefault("Explodes upon hitting enemies\nRandom chances to increase the damage upon hitting enemies");
        }

        public override void SafeSetDefaults()
        {
            item.width = 46;
            item.height = 46;
            item.damage = 58;
            item.knockBack = 6f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 24;
            item.useAnimation = 24;
            item.crit = 6;
            item.UseSound = SoundID.Item20;
            item.rare = ItemRarityID.Pink;
            item.autoReuse = true;
            item.value = Item.sellPrice(gold: 4);
            item.noUseGraphic = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<HellfireKunaiProj>();
            item.shootSpeed = 22f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MagmaKunai>());
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}