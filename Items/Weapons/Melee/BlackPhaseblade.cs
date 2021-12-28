using ExtinctionTalesMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class BlackPhaseblade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Phaseblade");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.damage = 25;
            item.knockBack = 3f;
            item.useTime = 25;
            item.useAnimation = 25;
            item.melee = true;
            item.UseSound = SoundID.Item15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 57);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(player.itemLocation + new Vector2(6f + player.velocity.X, 14f), 0.3f, 0.275f, 0.3f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 15);
            recipe.AddIngredient(ModContent.ItemType<OnyxGem>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}