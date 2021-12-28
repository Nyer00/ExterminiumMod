using ExtinctionTalesMod.Items.Equipment.Equipables.Pets;
using ExtinctionTalesMod.Items.Equipment.Vanities.BossesVanities;
using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.CyborgSlime;
using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.FungalDigger;
using ExtinctionTalesMod.Items.ExModeItems.BossDrops.Accessories.RuneWarrior;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Items.Ores;
using ExtinctionTalesMod.Items.SummoningItems.Bosses;
using ExtinctionTalesMod.Items.TreasureBags;
using ExtinctionTalesMod.Items.Weapons.BossDrops.AncientFungalDigger;
using ExtinctionTalesMod.Items.Weapons.BossDrops.CyborgSlime;
using ExtinctionTalesMod.Items.Weapons.BossDrops.RuneWarrior;
using ExtinctionTalesMod.NPCs.Bosses.CyborgSlime;
using ExtinctionTalesMod.NPCs.Bosses.FungalDigger;
using ExtinctionTalesMod.NPCs.Bosses.RuneWarrior;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ExtinctionTalesMod
{
    public class ExtinctionMod : Mod
    {
        internal UserInterface ExtinctionPersonUserInterface;
        internal static ExtinctionMod Instance;

        public ExtinctionMod() => Instance = this;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.PixieDust, 35);
            recipe.AddIngredient(ItemID.CrystalShard, 25);
            recipe.AddIngredient(ItemID.UnicornHorn, 5);
            recipe.AddIngredient(ItemID.PinkGel, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.RodofDiscord);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Shotgun);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ModContent.ItemType<OnyxGem>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ItemID.OnyxBlaster);
            recipe.AddRecipe();
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.GoldBar), ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyGoldBar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.IronBar), ItemID.IronBar, ItemID.LeadBar);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyIronBar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.CursedFlame), ItemID.CursedFlame, ItemID.Ichor);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyEvilFlame", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.ShadowScale), ItemID.ShadowScale, ItemID.TissueSample);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyEvilTissue", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.CobaltBar), ItemID.CobaltBar, ItemID.PalladiumBar);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyTier1HMBar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.MythrilBar), ItemID.MythrilBar, ItemID.OrichalcumBar);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyTier2HMBar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.AdamantiteBar), ItemID.AdamantiteBar, ItemID.TitaniumBar);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyTier3HMBar", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.MythrilAnvil), ItemID.MythrilAnvil, ItemID.OrichalcumAnvil);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyHMAnvil", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Lang.GetItemNameValue(ItemID.TitaniumForge), ItemID.TitaniumForge, ItemID.AdamantiteForge);
            RecipeGroup.RegisterGroup("ExtinctionTalesMod:AnyHMForge", group);
        }

        public override void UpdateUI(GameTime gameTime)
        {
            ExtinctionPersonUserInterface?.Update(gameTime);
        }

        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    4.2f,
                    ModContent.NPCType<FungalDiggerHead>(),
                    this,
                    "Ancient Fungal Digger",
                    (Func<bool>)(() => ExtinctionWorld.downedFungalDigger),
                    ModContent.ItemType<MushroomBait>(),
                    new List<int> { },
                    new List<int> { ModContent.ItemType<FungalDiggerBag>(), ModContent.ItemType<HarvesterHeart>(), ModContent.ItemType<MushroomSniper>(), ItemID.GlowingMushroom, ItemID.LesserHealingPotion },
                    "Use a [i: " + ModContent.ItemType<MushroomBait>() + "] at a Glowing Mushroom biome",
                    null,
                    "ExtinctionTalesMod/Textures/BossChecklist/FungalDiggerTexture",
                    "ExtinctionTalesMod/NPCs/Bosses/FungalDigger/FungalDiggerHead_Head_Boss",
                    null);
                bossChecklist.Call(
                    "AddBoss",
                    5.9f,
                    ModContent.NPCType<CyborgSlime>(),
                    this,
                    "Cyborg Slime",
                    (Func<bool>)(() => ExtinctionWorld.downedCyborgSlime),
                    ModContent.ItemType<SlimyRemote>(),
                    new List<int> { ModContent.ItemType<CyborgSlimeMask>() },
                    new List<int> { ModContent.ItemType<CyborgSlimeBag>(), ModContent.ItemType<SlimeCoreItem>(), ModContent.ItemType<EnergizedCore>(), ModContent.ItemType<HardwareBit>(), ModContent.ItemType<MechanicalDagger>(), ItemID.LesserHealingPotion, ItemID.Gel },
                    "Use a [i: " + ModContent.ItemType<SlimyRemote>() + "] at the surface at anytime after defeating Skeletron.",
                    null,
                    "ExtinctionTalesMod/Textures/BossChecklist/CyborgSLimeTexture",
                    "ExtinctionTalesMod/NPCs/Bosses/CyborgSlime/CyborgSlime_Head_Boss",
                    null);
                bossChecklist.Call(
                    "AddBoss",
                    7.3f,
                    ModContent.NPCType<RuneWarrior>(),
                    this,
                    "Rune Warrior",
                    (Func<bool>)(() => ExtinctionWorld.downedRuneWarrior),
                    ModContent.ItemType<WarriorsHorn>(),
                    new List<int> { },
                    new List<int> { ModContent.ItemType<RuneWarriorBag>(), ModContent.ItemType<PossessedHelmet>(), ModContent.ItemType<RuneBlade>(), ModContent.ItemType<PossessedPike>(), ModContent.ItemType<BrillianceOre>(), ItemID.GreaterHealingPotion },
                    "Use a [i: " + ModContent.ItemType<WarriorsHorn>() + "] at the Dungeon.",
                    null,
                    "ExtinctionTalesMod/Textures/BossChecklist/RuneWarriorTexture",
                    "ExtinctionTalesMod/NPCs/Bosses/RuneWarrior/RuneWarrior_Head_Boss",
                    null);
            }
        }

        public override void Load()
        {
            Logger.InfoFormat("{0} extinction logging", Name);
            ExtinctionPersonUserInterface = new UserInterface();
            ExtinctionLocalization.AddLocalizations();
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> screenRef = new Ref<Effect>(GetEffect("Effects/ShockwaveEffect"));
                Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                Filters.Scene["Shockwave"].Load();
            }
        }
    }
}