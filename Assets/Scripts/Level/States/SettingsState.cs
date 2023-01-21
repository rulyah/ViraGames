using StateMachineTool;

namespace Level.States
{
    public class SettingsState : State<LevelCore>
    {
        public SettingsState(LevelCore core) : base(core) { }

        public override void OnEnter()
        {
            core.settingsScreen.Show();
            core.settingsScreen.SetGodMode(core.model.isGodModeOn);
            core.settingsScreen.onClose += OnSettingsClose;
            core.settingsScreen.onGodModeClick += OnGodModeClick;
        }

        private void OnGodModeClick()
        {
            core.model.isGodModeOn = !core.model.isGodModeOn;
            core.settingsScreen.SetGodMode(core.model.isGodModeOn);
        }

        public override void OnExit()
        {
            core.settingsScreen.onGodModeClick -= OnGodModeClick;
            core.settingsScreen.onClose -= OnSettingsClose;
            core.settingsScreen.Hide();
        }

        private void OnSettingsClose()
        {
            ChangeState(new MenuState(core));
        }
    }
}