using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace BeeStation.Content.Enemies
{
    public class QuickBee : ModNPC
    {
	  public override void SetStaticDefaults()
	  {
		// DisplayName.SetDefault("Quick Bee");
		Main.npcFrameCount[NPC.type] = Main.npcFrameCount[4];
	  }

	  public override void SetDefaults()
	  {
		NPC.width = 16;
		NPC.height = 16;
		NPC.damage = 20;
		NPC.defense = 10;
		NPC.lifeMax = 20;
		NPC.value = 0f;
		NPC.knockBackResist = 0.5f;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.noGravity = true;
		//AIType = NPCID.Bee; //NPCID.Bee;
		AnimationType = NPCID.Bee;
	  }
	  //public override float SpawnChance(NPCSpawnInfo spawnInfo)
	  //{

	  //}
	  //public override void ModifyNPCLoot(NPCLoot npcLoot)
	  //{

	  //}
	  //public override void OnHitPlayer(Player target, int damage, bool crit)
	  //{


	  //}
	  //public override void OnKill()
	  //{

	  //}
	  public override float SpawnChance(NPCSpawnInfo spawnInfo)
	  {
		if (spawnInfo.Player.ZoneHive)
		{
		    return 1f;
		}
		return 0f;
		
	  }
	  public override void OnSpawn(IEntitySource source)
	  {
		NPC.ai[0] = NPC.Center.X; // Previous frame X
		NPC.ai[1] = 0; // Timer of frames with same X
		NPC.ai[2] = 0; // 0- Chasing State,  1- Backing State
		NPC.ai[3] = 0; // Timer for Backing State
	  }
	  public override void AI()
	  {
		
		Vector2 targetPos = Main.player[NPC.FindClosestPlayer()].Center;
		float targetDist = Main.player[NPC.FindClosestPlayer()].Distance(NPC.position) / 16;

		//stuck in Y timer
		if(NPC.ai[0] == NPC.Center.X)
		{
		    NPC.ai[1]++;
		}
		else
		{
		    NPC.ai[1] = 0;
		}
		if(NPC.ai[1] >= 100)
		{
		    NPC.ai[1] = 0;
		    NPC.ai[2] = 1;
		    NPC.ai[3] = 100;
		}

		//Backing State
		if(NPC.ai[3] > 0)
		{
		    NPC.ai[3]--;
		}
		if(NPC.ai[3] <= 0)
		{
		    NPC.ai[2] = 0;
		    NPC.ai[3] = 0;
		}


		//Velocity
		if ((targetPos.X > NPC.Center.X && NPC.ai[2]==0 || targetPos.X < NPC.Center.X && NPC.ai[2] == 1) && NPC.velocity.X < 6f)
		{
		    NPC.velocity.X += 0.2f;
		}
		if ((targetPos.X < NPC.Center.X && NPC.ai[2]==0 || targetPos.X > NPC.Center.X && NPC.ai[2] == 1) && NPC.velocity.X > -6f)
		{
		    NPC.velocity.X -= 0.2f;
		}
		if (targetPos.Y > NPC.Center.Y && NPC.velocity.Y < 6f)
		{
		    NPC.velocity.Y += 0.2f;
		}
		if (targetPos.Y < NPC.Center.Y && NPC.velocity.Y > -6f)
		{
		    NPC.velocity.Y -= 0.2f;
		}

		if(targetDist < 8)
		{
		    if(NPC.velocity.X > 0)
		    {
			  NPC.velocity.X = 10f;
		    }
		    else
		    {
			  NPC.velocity.X = -10f;
		    }
		}


		NPC.ai[0] = NPC.Center.X;
	  }
    }
}