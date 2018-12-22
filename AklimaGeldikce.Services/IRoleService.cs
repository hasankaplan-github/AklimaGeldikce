using AklimaGeldikce.Entities;
using System.Collections.Generic;

namespace AklimaGeldikce.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        IList<Role> GetManyByNames(params string[] names);
    }
}
