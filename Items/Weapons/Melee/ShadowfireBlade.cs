using ExtinctionTalesMod.Projectiles.Melee;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class ShadowfireBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowfire Blade");
            Tooltip.SetDefault("Left-Click to throw it\nRight-Click to swing it normally");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 42;
            item.crit = 6;
            item.damage = 50;
            item.useTime = 32;
            item.knockBack = 6f;
            item.useAnimation = 32;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 2);
            item.autoReuse = true;
            item.melee = true;
            item.noMelee = true;
            item.channel = true;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<ShadowfireBladeProj>();
            item.shootSpeed = 20f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.IsUsingAlt())
            {
                item.noMelee = false;
                item.noUseGraphic = false;
                item.channel = false;
                item.shoot = ProjectileID.None;
            }
            else
            {
                item.noMelee = true;
                item.noUseGraphic = true;
                item.channel = true;
                item.shoot = ModContent.ProjectileType<ShadowfireBladeProj>();
            }
            return base.CanUseItem(player);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 180);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 14);
            recipe.AddIngredient(ItemID.CursedFlame, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}