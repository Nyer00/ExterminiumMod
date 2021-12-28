using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Tools.Picks
{
    public class BrilliancePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Pickaxe");
        }

        public override void SetDefaults()
        {
            item.height = 40;
            item.width = 34;
            item.autoReuse = true;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 6.5f;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(gold: 4);
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.pick = 200;
            item.melee = true;
            item.damage = 24;
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
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}