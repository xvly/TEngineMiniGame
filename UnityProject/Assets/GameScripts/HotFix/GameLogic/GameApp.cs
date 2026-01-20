using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using GameLogic;
#if ENABLE_OBFUZ
using Obfuz;
#endif
using TEngine;
#pragma warning disable CS0436


/// <summary>
/// 游戏App。
/// </summary>
#if ENABLE_OBFUZ
[ObfuzIgnore(ObfuzScope.TypeName | ObfuzScope.MethodName)]
#endif
public partial class GameApp
{
    private static List<Assembly> _hotfixAssembly;


    // public static List<ProcedureBase> Procedures = new List<ProcedureBase>();

    /// <summary>
    /// 热更域App主入口。
    /// </summary>
    /// <param name="objects"></param>
    public static void Entrance(object[] objects)
    {
        // GameEventHelper.Init();
        
        _hotfixAssembly = (List<Assembly>)objects[0];
        
        

        
        Log.Warning("======= 看到此条日志代表你成功运行了热更新代码 =======");
        Log.Warning("======= Entrance GameApp =======");
        Utility.Unity.AddDestroyListener(Release);
        Log.Warning("======= StartGameLogic =======");
        StartGameLogic();
    }
    
    private static void StartGameLogic()
    {
        GameModule.CodeType.Awake(_hotfixAssembly.ToArray());
        
        GameModule.Controller.Awake();
        
        // GameModule.
        // var codeType = ModuleSystem.GetModule<ICodeTypeModule>();
        // codeType.Awake(_hotfixAssembly.ToArray());
        
        UIModule.Instance.Active();
        // StartMainScene().Forget();
        
        
        ProcedureBase[] procedures = new ProcedureBase[] { 
            new ProcedureEntrance(), 
            new ProcedureChangeScene(), 
            new ProcedureHome(),
            new ProcedureBattle()};

        GameModule.Procedure.RestartProcedure(procedures);
    }

    private static async UniTaskVoid StartMainScene()
    {
        // await GameModule.Scene.LoadSceneAsync("scene_main");
        
        

        // GameModule.Procedure.StartProcedure<ProcedureChangeScene>();
        
        
        // await GameModule.Scene.LoadSceneAsync("scene_home");
        // GameModule.UI.ShowUIAsync<HomeUI>();
        // GameModule.UI.ShowUIAsync<BattleMainUI>();
        
    }
    
    private static void Release()
    {
        SingletonSystem.Release();
        Log.Warning("======= Release GameApp =======");
    }
}