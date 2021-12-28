using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Weapons.Melee
{
    public class BlackPhasesaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Phasesaber");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.damage = 42;
            item.knockBack = 3f;
            item.useTime = 20;
            item.useAnimation = 20;
            item.melee = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(player.itemLocation + new Vector2(6f + player.velocity.X, 14f), 0.3f, 0.275f, 0.3f);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BlackPhaseblade>());
            recipe.AddIngredient(ItemID.CrystalShard, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}