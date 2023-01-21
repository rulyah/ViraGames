using UnityEngine;

namespace Level.Helpers
{
    public static class SpawnRoadHelper
    {
        public static void Execute(LevelCore core, int x, int z)
        {
            var road = core.factoryService.roads.Produce();
            road.transform.position = new Vector3(x, 0.0f, z);
            core.model.roadViews.Add(road);
        }
    }
}