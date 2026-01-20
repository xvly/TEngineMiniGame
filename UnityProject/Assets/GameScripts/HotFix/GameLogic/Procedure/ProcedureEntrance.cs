using System;
using TEngine;

namespace GameLogic
{
    public class ProcedureEntrance: ProcedureBase
    {
        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            
            Log.Info("进入游戏入口流程");
            
            procedureOwner.SetData("NextProcedure", typeof(ProcedureHome));
            procedureOwner.SetData<string>("NextSceneName", "scene_home");
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }
}