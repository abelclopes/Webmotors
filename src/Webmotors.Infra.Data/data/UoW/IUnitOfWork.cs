using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Infra.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
