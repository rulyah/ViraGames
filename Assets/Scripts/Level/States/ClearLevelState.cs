using StateMachineTool;
using UnityEngine;

namespace Level.States
{
    public class ClearLevelState : State<LevelCore>
    {
        public ClearLevelState(LevelCore core) : base(core) { }

        public override void OnEnter()
        {
            //Remove processes
            while(core.model.processes.Count > 0)
            {
                var process = core.model.processes[0];
                process.Stop();
                core.model.processes.Remove(process);
            }

            core.factoryService.players.Release(core.model.playerView);

            while (core.model.roadViews.Count > 0)
            {
                var road = core.model.roadViews[0];
                core.model.roadViews.Remove(road);
                core.factoryService.roads.Release(road);
            }
            
            ChangeState(new MenuState(core));
        }
    }
}