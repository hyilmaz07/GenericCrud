using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Entity
{
    [Table("Users")]
    public class Users : Humans
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
