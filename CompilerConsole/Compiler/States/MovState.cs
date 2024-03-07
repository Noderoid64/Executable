using System;
using System.Collections.Generic;

namespace CompilerConsole
{
    public class MovState : CompilerState
    {
        public MovState(IStatePool pool) : base(pool)
        {
        }

        public override void ProcessToken(string token)
        {
            if (Reg32.Contains(token))
            {
                _statePool.ChangeStateWithExecution(typeof(Mov_rm32_r32_0_State), token);
                return;
            }
            throw new InvalidOperationException("");
        }
    }
}