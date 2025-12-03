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

            }
            GenerateRooms(Main.maxTilesX / 2, Main.maxTilesY / 2, 10);
            //Entrance ent2 = new Entrance { x = 400, y = 600, dir = true, remaining = 1 };
            //MakePillarRoom(new Entrance { x = 100, y = 400, dir = true, remaining = 1}, WorldGen.genRand.Next(30, 50), WorldGen.genRand.Next(100));
            //MakeTunnel(ent2, WorldGen.genRand.Next(10) / 10.0f * (ent2.dir ? 1 : -1), WorldGen.genRand.Next(10) / 5.0f - 1, WorldGen.genRand.Next(200), WorldGen.genRand.Next(5, 10));
            //MakeDomeRoom(new Entrance { x = 600, y = 400, dir = true, remaining = 1 }, WorldGen.genRand.Next(30, 100), WorldGen.genRand.Next(10, 30));
        }
        private void GenerateRooms(int startX, int startY, int length)
        {
            List<Entrance> entrances = new List<Entrance>() { new Entrance() { x = startX, y = startY, dir = true, remaining = length } };

            int rand;
            for (int i = 0; i < entrances.Count; i++)
            {
                Console.Write($"Entrance count: {entrances.Count}");
                if (entrances[i].remaining <= 0 || WorldGen.genRand.Next(length) - entrances[i].remaining > 0) continue;
                rand = WorldGen.genRand.Next(10);
                Console.Write($"({entrances[i].remaining},{rand}) ");
                if (rand >= 6) entrances.AddRange(MakePillarRoom(entrances[i], WorldGen.genRand.Next(30,40), WorldGen.genRand.Next(80,100)));
                else if (rand >= 3) entrances.AddRange(MakeTunnel(entrances[i], WorldGen.genRand.Next(10) / 10.0f * (entrances[i].dir ? 1 : -1), WorldGen.genRand.Next(10) / 5.0f - 1, WorldGen.genRand.Next(60), WorldGen.genRand.Next(5, 10)));
                else entrances.AddRange(MakeDomeRoom(entrances[i], WorldGen.genRand.Next(30, 40), WorldGen.genRand.Next(20, 25)));
                Console.WriteLine($"Entrance count now: {entrances.Count}");
            }
        }
        private List<Entrance> MakeDomeRoom(Entrance entrance, int width, int height)
        {
            Console.WriteLine($"Room starting at ({entrance.x},{entrance.y}) and going {entrance.dir}. Size: [{width},{height}]");
            List<Entrance> exits = new List<Entrance>();
            exits.Add(new Entrance() { x = entrance.x, y = entrance.y, dir = true, remaining = entrance.remaining - 1 });
            float ceiling_height = 0;
            //Console.WriteLine($" x:{x}, y:{y}, room_width:{width}, max_ceil:{height} ");
            for (int w = 0; w < width; w++)
            {
                ceiling_height = (float)Math.Sin((float)w / width * Math.PI) * height;
                for (int h = 0; h < ceiling_height; h++)
                {
                    Tile tile = Main.tile[entrance.x + (entrance.dir ? w : -w), entrance.y - h];
                    tile.HasTile = false;
                    //tile.TileType = TileID.LivingFire;
                }
            }
            return exits;
        }

        private List<Entrance> MakePillarRoom(Entrance entrance, int width, int height)
        {
            Console.WriteLine($"Pillar starting at ({entrance.x},{entrance.y}) and going {entrance.dir}. Size: [{width},{height}]");
            List<Entrance> exits = new List<Entrance>();

            int exits_spacing = 70;

            if (entrance.x > Main.maxTilesX - 40 - width || entrance.y > Main.maxTilesY - 40 - height || entrance.x < 40 + width || entrance.y < 40 + height)
            {
                return exits;
            }

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    Tile tile = Main.tile[entrance.x + (entrance.dir ? w : -w), entrance.y - h];
                    tile.HasTile = false;
                }
            }

            for (int i = 0; i < height / exits_spacing; i++)
            {
                exits.Add(new Entrance() { x = entrance.x + (entrance.dir ? width : -width), y = entrance.y + i * exits_spacing, dir = entrance.dir, remaining = entrance.remaining - 1 });
                exits.Add(new Entrance() { x = entrance.x, y = entrance.y + i * exits_spacing, dir = !entrance.dir, remaining = entrance.remaining - 1 });
            }

            return exits;
        }
        private List<Entrance> MakeTunnel(Entrance entrance, float xDir, float yDir, int steps, float size)
        {
            int endX = entrance.x + (int)(xDir * steps);
            int endY = entrance.y + (int)(yDir * steps);
            Console.WriteLine($"Line from ({entrance.x},{entrance.y}) to ({endX},{endY})");
            if (endX < size + 30 || endX > Main.maxTilesX - size - 30 || endY < size + 30 || endY > Main.maxTilesY - size - 30)
                return new List<Entrance>() { /*new Entrance() { x = x, y = y, dir = xDir >= 0 }*/ };

            MakeCircle(entrance.x, entrance.y, size);

            MakeLine(entrance.x, entrance.y, endX, endY);

            MakeCircle(endX, endY, size);
            return new List<Entrance>() { new Entrance() { x = endX, y = endY, dir = xDir >= 0, remaining = entrance.remaining - 1 } };
        }

        private void MakeCircle(int x, int y, float size, int? tileId = null)
        {
            for (int i = -(int)size; i < size; i++)
            {
                for (int j = -(int)size; j < size; j++)
                {
                    if (i * i + j * j < size * size)
                    {
                        if (tileId == null)
                        {
                            Tile t = Main.tile[x + i, y - j];
                            t.HasTile = false;
                        }
                        else
                        {
                            Tile t = Main.tile[x + i, y - j];
                            t.HasTile = true;
                            t.TileType = (ushort)tileId;
                        }
                    }
                }
            }
        }
        private void MakeLine(int x1, int y1, int x2, int y2, int? tileId = null)
        {
            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }
            if (y1 > y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
            }
            for (int w = x1; w < x2; w++)
            {
                int h = (w - x1) * (y2 - y1) / (x2 - x1) + y1;
                if (tileId == null)
                {
                    Tile t = Main.tile[w, h];
                    t.HasTile = false;
                }
                else
                {
                    Tile t = Main.tile[w, h];
                    t.HasTile = true;
                    t.TileType = (ushort)tileId;
                }
            }
        }
    }
}
