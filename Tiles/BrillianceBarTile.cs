using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExtinctionTalesMod.Tiles
{
    public class BrillianceBarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);
            drop = ModContent.ItemType<BrillianceBar>();

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Brilliance Bar");
            AddMapEntry(new Color(218, 207, 142), name);

            minPick = 200;
            dustType = DustID.Sunflower;
        }
    }
}