using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;
using Microsoft.Xna.Framework;

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
		    int X = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
		    int Y = Math.Abs(WorldGen.genRand.Next(50, 50));//(int)Main.worldSurface * 0.35f)); //(int)WorldGen.worldSurface

		    int radius = 15;
		    for (int x = X - radius; x <= X + radius; x++)
			  for (int y = Y - radius; y <= Y + radius; y++)
				if (Vector2.Distance(new Vector2(X, Y), new Vector2(x, y)) <= radius)
				    WorldGen.PlaceTile(X, Y, TileID.Dirt, false, true);
		    
		    //WorldGen.TileRunner(x, y, 10, 3, TileID.TopazGemspark, true);
		}
		//int X = Main.spawnTileX;
		//int Y = Main.spawnTileY - 50;

	  }
    }
}
