using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using System;
using Microsoft.Xna.Framework;

namespace BeeStation.Content.Enemies
{
    public class HoneySlime : ModNPC
    {
	  public override void SetStaticDefaults()
	  {
		// DisplayName.SetDefault("Honey Slime");
		Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
	  }

	  public override void SetDefaults()
	  {
		NPC.width = 32;
		NPC.height = 20;
		NPC.damage = 12;
		NPC.defense = 3;
		NPC.lifeMax = 80;
		NPC.value = 700f;
		NPC.aiStyle = NPCAIStyleID.Slime;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		AIType = NPCID.BlueSlime;
		AnimationType = NPCID.BlueSlime;
	  }
	  public override float SpawnChance(NPCSpawnInfo spawnInfo)
	  {
		return SpawnCondition.UndergroundJungle.Chance * 1f;
	  }
	  public override void ModifyNPCLoot(NPCLoot npcLoot)
	  {
		//npcLoot.Add(ItemDropRule.Common(ItemID.HoneyBlock, 1, 1, 2));
	  }
	  public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
	  {
		target.AddBuff(BuffID.Regeneration, 300);
		//WorldGen.BroadcastText(NetworkText.FromLiteral("Hello player!"), Color.Green);
	  }
	  public override void OnKill()
	  {
		//WorldGen.BroadcastText(NetworkText.FromLiteral(NPC.position.X.ToString() + ", " + NPC.position.Y.ToString()), Color.Red);
		WorldGen.PlaceLiquid((int)NPC.Center.X / 16 + 1, ((int)NPC.position.Y + 8) / 16, (byte)LiquidID.Honey, 255);
		//WorldGen.PlaceTile(((int)NPC.position.X + 8) / 16, (int)NPC.position.Y / 16, TileID.Dirt, false, true);
	  }
    }
}