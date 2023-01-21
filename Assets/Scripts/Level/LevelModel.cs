using System.Collections.Generic;
using Level.Views;
using Utils.ProcessTool;

namespace Level
{
    public class LevelModel
    {
        public PlayerView playerView;
        public LevelCameraView levelCameraView;
        public List<RoadView> roadViews;
        public List<CrystalView> crystalViews;
        public List<Process> processes;
        public bool isGodModeOn;
    }
}