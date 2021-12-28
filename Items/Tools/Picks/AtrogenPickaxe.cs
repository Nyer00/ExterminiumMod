using ExtinctionTalesMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Picks
{
    public class AtrogenPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrogen Pickaxe");
        }

        public override void SetDefaults()
        {
            item.height = 38;
            item.width = 38;
            item.autoReuse = true;
            item.useTime = 26;
            item.useAnimation = 26;
            item.knockBack = 4.5f;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 63);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.pick = 100;
            item.melee = true;
            item.damage = 16;
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
            recipe.AddIngredient(ModContent.ItemType<MetallicGel>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}