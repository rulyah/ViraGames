using Level.Processes;
using StateMachineTool;

namespace Level.States
{
    public class GameplayState : State<LevelCore>
    {
        public GameplayState(LevelCore core) : base(core) { }
        
        public override void OnEnter()
        {
            core.gameScreen.Show();
            core.gameScreen.onPauseClick += OnPauseClick;

            core.model.processes.Add(core.model.isGodModeOn
                ? new GodModeProcess(core).Start()
                : new PlayerInputProcess(core).Start());

            core.model.processes.Add(new LevelGenerationProcess(core).Start());
            core.model.playerView.onDeath += PlayerOnDeath;
        }
        
        public override void OnExit()
        {
            core.gameScreen.onPauseClick -= OnPauseClick;
            core.model.playerView.onDeath -= PlayerOnDeath;
            core.gameScreen.Hide();
        }

        private void OnPauseClick()
        {
            ChangeState(new PauseState(core));
        }
        
        private void PlayerOnDeath()
        {
            ChangeState(new LossState(core));
        }
    }
}