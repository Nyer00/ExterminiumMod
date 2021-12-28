using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Buffs
{
    public class ExtinctionGlobalBuff : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            switch (type)
            {
                #region movespeed reduce

                case BuffID.OnFire:
                case BuffID.Confused:
                case BuffID.CursedInferno:
                case BuffID.Ichor:
                case BuffID.Poisoned:
                case BuffID.Cursed:
                    if (ExtinctionWorld.ExterminatorMode)
                    {
                        player.moveSpeed -= 0.1f;
                    }
                    break;

                    #endregion
            }
        }
    }
}