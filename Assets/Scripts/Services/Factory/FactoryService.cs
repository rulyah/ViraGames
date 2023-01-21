using Level.Views;
using UnityEngine;
using Utils.FactoryTool;

namespace Services.Factory
{
    public class FactoryService : MonoBehaviour
    {
        [SerializeField] private LevelCameraView _levelCameraPrefab;
        [SerializeField] private PlayerView _playerPrefab;
        [SerializeField] private RoadView _roadPrefab;
        [SerializeField] private CrystalView _crystalPrefab;

        
        public Factory<LevelCameraView> cameras { get; private set; }
        public Factory<PlayerView> players { get; private set; }
        public Factory<RoadView> roads { get; private set; }
        public Factory<CrystalView> crystals { get; private set; }


        private void Awake()
        {
            cameras = new Factory<LevelCameraView>(_levelCameraPrefab, 1);
            players = new Factory<PlayerView>(_playerPrefab, 1);
            roads = new Factory<RoadView>(_roadPrefab, 50);
            //crystals = new Factory<CrystalView>(_crystalPrefab, 20);
        }

        private void OnDestroy()
        {
            cameras.Dispose();
            players.Dispose();
            roads.Dispose();
            //crystals.Dispose();
        }
    }
}