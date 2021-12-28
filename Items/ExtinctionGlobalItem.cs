using ExtinctionTalesMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items
{
    public class ExtinctionGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.ReaverShark:
                    item.pick = 60;
                    break;

                default:
                    break;
            }
        }

        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            if ((extractType == ItemID.SlushBlock || extractType == ItemID.DesertFossil) && resultType >= 177 && resultType <= 182)
            {
                switch (Main.rand.Next(8))
                {
                    case 0:
                        resultType = ModContent.ItemType<OnyxGem>();
                        break;

                    case 1:
                        if (Main.hardMode)
                        {
                            resultType = ModContent.ItemType<SunstoneGem>();
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}