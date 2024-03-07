using System;
using System.Collections.Generic;

namespace CompilerConsole
{
    public class Compiler : IStatePool
    {
        private CompilerState _state;

        private readonly Dictionary<Type, CompilerState> _states;

        public Compiler()
        {
            _states = new Dictionary<Type, CompilerState>()
            {
                { typeof(NoContextState), new NoContextState(this) },
                { typeof(MovState), new MovState(this) },
                { typeof(Mov_rm32_r32_0_State), new Mov_rm32_r32_0_State(this)}
            };
            ChangeState(typeof(NoContextState));
        }
        
        public void ProcessToken(string token)
        {
            _state.ProcessToken(token.ToLower());
        }

        public void ChangeState(Type type)
        {
            _state = _states[type];
        }

        public void ChangeStateWithExecution(Type type, string token)
        {
            _state = _states[type];
            _state.ProcessToken(token);
        }
    }
}