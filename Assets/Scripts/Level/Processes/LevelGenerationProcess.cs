using Level.Helpers;
using Level.Views;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class LevelGenerationProcess : Process
    {
        private readonly LevelCore _core;

        public LevelGenerationProcess(LevelCore core) : base(core)
        {
            _core = core;
        }

        protected override void OnUpdate()
        {
            var player = _core.model.playerView;
            
            for (int i = 0; i < _core.model.roadViews.Count; i++)
            {
                RoadView road = _core.model.roadViews[i];
                float distance = CalculateRoadDistanceToPlayer(road, player);

                if (road.transform.position.z > player.transform.position.z)
                    continue;
                
                if (distance > _core.config.roadGenerationRadius * 2)
                    ReuseRoad(road);
            }
        }

        private float CalculateRoadDistanceToPlayer(RoadView road, PlayerView player)
        {
            return Vector3.Distance(road.transform.position, 
                player.transform.position);
        }
        
        private void ReuseRoad(RoadView road)
        {
            DespawnRoadHelper.Execute(_core, road);
            CalculateNextRoadPosHelper.Execute(_core, out int x, out int z);
            SpawnRoadHelper.Execute(_core, x, z);
        }
    }
}