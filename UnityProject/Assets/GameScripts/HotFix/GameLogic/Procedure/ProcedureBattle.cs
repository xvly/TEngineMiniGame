using TEngine;

namespace GameLogic
{
    public class ProcedureBattle: ProcedureBase
    {
        private IFsm<IProcedureModule> _procedureOwner; 
        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            _procedureOwner = procedureOwner;
            
            Log.Info("进入战斗流程");
            
            // GameModule.UI.ShowUI<UIHome>();
        }
        
       

        // public void EnterBattle()
        // {
        //     _procedureOwner.SetData("NextProcedure", typeof(ProcedureHome));
        //     ChangeState<ProcedureChangeScene>(_procedureOwner);
        // }
    }
}