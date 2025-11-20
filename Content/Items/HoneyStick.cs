using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BeeStation.Content.Items
{
    public class HoneyStick : ModItem
    {
	  // public override void SetStaticDefaults()
	  // {
		//DisplayName.SetDefault("Honey on a Stick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
		//Tooltip.SetDefault("");
	  // }

	  public override void SetDefaults()
	  {
		Item.damage = -1;
		Item.DamageType = DamageClass.Magic;
		Item.width = 20;
		Item.height = 20;
		Item.useTime = 35;
		Item.useAnimation = 35;
		Item.healLife = 2;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.knockBack = 6;
		Item.value = 1400;
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item54;
		Item.autoReuse = true;
	  }

	  public override void AddRecipes()
	  {
		Recipe recipe1 = CreateRecipe();
		recipe1.AddRecipeGroup("Wood", 18);
		recipe1.AddIngredient(ItemID.Lemon);
		recipe1.AddTile(TileID.Trees);
		recipe1.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddRecipeGroup("Wood", 18);
		recipe2.AddIngredient(ItemID.Apple);
		recipe2.AddTile(TileID.Trees);
		recipe2.Register();
		Recipe recipe3 = CreateRecipe();
		recipe3.AddRecipeGroup("Wood", 18);
		recipe3.AddIngredient(ItemID.Apricot);
		recipe3.AddTile(TileID.Trees);
		recipe3.Register();
		Recipe recipe4 = CreateRecipe();
		recipe4.AddRecipeGroup("Wood", 18);
		recipe4.AddIngredient(ItemID.Grapefruit);
		recipe4.AddTile(TileID.Trees);
		recipe4.Register();
		Recipe recipe5 = CreateRecipe();
		recipe5.AddRecipeGroup("Wood", 18);
		recipe5.AddIngredient(ItemID.Peach);
		recipe5.AddTile(TileID.Trees);
		recipe5.Register();
	  }
    }
}