using Utils.ProcessTool;

namespace Level.Processes
{
    public class PlayerInputProcess : Process
    {
        private readonly LevelCore _core;
        
        public PlayerInputProcess(LevelCore core) : base(core)
        {
            _core = core;
        }

        protected override void OnUpdate()
        {
            var inputAxis = _core.inputService.activeSource.GetMoveAxis();

            if (inputAxis.magnitude < 0.01f)
                return;
            
            _core.model.playerView.SetDirection(inputAxis);
        }
    }
}