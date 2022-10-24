using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BeeStation.Items
{
    public class SweetStick : ModItem
    {
	  public override void SetStaticDefaults()
	  {
		DisplayName.SetDefault("Sweet on a Stick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
								    //Tooltip.SetDefault("");
	  }

	  public override void SetDefaults()
	  {
		Item.damage = -1;
		Item.DamageType = DamageClass.Magic;
		Item.width = 20;
		Item.height = 20;
		Item.useTime = 8;
		Item.useAnimation = 8;
		Item.healLife = 4;
		Item.mana = 4;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.knockBack = 6;
		Item.value = 3600;
		Item.rare = 2;
		Item.UseSound = SoundID.Item54;
		Item.autoReuse = true;
	  }

	  public override void AddRecipes()
	  {
		Recipe recipe1 = CreateRecipe();
		recipe1.AddIngredient(ItemID.Pearlwood, 18);
		recipe1.AddIngredient(ItemID.Starfruit);
		recipe1.AddTile(TileID.Trees);
		recipe1.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(ItemID.Pearlwood, 18);
		recipe2.AddIngredient(ItemID.Dragonfruit);
		recipe2.AddTile(TileID.Trees);
		recipe2.Register();
	  }
    }
}