using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Axes
{
    public class BrillianceAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Axe");
        }

        public override void SetDefaults()
        {
            item.height = 40;
            item.width = 40;
            item.axe = 22;
            item.damage = 24;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 22;
            item.useAnimation = 22;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.knockBack = 6.5f;
            item.autoReuse = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire);
            }
            Lighting.AddLight(player.itemLocation + new Vector2(6f + player.velocity.X, 14f), 0.3f, 0.275f, 0.3f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BrillianceBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}