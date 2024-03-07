namespace CompilerConsole
{
    public abstract class CompilerState
    {
        protected readonly IStatePool _statePool;
        protected CompilerState(IStatePool pool)
        {
            _statePool = pool;
        }
        public abstract void ProcessToken(string token);
    }
}