using System.Collections.Generic;
using Level.Helpers;
using Level.Processes;
using Level.Views;
using StateMachineTool;
using UnityEngine;
using Utils.ProcessTool;

namespace Level.States
{
    public class PrepareLevelState : State<LevelCore>
    {
        public PrepareLevelState(LevelCore core) : base(core) { }

        public override void OnEnter()
        {
            core.model.processes ??= new List<Process>();
            
            core.model.playerView = core.factoryService.players.Produce();
            core.model.playerView.transform.position = new Vector3(0, 0.15f, 0);
            core.model.playerView.SetPlayerSpeed(core.config.playerMinSpeed);
            
            core.model.roadViews ??= new List<RoadView>(core.config.roadsCountAtStart);
            core.model.roadViews.Clear();

            core.model.crystalViews ??= new List<CrystalView>(20);
            core.model.crystalViews.Clear();
            
            core.model.processes.Add(new CameraFollowProcess(core).Start());

            
            SpawnRoadHelper.Execute(core, 0, 0);
            
            for (int i = 0; i < core.config.roadsCountAtStart; i++)
            {
                CalculateNextRoadPosHelper.Execute(core, out int x, out int z);
                SpawnRoadHelper.Execute(core, x, z);
            }

            ChangeState(new GameplayState(core));
        }
    }
}