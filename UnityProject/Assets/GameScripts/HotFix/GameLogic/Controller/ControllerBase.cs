using System;
using System.Collections.Generic;
using TEngine;

namespace GameLogic
{
    public abstract class ControllerBase : IControllerBase
    {
        private Dictionary<int, Action> _events = new Dictionary<int, Action>();

        public abstract void Awake();


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
        
        
             
    }
}