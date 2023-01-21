using StateMachineTool;
using UnityEngine;

namespace Level.States
{
    public class PauseState : State<LevelCore>
    {
        public PauseState(LevelCore core) : base(core) { }

        public override void OnEnter()
        {
            Time.timeScale = 0.0f;
            core.pauseScreen.Show();
            core.pauseScreen.onMenuClick += OnMenuClick;
            core.pauseScreen.onContinueClick += OnContinueClick;
        }

        private void OnContinueClick()
        {
            ChangeState(new GameplayState(core));
        }

        private void OnMenuClick()
        {
            ChangeState(new ClearLevelState(core));
        }

        public override void OnExit()
        {
            Time.timeScale = 1.0f;
            core.pauseScreen.onMenuClick -= OnMenuClick;
            core.pauseScreen.onContinueClick -= OnContinueClick;
            core.pauseScreen.Hide();
        }
    }
}