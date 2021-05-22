using GenericCrud.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Repositories
{
    public class UserRepository : BaseRepository<Entity.Users>, IUserRepository
    {
        public bool CustomMethod()
        {
            using (var con = GetConnection)
            {
                return true;
            }
        }
    }
}
