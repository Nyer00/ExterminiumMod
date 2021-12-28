using ExtinctionTalesMod.Projectiles.Pets;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs.Pets
{
    public class SlimeCoreBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Core of the Cyborg Slime");
            Description.SetDefault("It's friendly, probably");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetExtinctionPlayer().slimeCorePet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<SlimeCore>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, ModContent.ProjectileType<SlimeCore>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}