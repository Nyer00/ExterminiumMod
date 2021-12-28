using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Magic
{
    public class AtrogenStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Staff");
            Tooltip.SetDefault("Shoots an electric bolt");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.magic = true;
            item.mana = 6;
            item.width = 46;
            item.height = 46;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(silver: 37);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ElectricBolt>();
            item.shootSpeed = 21f;
        }

        public override void HoldItem(Player player)
        {
            player.itemLocation.Y += 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}