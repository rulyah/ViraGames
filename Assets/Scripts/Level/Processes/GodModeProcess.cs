using Level.Views;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class GodModeProcess : Process
    {
        private readonly LevelCore _core;

        private RoadView _nextRoad;
        
        public GodModeProcess(LevelCore core) : base(core)
        {
            _core = core;
            _nextRoad = core.model.roadViews[0];
        }

        protected override void OnUpdate()
        {
            var playerPos = new Vector3(_core.model.playerView.transform.position.x,
                0.0f,
                _core.model.playerView.transform.position.z);
            
            var nextRoadPos = new Vector3(_nextRoad.transform.position.x,
                0.0f,
                _nextRoad.transform.position.z);
            
            float distance = Vector3.Distance(playerPos, nextRoadPos);

            var direction = Vector3.Normalize(nextRoadPos - playerPos);

            if (direction.z > direction.x)
                direction = new Vector3(-direction.z, 0.0f, 0.0f);
            
            _core.model.playerView.SetDirection(direction);
            
            if (distance < 0.1f)
                _nextRoad = GetNextRoad(_nextRoad);
        }

        private RoadView GetNextRoad(RoadView currRoad)
        {
            int currIndex = _core.model.roadViews.IndexOf(currRoad);
            currIndex++;
            return _core.model.roadViews[currIndex];
        }
    }
}