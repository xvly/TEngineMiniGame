using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameLogic
{
    public class ControllerModule 
    {
        public void Awake()
        {
            var conntrollers = GameModule.CodeType.GetTypes(typeof(ControllerAttribute));

            foreach (var controllerType in conntrollers)
            {
                var controller = Activator.CreateInstance(controllerType) as IControllerBase;
                controller.Awake();
            }
        }
    }
}