using System;
using Cysharp.Threading.Tasks;
// using GameLogic;
using Launcher;
using TEngine;
using ProcedureOwner = TEngine.IFsm<TEngine.IProcedureModule>;

namespace Procedure
{
    public class ProcedureStartGame : ProcedureBase
    {
        public override bool UseNativeDialog { get; }
        
        private ProcedureOwner _procedureOwner;

        protected override void OnEnter(IFsm<IProcedureModule> procedureOwner)
        {
            _procedureOwner = procedureOwner;
            
            base.OnEnter(procedureOwner);
            StartGame().Forget();
        }

        private async UniTaskVoid StartGame()
        {
            await UniTask.Yield();
            LauncherMgr.HideAll();
        }
    }
}