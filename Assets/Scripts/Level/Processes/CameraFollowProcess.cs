using Level.Views;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.Processes
{
    public class CameraFollowProcess : Process
    {
        private readonly LevelConfig _config;
        private readonly PlayerView _player;
        private readonly LevelCameraView _camera;
     
        public CameraFollowProcess(LevelCore core) : base(core)
        {
            _config = core.config;
            _player = core.model.playerView;
            _camera = core.model.levelCameraView;
        }

        protected override void OnUpdate()
        {
            Vector3 offsetDirection = _config.cameraOffsetDirection.normalized;
            
            var position = _player.transform.position + 
                           offsetDirection * _config.cameraOffsetDistance;

            _camera.transform.position = position;
            _camera.transform.forward = offsetDirection * -1;
        }
    }
}