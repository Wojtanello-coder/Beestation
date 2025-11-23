using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BeeStation.Content.Enemies
{
    internal class StellarBee : ModNPC
    {
        public NPC FollowingNPC => Main.npc[(int)NPC.ai[0]];
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }
        public override void SetDefaults()
        {

            NPC.width = 32;
            NPC.height = 32;
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.lifeMax = 100;
            NPC.value = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
        }
        public override void OnSpawn(IEntitySource source)
        {
            NPC.ai[0] = 400; // Floating distance
            NPC.ai[1] = 0; 
            NPC.ai[2] = 0;
            NPC.ai[3] = 0;
        }
        public override void AI()
        {
            const float maxSpeed = 10f;
            if (FollowingNPC.life <= 0)
            {
                NPC.StrikeInstantKill();
            }
            else
            {
                Microsoft.Xna.Framework.Vector2 following = FollowingNPC.Center;

                NPC.rotation += 1f / 60;
                following.X += (float)Math.Sin(NPC.rotation) * NPC.ai[0];
                following.Y -= (float)Math.Cos(NPC.rotation) * NPC.ai[0];
                if (NPC.Center.X > following.X) NPC.velocity.X += (following.X - NPC.Center.X) / 10;
                if (NPC.Center.X < following.X) NPC.velocity.X += (following.X - NPC.Center.X) / 10;
                if (NPC.Center.Y > following.Y) NPC.velocity.Y += (following.Y - NPC.Center.Y) / 10;
                if (NPC.Center.Y < following.Y) NPC.velocity.Y += (following.Y - NPC.Center.Y) / 10;
                if (Math.Abs(NPC.velocity.Length()) > maxSpeed) {
                    NPC.velocity.Normalize();
                    NPC.velocity *= maxSpeed;
                }
            }
        }
    }
}
