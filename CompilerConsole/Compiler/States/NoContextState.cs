using System;

namespace CompilerConsole
{
    public class NoContextState : CompilerState
    {
        public NoContextState(IStatePool _statePool): base(_statePool) { }
        public override void ProcessToken(string token)
        {
            if (token == "mov")
            {
                _statePool.ChangeState(typeof(MovState));
                return;
            }

            throw new InvalidOperationException("");
        }
    }
}