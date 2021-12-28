using ExtinctionTalesMod.Items.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Tiles
{
    public class AncientMarbleTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileValue[Type] = 750;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Ancient Marble");
            AddMapEntry(new Color(200, 200, 200), name);

            drop = ModContent.ItemType<AncientMarbleShards>();
            minPick = 200;
            dustType = DustID.Silver;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
    }
}