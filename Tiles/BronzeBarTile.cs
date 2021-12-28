using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExtinctionTalesMod.Tiles
{
    public class BronzeBarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);
            drop = ModContent.ItemType<BronzeBar>();

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Bronze Bar");
            AddMapEntry(new Color(112, 39, 0), name);

            minPick = 55;
            dustType = DustID.Copper;
        }
    }
}