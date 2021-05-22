using GenericCrud.Core.Interfaces;
using GenericCrud.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Business
{
    public class UserManager : BaseManager<Entity.Users>, IUserRepository
    {
        private readonly IUserRepository repo;
        public UserManager()
        {
            repo = new UserRepository();
        }
        public bool CustomMethod()
        {
            return repo.CustomMethod();
        }
    }
}
