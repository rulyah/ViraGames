using Level.States;
using Screens;
using Services.Factory;
using Services.UserInput;
using StateMachineTool;
using UI;
using UnityEngine;
using Utils.ProcessTool;

namespace Level
{
    public class LevelCore : MonoBehaviour, ICoroutineRunner
    {
        [Header("Services")] 
        public FactoryService factoryService;
        public InputService inputService;

        [Header("Screens")] 
        public GameScreen gameScreen;
        public LossScreen lossScreen;
        public MenuScreen menuScreen;
        public PauseScreen pauseScreen;
        public SettingsScreen settingsScreen;
        
        
        [Space] 
        public LevelConfig config;
        public LevelModel model { get; private set; }

        private StateMachine<LevelCore> _stateMachine;

        private void Start()
        {
            model = new LevelModel();
            _stateMachine = new StateMachine<LevelCore>(new PrepareGameState(this));
        }
    }
}
