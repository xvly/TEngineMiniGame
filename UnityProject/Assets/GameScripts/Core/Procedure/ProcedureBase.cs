using System;
using System.Collections.Generic;
using TEngine;
using UnityEngine.UIElements;

namespace Procedure
{
    public abstract class ProcedureBase : TEngine.ProcedureBase
    {
        /// <summary>
        /// 获取流程是否使用原生对话框
        /// 在一些特殊的流程（如游戏逻辑对话框资源更新完成前的流程）中，可以考虑调用原生对话框进行消息提示行为
        /// </summary>
        public abstract bool UseNativeDialog { get; }
        
        protected readonly IResourceModule _resourceModule = ModuleSystem.GetModule<IResourceModule>();

        private Dictionary<int, Action> _events = new Dictionary<int, Action>();

        protected void AddEventListener(int eventType, Action handler)
        {
            if (_events.ContainsKey(eventType))
            {
                Log.Error($"{eventType} already exist.");
                return;
            }
            
            _events.Add(eventType, handler);
            GameEvent.AddEventListener(eventType, handler);
        }
        
        void RemoveAllEventListeners()
        {
            foreach (var eventData in _events)
            {
                GameEvent.RemoveEventListener(eventData.Key,eventData.Value);
            }   
        }

        protected override void OnLeave(IFsm<IProcedureModule> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            RemoveAllEventListeners();   
        }
    }
}