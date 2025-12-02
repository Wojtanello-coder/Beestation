using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace BeeStation.Common.Systems.GenPasses.BeehiveSubworld
{
    struct Entrance
    {
        public int x;
        public int y;
        public bool dir;
    }
    internal class BeehiveCaveRoomGenPass : GenPass
    {
        public BeehiveCaveRoomGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Carving out cheese holes";

            int holes = Main.maxTilesX * Main.maxTilesY / 10000;

            int max_ceiling_height;
            int room_width;
            int x, y;
            
            //Console.WriteLine($"Amount of holes: {holes}");
            for (int i = 0; i < holes; i++)
            {
                progress.Set(i / holes);

                max_ceiling_height = WorldGen.genRand.Next(20, 30);
                room_width = WorldGen.genRand.Next(50, 100);

                x = WorldGen.genRand.Next(50 + room_width, Main.maxTilesX - 50 - room_width);
                y = WorldGen.genRand.Next(60 + (int)max_ceiling_height, Main.maxTilesY - 60);

                MakeDomeRoom(x, y, room_width, max_ceiling_height);
            }
        }
        private List<Entrance> MakeDomeRoom(int x, int y, int width, int height, bool dir = true)
        {
            List<Entrance> exits = new List<Entrance>();
            exits.Add(new Entrance() { x = x, y = y, dir = true });
            float ceiling_height = 0;
            //Console.WriteLine($" x:{x}, y:{y}, room_width:{width}, max_ceil:{height} ");
            for (int w = 0; w < width; w++)
            {
                ceiling_height = (float)Math.Sin((float)w / width * Math.PI) * height;
                for (int h = 0; h < ceiling_height; h++)
                {
                    Tile tile = Main.tile[x+(dir ? w:-w), y-h];
                    tile.HasTile = false;
                    //tile.TileType = TileID.LivingFire;
                }
            }
            return exits;
        }

        private List<Entrance> MakePillarRoom(int x, int y, int width, int height, bool dir = true)
        {
            List<Entrance> exits = new List<Entrance>();




            return exits;
        }
        private List<Entrance> MakeTunnel(int x, int y, float xDir, float yDir, int steps, float size)
        {
            int endX = x + (int)(xDir * steps);
            int endY = y + (int)(yDir * steps);
            if (endX < size + 30 || endX > Main.maxTilesX - size - 30 || endY < size + 30 || endY > Main.maxTilesY - size - 30)
                return new List<Entrance>() { new Entrance() { x = x, y = y, dir = xDir >= 0 } };

            //circle1
            //2 lines
            //circle2
            return new List<Entrance>() { new Entrance() { x = x, y = y, dir = xDir >= 0 } };
        }
    }
}
