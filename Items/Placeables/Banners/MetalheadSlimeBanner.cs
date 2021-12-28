﻿using ExtinctionTalesMod.Tiles.Banners;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Placeables.Banners
{
    public class MetalheadSlimeBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 24;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.consumable = true;
            item.rare = ItemRarityID.Blue;
            item.value = Item.buyPrice(0, 0, 10);
            item.createTile = ModContent.TileType<MonsterBanner>();
            item.placeStyle = 1;
        }
    }
}