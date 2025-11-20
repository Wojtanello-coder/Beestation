using System;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using BeeStation.Common.Systems.GenPasses;

namespace BeeStation.Common.Systems
{
    class WorldSystem : ModSystem
    {
	  public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	  {
		int ShiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
		if(ShiniesIndex != -1)
		{
		    tasks.Insert(ShiniesIndex + 1, new SpaceHiveGenPass("Space Hive", 320f));
		}
	  }
    }
}
