using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.RuneWarrior
{
    public class PossessedHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Helmet");
            Tooltip.SetDefault("Increases damage at the cost of 10% of your life\nImmunity to Bleeding\nExterminator Mode");
        }

        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 32;
            item.accessory = true;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
            item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.15f;
            player.GetAssassinPlayer().assassinDamageAdd += 0.15f;
            player.buffImmune[BuffID.Bleeding] = true;
            player.statLifeMax2 -= 40;
        }
    }
}