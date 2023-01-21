using StateMachineTool;

namespace Level.States
{
    public class PrepareGameState : State<LevelCore>
    {
        public PrepareGameState(LevelCore core) : base(core) { }

        public override void OnEnter()
        {
            core.model.levelCameraView = core.factoryService.cameras.Produce();
            ChangeState(new MenuState(core));
        }
    }
}