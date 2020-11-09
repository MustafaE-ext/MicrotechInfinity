using System;
using System.Collections.Generic;
using System.Text;

namespace MicrotechInfinity.Domain.Interfaces.UoW
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
