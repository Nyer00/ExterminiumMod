using ExtinctionTalesMod.Tiles;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace ExtinctionTalesMod
{
    public class ExtinctionWorld : ModWorld
    {
        public static bool chargedGraniteGen;
        public static bool ancientMarbleGen;
        public static bool brillianceOreGen;
        public static bool downedCyborgSlime;
        public static bool downedFungalDigger;
        public static bool downedRuneWarrior;
        public static bool ExterminatorMode;

        public override void Initialize()
        {
            ExterminatorMode = false;
            downedCyborgSlime = false;
            downedFungalDigger = false;
            downedRuneWarrior = false;
            brillianceOreGen = false;
            chargedGraniteGen = false;
            ancientMarbleGen = false;
        }

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int num = tasks.FindIndex(GenPass => GenPass.Name.Equals("Reset"));
            num = tasks.FindIndex(GenPass => GenPass.Name.Equals("Shinies"));
            if (num != -1)
            {
                tasks.Insert(num + 1, new PassLegacy("Extinction Tales Ores", new WorldGenLegacyMethod(ExtinctionModOres)));
            }
            num = tasks.FindIndex(GenPass => GenPass.Name.Equals("Gems"));
            if (num != -1)
            {
                tasks.Insert(num + 1, new PassLegacy("Extinction Tales Gems", new WorldGenLegacyMethod(ExtinctionModGems)));
            }
        }

        private void ExtinctionModOres(GenerationProgress progress)
        {
            progress.Message = "Extinction Tales: " + Language.GetTextValue("LegacyWorldGen.16");

            for (int i = 0; i < Main.maxTilesX * Main.maxTilesY * 0.00015; i++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY * 0.5f), Main.maxTilesY), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), ModContent.TileType<ViriumOreTile>(), false, 0f, 0f, false, true);
            }
        }

        private void ExtinctionModGems(GenerationProgress progress)
        {
            progress.Message = Language.GetTextValue("LegacyWorldGen.23");

            for (int i = 0; i < 2; i++)
            {
                int num = (int)(Main.maxTilesX * ((i == 0) ? 0.4f : 0.3f) * 0.2f);
                for (int j = 0; j < num; j++)
                {
                    int num2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int num3 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    while (Main.tile[num2, num3].type != 1)
                    {
                        num2 = WorldGen.genRand.Next(0, Main.maxTilesX);
                        num3 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    }
                    WorldGen.TileRunner(num2, num3, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), ModContent.TileType<OnyxGem>(), false, 0f, 0f, false, true);
                }
            }
        }

        public override TagCompound Save()
        {
            List<string> downed = new List<string>();
            if (downedCyborgSlime) downed.Add("cyborgSlime");
            if (ExterminatorMode) downed.Add("exterminator");
            if (downedFungalDigger) downed.Add("fungaldigger");
            if (downedRuneWarrior) downed.Add("runewarrior");
            if (brillianceOreGen) downed.Add("brillianceore");
            if (chargedGraniteGen) downed.Add("chargedgranite");
            if (ancientMarbleGen) downed.Add("ancientmarble");

            return new TagCompound
            {
                {"downed", downed}
            };
        }

        public override void Load(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            downedCyborgSlime = downed.Contains("cyborgSlime");
            ExterminatorMode = downed.Contains("exterminator");
            downedFungalDigger = downed.Contains("fungaldigger");
            downedRuneWarrior = downed.Contains("runewarrior");
            brillianceOreGen = downed.Contains("brillianceore");
            chargedGraniteGen = downed.Contains("chargedgranite");
            ancientMarbleGen = downed.Contains("ancientmarble");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();

                downedCyborgSlime = flags[1];
                ExterminatorMode = flags[2];
                downedFungalDigger = flags[3];
                downedRuneWarrior = flags[4];
                brillianceOreGen = flags[5];
                chargedGraniteGen = flags[6];
                ancientMarbleGen = flags[7];
            }
            else
            {
                mod.Logger.Error("Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte
            {
                [1] = downedCyborgSlime,
                [2] = ExterminatorMode,
                [3] = downedFungalDigger,
                [4] = downedRuneWarrior,
                [5] = brillianceOreGen,
                [6] = chargedGraniteGen,
                [7] = ancientMarbleGen
            };

            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedCyborgSlime = flags[1];
            ExterminatorMode = flags[2];
            downedFungalDigger = flags[3];
            downedRuneWarrior = flags[4];
            brillianceOreGen = flags[5];
            chargedGraniteGen = flags[6];
            ancientMarbleGen = flags[7];
        }

        public override void PostUpdate()
        {
            if (ExterminatorMode)
            {
                if (!Main.expertMode)
                {
                    ExterminatorMode = false;
                }
            }
        }
    }
}