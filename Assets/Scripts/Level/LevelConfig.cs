using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public int minRoadLength = 3;
        public int maxRoadLength = 6;

        public float roadWidth = 2.0f;
        
        public float playerMinSpeed = 5.0f;

        public int roadsCountAtStart = 50;
        public int roadGenerationRadius = 10;
        public float cameraOffsetDistance = 10.0f;
        public Vector3 cameraOffsetDirection = new (-1.0f, -1.0f, -1.0f);
    }
}