using ExtinctionTalesMod.Items.Classes.Assassin;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Projectiles.Assassin;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Assassin
{
    public class MagmaKunai : AssassinWeapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Kunai");
            Tooltip.SetDefault("Explodes upon hitting enemies");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 42;
            item.height = 32;
            item.width = 32;
            item.crit = 4;
            item.knockBack = 2.5f;
            item.useTime = 22;
            item.useAnimation = 22;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Orange;
            item.value = Item.sellPrice(gold: 1);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noUseGraphic = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<MagmaKunaiProj>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 14);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}