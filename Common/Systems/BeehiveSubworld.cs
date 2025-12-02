using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeStation.Common.Systems.GenPasses.BeehiveSubworld;
using SubworldLibrary;
using Terraria.WorldBuilding;

namespace BeeStation.Common.Systems
{
    class BeehiveSubworld : Subworld
    {
        public override int Width => 840;
        public override int Height => 840;
        public override bool ShouldSave => false;
        public override bool NoPlayerSaving => true;
        public override List<GenPass> Tasks => new List<GenPass>()
        {
            new BeehiveGroundGenPass("Ground", 1f),
            new BeehiveCaveRoomGenPass("Caves", 3f)
        };
        public override void OnEnter()
        {
        }
        
    }
}
