using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;
//using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace WorldGenTutorial
{
    class WorldGenTutorialWorld : ModPlayer
    {
	  public static bool JustPressed(Keys key)
	  {
		return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
	  }

	  public override void PostUpdate()
	  {
		if (JustPressed(Keys.Z))
		    TestMethod((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
		if (JustPressed(Keys.X))
		    TestMethod2((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
	  }

	  private void TestMethod(int x, int y)
	  {
		Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

		// Code to test placed here:
		WorldGen.digTunnel(x, y, 1, 0, 30, 2);
	  }
	  private void TestMethod2(int x, int y)
	  {
		Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

		// Code to test placed here:
		//WorldGen.TileRunner(x + xx, y + yy, 5, 5, TileID.Dirt, true);

		Point point = new Point(x, y);
		WorldUtils.Gen(point, new Shapes.Tail(5, new Vector2(WorldGen.genRand.Next(-10, 10), WorldGen.genRand.Next(15, 30))), new Actions.SetTile(TileID.Dirt));
	  }
    }
}