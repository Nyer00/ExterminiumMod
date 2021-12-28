using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Classes.Assassin
{
    public class AssassinPlayer : ModPlayer
    {
        public float assassinDamageAdd;
        public float assassinDamageMult = 1f;
        public float assassinKnockback;
        public int assassinCrit;

        public static AssassinPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<AssassinPlayer>();
        }

        public override void Initialize()
        {
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            assassinDamageAdd = 0f;
            assassinDamageMult = 1f;
            assassinKnockback = 0f;
            assassinCrit = 0;
        }

        public override void PostUpdateMiscEffects()
        {
        }
    }
}