using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BeeStation.Content.Items
{
    public class SweetIcicle : ModItem
    {
	  // public override void SetStaticDefaults()
	  // {
			// DisplayName.SetDefault("Sweet Icicle"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
									  //Tooltip.SetDefault("");
	  // }

	  public override void SetDefaults()
	  {
		Item.damage = -1;
		Item.DamageType = DamageClass.Magic;
		Item.width = 20;
		Item.height = 20;
		Item.useTime = 50;
		Item.useAnimation = 50;
		Item.healMana = 12;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.knockBack = 6;
		Item.value = 1800;
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item54;
		Item.autoReuse = true;
	  }

	  public override void AddRecipes()
	  {
		Recipe recipe1 = CreateRecipe();
		recipe1.AddIngredient(ItemID.IceBlock , 18);
		recipe1.AddIngredient(ItemID.Cherry);
		recipe1.AddTile(TileID.Trees);
		recipe1.Register();
		Recipe recipe2 = CreateRecipe();
		recipe2.AddIngredient(ItemID.IceBlock, 18);
		recipe2.AddIngredient(ItemID.Plum);
		recipe2.AddTile(TileID.Trees);
		recipe2.Register();
	  }
    }
}