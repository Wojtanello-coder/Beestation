using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeeStation.Content.Enemies
{
    internal class StellarBeeGuardian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
        }
        public override void SetDefaults()
        {

            NPC.width = 32;
            NPC.height = 48;
            NPC.damage = 20;
            NPC.defense = 10;
            NPC.lifeMax = 20;
            NPC.value = 2850f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return 1f;

        }
        public override void OnSpawn(IEntitySource source)
        {
            NPC.ai[0] = 0; // Summon Cooldown
            NPC.ai[1] = 0; // Summon Count
            NPC.ai[2] = 0; 
            NPC.ai[3] = 0;
        }
        public override void AI()
        {
            if (Main.player[NPC.FindClosestPlayer()].Distance(NPC.Center) < 320f && NPC.ai[0] <= 0 && NPC.ai[1] < 7) {
                NPC.ai[0] = 360 * (float)Math.PI / 7;
                NPC.ai[1]++;
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<StellarBee>(), 0, NPC.whoAmI);
            }
            if (NPC.ai[0] > 0) NPC.ai[0]--;
        }

    }
}
