using System;
using Cysharp.Threading.Tasks;
using TEngine;

namespace GameLogic
{
    public class ProcedureChangeScene: ProcedureBase
    {
        private int _count = 50;
        
        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            
            GameModule.UI.ShowUIAsync<UILoading>();

            var nextSceneName = procedureOwner.GetData<string>("NextSceneName");

            Log.Info("切换场景到:" + nextSceneName);
            _count = 100;
            
            LoadSceneAsync(nextSceneName).Forget();
        }
        
        async UniTaskVoid LoadSceneAsync(string sceneName)
        {
            await GameModule.Scene.LoadSceneAsync(sceneName);
        }

        protected override void OnUpdate(IFsm<IProcedureModule> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            _count--;
            // Log.Info("切换场景等待中..." + _count);

            if (_count <= 0)
            {
                var procedureType = procedureOwner.GetData<Type>("NextProcedure");
                ChangeState( procedureOwner, procedureType);
            }
        }

        protected override void OnLeave(IFsm<IProcedureModule> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            
            GameModule.UI.CloseUI<UILoading>();
        }
    }
}