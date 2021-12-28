using ExtinctionTalesMod.Items.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Tiles
{
    public class ViriumOreTile : ModTile
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
            Main.tileValue[Type] = 270;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Virium");
            AddMapEntry(new Color(120, 0, 120), name);

            drop = ModContent.ItemType<ViriumOre>();
            minPick = 50;
            dustType = DustID.Demonite;
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