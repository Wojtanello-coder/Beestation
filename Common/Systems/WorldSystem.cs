using BeeStation.Common.Systems.GenPasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace BeeStation.Common.Systems
{
    class WorldSystem : ModSystem
    {
        public string[] zodiacs = { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces" };
        public static int zodiacSign;
	  public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
	  {
		int ShiniesIndex = tasks.FindIndex(t => t.Name.Equals("Shinies"));
		if(ShiniesIndex != -1)
		{
		    tasks.Insert(ShiniesIndex + 1, new SpaceHiveGenPass("Space Hive", 320f));
		}
	  }
        public override void PreWorldGen()
        {
            Console.Write($"[PWG] Previous sign was {zodiacSign}. ");
            zodiacSign = new Random((int)DateTime.Now.Ticks).Next(12);
            Console.WriteLine($"Current is {zodiacSign}.");

        }
        //public override void OnWorldLoad()
        //{
        //    Console.Write($"[OWL] Previous sign was {zodiacSign}. ");
        //    zodiacSign = new Random((int)DateTime.Now.Ticks).Next(12);
        //    Console.WriteLine($"Current is {zodiacSign}.");
        //}
        public override void LoadWorldData(TagCompound tag)
        {
            Console.Write($"[LWD] Previous sign was {zodiacSign}. ");
            if (tag.ContainsKey("ZodiacSign"))
            {
                zodiacSign = tag.GetInt("ZodiacSign");
            }
            else
            {
                zodiacSign = new Random((int)DateTime.Now.Ticks).Next(12);
            }
            Console.WriteLine($"Current is {zodiacSign}.");
        }

        public override void SaveWorldData(TagCompound tag)
        {
            Console.WriteLine($"[SWD] Saving {zodiacSign}. ");
            tag["ZodiacSign"] = zodiacSign;
        }
        public override void SaveWorldHeader(TagCompound tag)
        {
            Console.WriteLine($"[SWH] Saving {zodiacSign}. ");
            tag["ZodiacSign"] = zodiacSign;
        }
    }
}
