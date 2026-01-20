using TEngine;

namespace GameLogic
{
    public class PoolEvent
    {
        // 推出gameobject
        public static readonly int OnPushGameObject = RuntimeId.ToRuntimeId("IPoolEvent_Event.OnPushGameObject");
        
        // 获取gameobject
        public static readonly int OnGetGameObject = RuntimeId.ToRuntimeId("IPoolEvent_Event.OnGetGameObject");
        
        // 推出object
        public static readonly int OnGetObject = RuntimeId.ToRuntimeId("IPoolEvent_Event.OnGetObject");
        
        // 获取object
        public static readonly int OnPushObject = RuntimeId.ToRuntimeId("IPoolEvent_Event.OnPushObject");
    }
}