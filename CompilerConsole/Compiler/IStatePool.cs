using System;

namespace CompilerConsole
{
    public interface IStatePool
    {
        void ChangeState(Type type);
        void ChangeStateWithExecution(Type type, string token);
    }
}