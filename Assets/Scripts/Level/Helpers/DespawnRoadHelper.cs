using Level.Views;

namespace Level.Helpers
{
    public static class DespawnRoadHelper
    {
        public static void Execute(LevelCore core, RoadView roadView)
        {
            core.model.roadViews.Remove(roadView);
            core.factoryService.roads.Release(roadView);
        }
    }
}