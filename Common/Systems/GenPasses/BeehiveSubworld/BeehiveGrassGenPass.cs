using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace BeeStation.Common.Systems.GenPasses.BeehiveSubworld
{
    internal class BeehiveGrassGenPass : GenPass
    {
        public BeehiveGrassGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Trying some moss alternative";

            for (int w = 1; w < Main.maxTilesX-1; w++)
            {
                for (int h = 1; h < Main.maxTilesY-1; h++)
                {
                    if (Main.tile[w,h].TileType == TileID.Mud && (!Main.tile[w-1, h-1].HasTile || !Main.tile[w-1, h].HasTile || !Main.tile[w-1, h+1].HasTile || !Main.tile[w, h-1].HasTile ||
                                                                  !Main.tile[w, h+1].HasTile || !Main.tile[w+1, h-1].HasTile || !Main.tile[w+1, h].HasTile || !Main.tile[w+1, h+1].HasTile))
                    {
                        Main.tile[w, h].TileType = TileID.JungleGrass;
                    }
                }
            }
        }
    }
}
