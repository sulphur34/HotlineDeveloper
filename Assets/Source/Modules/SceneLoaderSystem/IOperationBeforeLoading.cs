using System;

namespace Modules.SceneLoaderSystem
{
    public interface IOperationBeforeLoading
    {
        event Action<IOperationBeforeLoading> Executed;
    }
}