using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Documents> DocumentRepository { get; }
        
        int Complete();
    }
}
