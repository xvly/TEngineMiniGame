using TEngine;

namespace GameLogic
{
    [Controller]
    public class ControllerLoading : ControllerBase
    {
        public override void Awake()
        {
            Log.Info("!! loading controller awake");
        }
    }
}