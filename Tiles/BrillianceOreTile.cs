using ExtinctionTalesMod.Items.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Tiles
{
    public class BrillianceOreTile : ModTile
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
            Main.tileValue[Type] = 700;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Brilliance");
            AddMapEntry(new Color(218, 207, 142), name);

            drop = ModContent.ItemType<BrillianceOre>();
            minPick = 200;
            dustType = DustID.Sunflower;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.75f;
            g = 0.25f;
            b = 0.5f;
        }
    }
}