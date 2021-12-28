using ExtinctionTalesMod.Items.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Equipables.Hooks
{
    internal class OnyxHookItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Onyx Hook");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DiamondHook);
            item.width = 28;
            item.height = 36;
            item.shootSpeed = 18f;
            item.shoot = ModContent.ProjectileType<OnyxHookProjectile>();
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

    internal class OnyxHookProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("${ProjectileName.GemHookAmethyst}");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.GemHookDiamond);
        }

        public override bool? SingleGrappleHook(Player player)
        {
            return true;
        }

        public override float GrappleRange()
        {
            return 300f;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 18f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 11;
        }

        public override void GrappleTargetPoint(Player player, ref float grappleX, ref float grappleY)
        {
            Vector2 dirToPlayer = projectile.DirectionTo(player.Center);
            float hangDist = 25f;
            grappleX += dirToPlayer.X * hangDist;
            grappleY += dirToPlayer.Y * hangDist;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("ExtinctionTalesMod/Items/Equipment/Equipables/Hooks/OnyxHookChain");
            Vector2 vector = projectile.Center;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = null;
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float num = texture.Height;
            Vector2 vector2 = mountedCenter - vector;
            float rotation = (float)Math.Atan2(vector2.Y, vector2.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(vector.X) && float.IsNaN(vector.Y))
            {
                flag = false;
            }
            if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
            {
                flag = false;
            }
            while (flag)
            {
                if (vector2.Length() < num + 1)
                {
                    flag = false;
                }
                else
                {
                    Vector2 value = vector2;
                    value.Normalize();
                    vector += value * num;
                    vector2 = mountedCenter - vector;
                    Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16.0));
                    color = projectile.GetAlpha(color);
                    Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }
}