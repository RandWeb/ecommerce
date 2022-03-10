using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IEntity<TKey> : IBaseEntity<TKey>
    {
    }

    public interface IEntity : IBaseEntity<Guid>
    {

    }
}
