using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Magic
{
    public class BrillianceStave : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brilliance Stave");
            Tooltip.SetDefault("Shoots Fireballs from the sky");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 46;
            item.damage = 58;
            item.noMelee = true;
            item.magic = true;
            item.knockBack = 4.5f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 24;
            item.useAnimation = 24;
            item.autoReuse = true;
            item.mana = 16;
            item.value = Item.sellPrice(gold: 3);
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item20;
            //item.shoot = ModContent.ProjectileType<FireballMage>();
            item.shootSpeed = 6f;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                ModContent.GetTexture("ExtinctionTalesMod/Items/Weapons/Magic/BrillianceStave_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
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