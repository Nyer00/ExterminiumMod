using ExtinctionTalesMod.Items.Placeables;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExtinctionTalesMod.Tiles
{
    public class TemporalMonument : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16 };
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Temporal Monument");
            AddMapEntry(new Color(200, 200, 200), name);
            disableSmartCursor = true;
        }

        public override bool HasSmartInteract()
        {
            return true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<TemporalMonumentItem>());
        }

        public override bool NewRightClick(int i, int j)
        {
            for (int z = 0; z < Main.maxNPCs; z++)
            {
                if (Main.npc[z].active && Main.npc[z].boss)
                {
                    string text1 = "Unable to use while a Boss is alive";
                    Color textColor1 = Color.Purple;
                    ExtinctionUtils.DisplayLocalText(text1, new Color?(textColor1));
                    return false;
                }
            }
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Main.time = 0;
                Main.dayTime = !Main.dayTime;
                if (Main.dayTime && ++Main.moonPhase >= 8)
                {
                    Main.moonPhase = 0;
                }
                ExtinctionNet.SyncMultiplayer();
            }
            Main.PlaySound(SoundID.Item60);
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ModContent.ItemType<TemporalMonumentItem>();
        }
    }
}