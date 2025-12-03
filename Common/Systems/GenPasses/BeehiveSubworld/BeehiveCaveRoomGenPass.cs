using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace BeeStation.Common.Systems.GenPasses.BeehiveSubworld
{
    struct Entrance
    {
        public int x;
        public int y;
        public bool dir;
        public int remaining;
    }
    internal class BeehiveCaveRoomGenPass : GenPass
    {
        public BeehiveCaveRoomGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Carving out cheese holes";

            int holes = Main.maxTilesX * Main.maxTilesY / 10000;

            for (int w = 0; w < Main.maxTilesX; w+=50)
            {
                for (int h = 0; h < Main.maxTilesY; h+=50)
                {
                    progress.Set((w * Main.maxTilesY + h) / holes);
                    WorldGen.digTunnel(w + WorldGen.genRand.Next(50), h + WorldGen.genRand.Next(50) + (w%2)*25, WorldGen.genRand.Next(2) * 2 - 1, (WorldGen.genRand.Next(101) / 50 - 1) * 0.2, WorldGen.genRand.Next(40, 50), WorldGen.genRand.Next(5, 12));
                }
            }
            for (int i = 0; i < holes / 100; i++)
            {
                WorldGen.digTunnel(WorldGen.genRand.Next(Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY), (WorldGen.genRand.Next(2) * 2 - 1) * 0.3, WorldGen.genRand.Next(2) * 2 - 1, WorldGen.genRand.Next(1000, 1500), WorldGen.genRand.Next(20, 30));
            }
        }
    }
}
