using UnityEngine;

namespace Level.Helpers
{
    public static class CalculateNextRoadPosHelper
    {
        public static void Execute(LevelCore core, out int x, out int z)
        {
            var prevRoad = core.model.roadViews[^1];
            x = Mathf.RoundToInt(prevRoad.transform.position.x);
            z = Mathf.RoundToInt(prevRoad.transform.position.z);

            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                x++;
            }
            else
            {
                z++;
            }
        }
    }
}