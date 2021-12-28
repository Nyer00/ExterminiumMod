using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Classes.Assassin
{
    public abstract class AssassinWeapon : ModItem
    {
        public override bool CloneNewInstances => true;

        public virtual void SafeSetDefaults()
        {
        }

        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            item.melee = true;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += AssassinPlayer.ModPlayer(player).assassinDamageAdd;
            mult *= AssassinPlayer.ModPlayer(player).assassinDamageMult;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += AssassinPlayer.ModPlayer(player).assassinKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += AssassinPlayer.ModPlayer(player).assassinCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                tt.text = damageValue + " assassin " + damageWord;
            }
        }
    }
}