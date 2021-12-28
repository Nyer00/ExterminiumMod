using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Misc
{
    public class LargeOnyx : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Large Onyx");
            Tooltip.SetDefault("For capture the Gem. It drops when you die\nWork in progress");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 36;
            item.value = Item.sellPrice(silver: 32);
            item.rare = ItemRarityID.Blue;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D texture2D = Main.itemTexture[item.type];
            Vector2 vector = Utils.Size(texture2D) / 2f;
            Vector2 vector2 = item.position - Main.screenPosition + vector;
            spriteBatch.Draw(texture2D, vector2, null, new Color(250, 250, 250, (Main.mouseTextColor / 2)), rotation, vector, Main.mouseTextColor / 1000f + 0.8f, 0, 0f);
            return false;
        }

        public override void UpdateInventory(Player player)
        {
            player.GetExtinctionPlayer().largeGem = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<OnyxGem>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}