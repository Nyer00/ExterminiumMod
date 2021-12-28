using ExtinctionTalesMod.Items.IngotBars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExtinctionTalesMod.Tiles
{
    public class ViriumBarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.addTile(Type);
            drop = ModContent.ItemType<ViriumBar>();

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Virium Bar");
            AddMapEntry(new Color(222, 37, 222), name);

            minPick = 50;
            dustType = DustID.Orichalcum;
        }
    }
}