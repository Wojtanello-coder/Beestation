using BeeStation.Common.Systems;
using SubworldLibrary;
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
    class WeirdMirror : ModItem
    {
        public override void SetDefaults()
        {
            Item.useTime = 60;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.RaiseLamp;
            Item.value = 21;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item50;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock);
            //recipe.AddIngredient(ItemID.Hive, 30);
            //recipe.AddIngredient(ItemID.FallenStar, 3);
            //recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool? UseItem(Player player)
        {
            SubworldSystem.Enter<BeehiveSubworld>();
            //if (SubworldSystem.Current.FullName == )
            //{
            //    Console.WriteLine("Going to main world.");
            //    SubworldSystem.Exit();
            //}
            //else
            //{
            //    Console.WriteLine("Going to subworld.");
            //    SubworldSystem.Enter<BeehiveSubworld>();
            //}
            return null;
        }
    }
}
