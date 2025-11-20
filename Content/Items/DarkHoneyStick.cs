using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace BeeStation.Content.Items
{
	public class DarkHoneyStick : ModItem
    {
		// public override void SetStaticDefaults()
	    // {

			//DisplayName.SetDefault("Dark Honey on a Stick"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
									  //Tooltip.SetDefault("");
		// }

		public override void SetDefaults()
		{
			Item.damage = -1;
			Item.DamageType = DamageClass.Magic;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 85;
			Item.useAnimation = 85;
			Item.healLife = 20;
			Item.mana = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 2300;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item54;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Ebonwood, 18);
			recipe1.AddIngredient(ItemID.BlackCurrant, 1);
			recipe1.AddTile(TileID.Trees);
			recipe1.Register();
			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.Ebonwood, 18);
			recipe2.AddIngredient(ItemID.Elderberry, 1);
			recipe2.AddTile(TileID.Trees);
			recipe2.Register();
			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.Shadewood, 18);
			recipe3.AddIngredient(ItemID.BlackCurrant, 1);
			recipe3.AddTile(TileID.Trees);
			recipe3.Register();
			Recipe recipe4 = CreateRecipe();
			recipe4.AddIngredient(ItemID.Shadewood, 18);
			recipe4.AddIngredient(ItemID.Elderberry, 1);
			recipe4.AddTile(TileID.Trees);
			recipe4.Register();
		}
    }
}