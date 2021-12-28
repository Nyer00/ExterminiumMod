using ExtinctionTalesMod.Projectiles.Melee;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class BloodshedBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodshed Blade");
            Tooltip.SetDefault("Left-Click to throw it\nRight-Click to swing it normally");
        }

        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 46;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.channel = true;
            item.damage = 50;
            item.crit = 6;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTime = 32;
            item.useAnimation = 32;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 2);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<BloodshedBladeProj>();
            item.shootSpeed = 22f;
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
                item.shoot = ModContent.ProjectileType<BloodshedBladeProj>();
            }
            return base.CanUseItem(player);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 180);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 14);
            recipe.AddIngredient(ItemID.Ichor, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}