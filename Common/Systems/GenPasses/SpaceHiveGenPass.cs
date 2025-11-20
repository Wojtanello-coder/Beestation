using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BeeStation.Common.Systems.GenPasses
{
    class SpaceHiveGenPass : GenPass
    {
	  public SpaceHiveGenPass(string name, float weight) : base(name, weight)
	  {

	  }

	  protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
	  {
		progress.Message = "Generating More Bee Hives";

		int maxtoSpawn = (int)(Main.maxTilesX * 0.001);
		for(int i = 0; i < maxtoSpawn; i++)
		{
		    float[] angles = new float[360];
		    float rough = 0;
		    float noise = 1;

		    angles[0] = 40;
		    for(int j = 1; j < 360; j++)
		    {
			  rough = WorldGen.genRand.Next(0, (int)noise+1) * (angles[0] / angles[j-1]) - noise / 2;
			  angles[j] = angles[j-1] + rough;
		    }

		    int X;
		    do
		    {
			  X = WorldGen.genRand.Next(400, Main.maxTilesX - 400);
		    } while (X > Main.spawnTileX - 200 && X < Main.spawnTileX + 200);
		    int Y = Math.Abs(WorldGen.genRand.Next(100, 100));//(int)Main.worldSurface * 0.35f)); //(int)WorldGen.worldSurface




		    //WorldGen.TileRunner(X, Y, 10, 3, TileID.TopazGemspark, true);
		    for (int h = -50; h < 50; h++)
		    {
			  for (int k = -50; k < 50; k++)
			  {
				int angle = (int)Math.Atan2(h, k);
				if (Math.Sqrt(h * h + k * k) < angles[angle + 180] && Math.Sqrt(h * h + k * k) > angles[angle + 180] * 0.8)
				{
				    WorldUtils.Gen(new Point(X + h, Y + k), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Hive));
				}
				if (Math.Sqrt(h * h + k * k) < angles[angle + 180] - 2)
				{
				    WorldUtils.Gen(new Point(X + h, Y + k), new Shapes.Rectangle(1, 1), new Actions.PlaceWall(WallID.Hive));
				}
			  }
		    }
		    for(int a1 = 1; a1 <= 5; a1++)
		    {
			  for(int b1 = 0; b1 < a1; b1++)
			  {
				placeHoneyComb(X+6 - (a1*6) + (b1)*12, Y+27 - (a1*3)); //I y+24  II x1-6 x2+6 y+21
				placeHoneyComb(X+6 - (a1*6) + (b1)*12, Y-27 + (a1*3)); 
			  }

		    }
		    for (int a2 = 0; a2 < 7; a2++)
		    {
			  if (a2 % 2 == 0)
			  {
				for (int b2 = 0; b2 < 4; b2++)
				{
				    placeHoneyComb(X-18 + (b2*12), Y-9 + (a2*3));
				}
			  }
			  else
			  {
				for (int b2 = 0; b2 < 5; b2++)
				{
				    placeHoneyComb(X-24 + (b2*12), Y-9 + (a2*3));
				}
			  }
		    }
		}
		//int X = Main.spawnTileX;
		//int Y = Main.spawnTileY - 50;
	  }
	  private void placeHoneyComb(int x, int y, bool hasChest = false)
	  {
		if(WorldGen.genRand.Next(0, 2) == 0)
		{
		    WorldUtils.Gen(new Point(x - 1, y - 1), new Shapes.Rectangle(4, 4), new Actions.SetTile(TileID.HoneyBlock));
		    WorldUtils.Gen(new Point(x + 3, y), new Shapes.Rectangle(1, 2), new Actions.SetTile(TileID.HoneyBlock));
		    WorldUtils.Gen(new Point(x - 2, y), new Shapes.Rectangle(1, 2), new Actions.SetTile(TileID.HoneyBlock));
		    if (WorldGen.genRand.Next(0, 11) == 0)
		    {
			  WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(2, 2), new Actions.ClearTile());
			  int chestIndex = WorldGen.PlaceChest(x, y+1, style: 10);

			  if (chestIndex != -1)
			  {
				Chest chest = Main.chest[chestIndex];
				var itemsToAdd = new List<(int type, int stack)>();

				//int specialItem = new Terraria.Utilities.WeightedRandom<int>(
				//	Tuple.Create((int)ItemID.StingerNecklace, 1.0),
				//	Tuple.Create((int)ItemID.BeeCloak, 1.0),
				//	Tuple.Create((int)ItemID.HoneyBalloon, 1.0),
				//	Tuple.Create((int)ItemID.SweetheartNecklace, 1.0),
				//	Tuple.Create(ModContent.ItemType<Items.SweetStick>(), 1.0)
				//);
				//if (specialItem != ItemID.None)
				//{
				//    itemsToAdd.Add((specialItem, 1));
				//}
				//int hatItem = new Terraria.Utilities.WeightedRandom<int>(
				//	Tuple.Create((int)ItemID.GoldCrown, 1.0),
				//	Tuple.Create((int)ItemID.BeeHeadgear, 1.0),
				//	Tuple.Create((int)ItemID.FossilHelm, 1.0),
				//	Tuple.Create((int)ItemID.BeeHat, 1.0),
				//	Tuple.Create((int)ItemID.SummerHat, 1.0),
				//	Tuple.Create((int)ItemID.RainHat, 1.0)
				//);
				//if (hatItem != ItemID.None)
				//{
				//    itemsToAdd.Add((hatItem, 1));
				//}
				switch (Main.rand.Next(5))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.StingerNecklace, 1));
					  break;
				    case 1:
					  itemsToAdd.Add((ItemID.BeeCloak, 1));
					  break;
				    case 2:
					  itemsToAdd.Add((ItemID.HoneyBalloon, 1));
					  break;
				    case 3:
					  itemsToAdd.Add((ItemID.SweetheartNecklace, 1));
					  break;
				    case 4:
					  itemsToAdd.Add((ModContent.ItemType<Content.Items.SweetStick>(), 1));
					  break;
				}
				switch (Main.rand.Next(6))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.GoldCrown, 1));
					  break;
				    case 1:
					  itemsToAdd.Add((ItemID.BeeHeadgear, 1));
					  break;
				    case 2:
					  itemsToAdd.Add((ItemID.FossilHelm, 1));
					  break;
				    case 3:
					  itemsToAdd.Add((ItemID.BeeHat, 1));
					  break;
				    case 4:
					  itemsToAdd.Add((ItemID.SummerHat, 1));
					  break;
				    case 5:
					  itemsToAdd.Add((ItemID.RainHat, 1));
					  break;
				}

				switch (Main.rand.Next(9))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.ThornsPotion, Main.rand.Next(1, 3)));
					  break;
				    case 1:
					  itemsToAdd.Add((ItemID.IronskinPotion, Main.rand.Next(1, 3)));
					  break;
				    case 2:
					  itemsToAdd.Add((ItemID.TrapsightPotion, Main.rand.Next(1, 3)));
					  break;
				    case 3:
					  itemsToAdd.Add((ItemID.NightOwlPotion, Main.rand.Next(1, 3)));
					  break;
				    case 4:
					  itemsToAdd.Add((ItemID.SummoningPotion, Main.rand.Next(1, 3)));
					  break;
				    case 5:
					  itemsToAdd.Add((ItemID.HeartreachPotion, Main.rand.Next(1, 3)));
					  break;
				    case 6:
					  itemsToAdd.Add((ItemID.TeleportationPotion, Main.rand.Next(1, 3)));
					  break;
				    case 7:
					  itemsToAdd.Add((ItemID.ManaRegenerationPotion, Main.rand.Next(1, 3)));
					  break;
				    case 8:
					  itemsToAdd.Add((ItemID.FlipperPotion, Main.rand.Next(1, 3)));
					  break;
				}
				switch (Main.rand.Next(3))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.Topaz, Main.rand.Next(5, 16)));
					  break;
				}
				switch (Main.rand.Next(2))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.HoneyBlock, Main.rand.Next(25, 50)));
					  break;
				}
				switch (Main.rand.Next(6))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.HoneyfallBlock, Main.rand.Next(10, 21)));
					  break;
				}
				switch (Main.rand.Next(3))
				{
				    case 0:
				    case 1:
					  itemsToAdd.Add((ItemID.JestersArrow, Main.rand.Next(25, 51)));
					  break;
				}
				switch (Main.rand.Next(6))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.LogicSensor_Honey, Main.rand.Next(1, 4)));
					  break;
				}
				switch (Main.rand.Next(2))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.BottledHoney, Main.rand.Next(3, 6)));
					  break;
				}
				switch (Main.rand.Next(2))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.GoldBar, Main.rand.Next(3, 11)));
					  break;
				}
				switch (Main.rand.Next(2))
				{
				    case 0:
					  itemsToAdd.Add((ItemID.GoldCoin, Main.rand.Next(1, 4)));
					  break;
				}


				int chestItemIndex = 0;
				foreach (var itemToAdd in itemsToAdd)
				{
				    Item item = new Item();
				    item.SetDefaults(itemToAdd.type);
				    item.stack = itemToAdd.stack;
				    chest.item[chestItemIndex] = item;
				    chestItemIndex++;
				    if (chestItemIndex >= 40)
					  break;
				}
			  }
		    }
		    else
		    {
			  WorldUtils.Gen(new Point(x, y), new Shapes.Rectangle(2, 2), new Actions.PlaceWall(WallID.TopazGemspark));
		    }
		}
	  }
    }
}
