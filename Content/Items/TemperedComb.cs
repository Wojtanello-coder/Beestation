using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeeStation.Content.Items
{
    public class TemperedComb : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }
        public override void SetDefaults()
        {
            Item.width = 16; // The item texture's width
            Item.height = 16; // The item texture's height

            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.buyPrice(silver: 10); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FallenStar)
                .AddIngredient(ItemID.HoneyBlock,2)
                .AddIngredient(ItemID.IceBlock)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
