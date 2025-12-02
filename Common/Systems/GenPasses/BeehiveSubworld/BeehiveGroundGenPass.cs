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
    internal class BeehiveGroundGenPass : GenPass
    {
        public BeehiveGroundGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Setting some ground rules";
            Main.worldSurface = Main.maxTilesY - 42;
            Main.rockLayer = Main.maxTilesY;

            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY));
                    if (Math.Pow(i - Main.maxTilesX / 2, 4) + Math.Pow(Main.maxTilesX / Main.maxTilesY * j - Main.maxTilesX / 2, 4) < Math.Pow(Main.maxTilesX, 4) / 16)
                    {
                        Tile tile = Main.tile[i, j];
                        tile.HasTile = true;
                        tile.TileType = TileID.Mud;
                    }
                }
            }
        }
    }
}
