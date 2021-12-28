using ExtinctionTalesMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Axes
{
    public class AtrogenHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Hamaxe");
        }

        public override void SetDefaults()
        {
            item.height = 56;
            item.width = 50;
            item.hammer = 70;
            item.axe = 30;
            item.damage = 18;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 26;
            item.useAnimation = 26;
            item.value = Item.sellPrice(silver: 46);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.knockBack = 4.5f;
            item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Electric);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}