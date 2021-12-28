using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Projectiles
{
    public class ExtinctionGlobalProj : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override void OnHitPlayer(Projectile projectile, Player target, int damage, bool crit)
        {
            switch (projectile.type)
            {
                case ProjectileID.Nail:
                    target.AddBuff(BuffID.Bleeding, 120);
                    break;
            }
        }
    }
}