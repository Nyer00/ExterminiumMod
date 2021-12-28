using ExtinctionTalesMod.Items.Consumables.Foods;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.SummoningItems.Bosses;
using ExtinctionTalesMod.Items.Weapons.Magic;
using ExtinctionTalesMod.Items.Weapons.Melee;
using ExtinctionTalesMod.Items.Weapons.Ranged;
using ExtinctionTalesMod.Tiles;
using ExtinctionTalesMod.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs
{
    public class ExtinctionGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool overheatingEnemies;
        public bool brokenBonesEnemies;

        public override void ResetEffects(NPC npc)
        {
            overheatingEnemies = false;
            brokenBonesEnemies = false;
        }

        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.SkeletronHead:
                    Item.NewItem(npc.getRect(), ItemID.Bone, Main.rand.Next(10, 21));
                    break;

                case NPCID.Demon:
                case NPCID.VoodooDemon:
                case NPCID.BoneSerpentHead:
                    if (Main.rand.NextBool(3))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<MagmaCrystal>(), Main.rand.Next(2, 6));
                        if (Main.hardMode)
                        {
                            Item.NewItem(npc.getRect(), ModContent.ItemType<MagmaCrystal>(), Main.rand.Next(4, 7));
                        }
                    }
                    break;

                case NPCID.Necromancer:
                case NPCID.RaggedCaster:
                case NPCID.DiabolistRed:
                case NPCID.DiabolistWhite:
                    if (Main.rand.NextBool(8))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<HopelessSoulsTome>());
                    }
                    break;

                case NPCID.Plantera:
                    if (!ExtinctionWorld.chargedGraniteGen)
                    {
                        string text = "The Granite empowers.";
                        Color textColor = Color.Blue;
                        ExtinctionUtils.DisplayLocalText(text, new Color?(textColor));
                        ExtinctionWorld.chargedGraniteGen = true;
                        for (double num = 0.0; num < (Main.maxTilesX - 200) * (Main.maxTilesY - 150 - (int)Main.rockLayer) / 8000.0; ++num)
                        {
                            WorldGen.OreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 8), (ushort)ModContent.TileType<ChargedGraniteTile>());
                        }
                        ExtinctionNet.SyncMultiplayer();
                    }
                    if (!ExtinctionWorld.ancientMarbleGen)
                    {
                        string text = "The Ancient Marble recovers its essence.";
                        Color textColor = Color.Silver;
                        ExtinctionUtils.DisplayLocalText(text, new Color?(textColor));
                        ExtinctionWorld.ancientMarbleGen = true;
                        for (double num = 0.0; num < (Main.maxTilesX - 200) * (Main.maxTilesY - 150 - (int)Main.rockLayer) / 8000.0; ++num)
                        {
                            WorldGen.OreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), WorldGen.genRand.Next(5, 8), WorldGen.genRand.Next(5, 8), (ushort)ModContent.TileType<AncientMarbleTile>());
                        }
                        ExtinctionNet.SyncMultiplayer();
                    }
                    break;

                case NPCID.WallofFlesh:
                    if (Main.rand.NextBool(8))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ZwillCrossblade>());
                    }
                    break;

                case NPCID.GraniteFlyer:
                case NPCID.GraniteGolem:
                    if (Main.rand.NextBool(4))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ElementalGraniteCharge>(), Main.rand.Next(4, 9));
                    }
                    break;

                case NPCID.Zombie:
                case NPCID.SlimedZombie:
                case NPCID.ZombieRaincoat:
                case NPCID.FemaleZombie:
                    if (Main.rand.NextBool(6))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Nugget>(), Main.rand.Next(1, 3));
                    }
                    break;

                case NPCID.Medusa:
                case NPCID.GreekSkeleton:
                    if (Main.rand.NextBool(4))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<ElementalMarblePieces>(), Main.rand.Next(4, 9));
                    }
                    break;
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (overheatingEnemies)
            {
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Fire, 0.5f, 0.5f, 0, default, 1f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 2f;
                drawColor.R = 255;
                drawColor.G = 78;
                drawColor.B = 0;
            }
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (brokenBonesEnemies)
            {
                npc.lifeRegen -= 2;
            }
            if (overheatingEnemies)
            {
                npc.lifeRegen -= 6;
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.ArmsDealer:
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<CarbineRifle>());
                    nextSlot++;
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<Magnus>());
                        nextSlot++;
                    }
                    break;

                case NPCID.Dryad:
                    if (ExtinctionWorld.downedFungalDigger)
                    {
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<MushroomBait>());
                        nextSlot++;
                    }
                    break;
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetExtinctionPlayer().bossCurse)
            {
                spawnRate *= 5;
                maxSpawns = (int)(maxSpawns * 0.001f);
            }
        }
    }
}