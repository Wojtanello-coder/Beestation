using BeeStation.Content.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeeStation.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class WaspmatMask : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.sellPrice(gold: 1, silver: 75); // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 5;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<TemperedComb>(15)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
