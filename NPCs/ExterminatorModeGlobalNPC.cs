using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.NPCs
{
    public class ExterminatorModeGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool canHurt;

        public override void SetDefaults(NPC npc)
        {
            canHurt = true;

            if (!ExtinctionWorld.ExterminatorMode)
            {
                return;
            }
            npc.value = (int)(npc.value * 1.3);

            switch (npc.type)
            {
                #region enemies npcs

                case NPCID.GoblinWarrior:
                    npc.knockBackResist /= 6;
                    break;

                case NPCID.Pixie:
                    npc.noTileCollide = true;
                    break;

                case NPCID.WyvernHead:
                    if (Main.hardMode)
                    {
                        npc.lifeMax *= (int)1.5;
                    }
                    else
                    {
                        npc.defense /= 2;
                    }
                    break;

                case NPCID.Moth:
                    npc.lifeMax *= (int)1.5;
                    break;

                case NPCID.Salamander:
                case NPCID.Salamander2:
                case NPCID.Salamander3:
                case NPCID.Salamander4:
                case NPCID.Salamander5:
                case NPCID.Salamander6:
                case NPCID.Salamander7:
                case NPCID.Salamander8:
                case NPCID.Salamander9:
                    npc.Opacity /= 5;
                    break;

                case NPCID.Mothron:
                case NPCID.MothronSpawn:
                    npc.knockBackResist *= .1f;
                    break;

                case NPCID.Butcher:
                    npc.knockBackResist = 0f;
                    break;

                case NPCID.ChaosElemental:
                    npc.buffImmune[BuffID.Confused] = true;
                    break;

                case NPCID.Tim:
                case NPCID.RuneWizard:
                    npc.buffImmune[BuffID.OnFire] = true;
                    npc.lavaImmune = true;
                    npc.lifeMax *= 4;
                    npc.damage /= 2;
                    break;

                case NPCID.LostGirl:
                case NPCID.Nymph:
                    npc.lavaImmune = true;
                    npc.buffImmune[BuffID.Confused] = true;
                    if (Main.hardMode)
                    {
                        npc.lifeMax *= (int)3.5;
                        npc.damage *= (int)1.5;
                        npc.defense *= (int)1.5;
                    }
                    break;

                case NPCID.Shark:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.Piranha:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.DD2SkeletonT1:
                case NPCID.DD2SkeletonT3:
                    npc.lifeMax = (int)(npc.lifeMax * 2.5);
                    break;

                case NPCID.BloodFeeder:
                    npc.lifeMax *= (int)3.5;
                    break;

                case NPCID.VileSpit:
                    npc.scale *= 1.25f;
                    break;

                case NPCID.WanderingEye:
                    npc.lifeMax *= (int)1.5;
                    break;

                case NPCID.BigEater:
                case NPCID.EaterofSouls:
                case NPCID.LittleEater:
                    break;

                case NPCID.PirateShip:
                    npc.noTileCollide = true;
                    break;

                case NPCID.PirateShipCannon:
                    npc.noTileCollide = true;
                    break;

                case NPCID.MisterStabby:
                case NPCID.AnglerFish:
                    npc.Opacity /= 5;
                    break;

                case NPCID.SolarSolenian:
                    npc.knockBackResist = 0f;
                    break;

                case NPCID.RainbowSlime:
                    npc.scale = 3f;
                    npc.lifeMax *= (int)4.5;
                    npc.knockBackResist = 0f;
                    break;

                case NPCID.Hellhound:
                    npc.lavaImmune = true;
                    break;

                case NPCID.WalkingAntlion:
                    npc.knockBackResist = .4f;
                    break;

                case NPCID.Tumbleweed:
                    npc.knockBackResist = .1f;
                    break;

                case NPCID.DesertBeast:
                    npc.lifeMax *= 2;
                    npc.knockBackResist = 0f;
                    break;

                case NPCID.DuneSplicerHead:
                case NPCID.DuneSplicerBody:
                case NPCID.DuneSplicerTail:
                    if (Main.hardMode)
                    {
                        npc.lifeMax *= (int)2.5;
                    }
                    else
                    {
                        npc.defense /= 2;
                        npc.damage /= 2;
                    }
                    break;

                case NPCID.StardustCellSmall:
                    npc.defense = 80;
                    break;

                case NPCID.Parrot:
                    npc.noTileCollide = true;
                    break;

                case NPCID.SolarSroller:
                    npc.scale += 0.5f;
                    break;

                case NPCID.ChaosBall:
                    npc.dontTakeDamage = Main.hardMode;
                    break;

                case NPCID.DoctorBones:
                case NPCID.Lihzahrd:
                case NPCID.FlyingSnake:
                    npc.trapImmune = true;
                    break;

                case NPCID.SolarCrawltipedeTail:
                    npc.trapImmune = true;
                    break;

                case NPCID.SolarGoop:
                    npc.noTileCollide = true;
                    npc.buffImmune[BuffID.OnFire] = true;
                    npc.lavaImmune = true;
                    break;

                case NPCID.Clown:
                    npc.lifeMax *= (int)1.5;
                    break;

                case NPCID.CultistArcherWhite:
                    npc.chaseable = true;
                    npc.lavaImmune = false;
                    npc.value = Item.buyPrice(0, 1);
                    npc.lifeMax *= 2;
                    break;

                case NPCID.Reaper:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.EnchantedSword:
                case NPCID.CursedHammer:
                case NPCID.CrimsonAxe:
                    npc.scale = 2f;
                    npc.lifeMax *= (int)3.5;
                    npc.defense *= (int)1.5;
                    npc.knockBackResist = 0f;
                    break;

                case NPCID.Pumpking:
                case NPCID.IceQueen:
                    npc.lifeMax = (int)(npc.lifeMax * 1.2);
                    break;

                case NPCID.Mimic:
                case NPCID.Medusa:
                case NPCID.PigronCorruption:
                case NPCID.PigronCrimson:
                case NPCID.PigronHallow:
                case NPCID.IchorSticker:
                case NPCID.SeekerHead:
                case NPCID.AngryNimbus:
                case NPCID.RedDevil:
                case NPCID.MushiLadybug:
                case NPCID.AnomuraFungus:
                case NPCID.ZombieMushroom:
                case NPCID.ZombieMushroomHat:
                    if (!Main.hardMode)
                    {
                        npc.defense /= 2;
                    }
                    break;

                case NPCID.Derpling:
                    npc.scale *= .4f;
                    break;

                case NPCID.BlazingWheel:
                    npc.scale *= 1.5f;
                    break;

                case NPCID.SandSlime:
                case NPCID.BabySlime:
                case NPCID.BlackSlime:
                case NPCID.BlueSlime:
                case NPCID.GreenSlime:
                case NPCID.IceSlime:
                case NPCID.JungleSlime:
                case NPCID.MotherSlime:
                case NPCID.PurpleSlime:
                case NPCID.RedSlime:
                case NPCID.UmbrellaSlime:
                case NPCID.YellowSlime:
                case NPCID.IlluminantSlime:
                    npc.lifeMax *= (int)1.5;
                    npc.damage *= (int)1.5;
                    break;

                case NPCID.SlimeSpiked:
                case NPCID.CorruptSlime:
                case NPCID.Crimslime:
                case NPCID.SpikedJungleSlime:
                case NPCID.SpikedIceSlime:
                case NPCID.DungeonSlime:
                    npc.lifeMax = (int)(npc.lifeMax * 2.5);
                    npc.damage = (int)(npc.damage * 2.5);
                    break;

                #endregion enemies npcs

                #region exterminator bosses

                case NPCID.KingSlime:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.ServantofCthulhu:
                    npc.lifeMax *= 2;
                    break;

                case NPCID.BrainofCthulhu:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    npc.scale += 0.25f;
                    break;

                case NPCID.Creeper:
                    npc.lifeMax = (int)(npc.lifeMax * 1.25);
                    break;

                case NPCID.QueenBee:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.Skeleton:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.SkeletronHand:
                    npc.defense = (int)(npc.defense * 1.2);
                    break;

                case NPCID.WallofFlesh:
                    npc.defense *= 10;
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.WallofFleshEye:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.TheHungryII:
                    npc.noTileCollide = true;
                    break;

                case NPCID.SkeletronPrime:
                    npc.trapImmune = true;
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.Spazmatism:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.Retinazer:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.TheDestroyer:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.PrimeCannon:
                case NPCID.PrimeLaser:
                case NPCID.PrimeSaw:
                case NPCID.PrimeVice:
                    npc.dontTakeDamage = true;
                    npc.trapImmune = true;
                    break;

                case NPCID.Golem:
                    npc.lifeMax *= (int)2.5;
                    npc.trapImmune = true;
                    break;

                case NPCID.GolemHead:
                    npc.trapImmune = true;
                    break;

                case NPCID.GolemHeadFree:
                    npc.scale = (int)(npc.scale * 1.25);
                    break;

                case NPCID.GolemFistLeft:
                case NPCID.GolemFistRight:
                    npc.scale += 0.5f;
                    npc.trapImmune = true;
                    break;

                case NPCID.Plantera:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    break;

                case NPCID.DukeFishron:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.DetonatingBubble:
                    npc.lavaImmune = true;
                    npc.buffImmune[BuffID.OnFire] = true;
                    if (!NPC.downedBoss3)
                        npc.noTileCollide = false;
                    break;

                case NPCID.Sharkron:
                case NPCID.Sharkron2:
                    npc.lifeMax *= 4;
                    npc.buffImmune[BuffID.OnFire] = true;
                    npc.lavaImmune = true;
                    break;

                case NPCID.DD2Betsy:
                    npc.boss = true;
                    break;

                case NPCID.CultistBoss:
                    npc.lifeMax = (int)(npc.lifeMax * 1.5);
                    canHurt = false;
                    break;

                case NPCID.CultistBossClone:
                    npc.defense += 4;
                    break;

                case NPCID.AncientDoom:
                    npc.lifeMax *= 3;
                    break;

                case NPCID.AncientLight:
                    npc.buffImmune[BuffID.OnFire] = true;
                    npc.lavaImmune = true;
                    break;

                case NPCID.MoonLordCore:
                    canHurt = false;
                    break;

                case NPCID.LunarTowerSolar:
                case NPCID.LunarTowerNebula:
                case NPCID.LunarTowerStardust:
                case NPCID.LunarTowerVortex:
                    npc.lifeMax = (int)(npc.lifeMax * 1.3);
                    break;

                case NPCID.MoonLordHead:
                    npc.lifeMax /= 2;

                    goto case NPCID.MoonLordHand;
                case NPCID.MoonLordHand:
                case NPCID.MoonLordFreeEye:
                case NPCID.MoonLordLeechBlob:
                    canHurt = false;
                    break;

                    #endregion exterminator bosses
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (ExtinctionWorld.ExterminatorMode)
            {
                spawnRate = (int)(spawnRate * 0.9);
                maxSpawns = (int)(maxSpawns * 1.25f);
            }
        }
    }
}