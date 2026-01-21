using TEngine;

namespace GameLogic
{
    public class ProcedureHome: Procedure.ProcedureBase
    {
        public override bool UseNativeDialog { get; }
        
        private IFsm<IProcedureModule> _procedureOwner; 
        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            base.OnEnter(procedureOwner);

            _procedureOwner = procedureOwner;
            
            Log.Info("进入主界面流程 1");
            
            GameModule.UI.ShowUIAsync<UIHome>();

            AddEventListener(EventHome.EnterBattle, EnterBattle);
        }
        
        protected override void OnLeave(IFsm<IProcedureModule> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            
            GameModule.UI.CloseUI<UIHome>();
        }

        public void EnterBattle()
        {
            _procedureOwner.SetData("NextProcedure", typeof(ProcedureBattle));
            _procedureOwner.SetData("NextSceneName", "scene_battle");
            ChangeState<ProcedureChangeScene>(_procedureOwner);
        }
    }
}