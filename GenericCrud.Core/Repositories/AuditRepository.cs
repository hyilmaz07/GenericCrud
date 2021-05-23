using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Repositories
{
    public class AuditRepository : Connection.Connection
    {
        int Insert(Entity.AuditTracing model)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return (int)con.Insert(model);
                }
            }
            catch
            {
                return 0;
            }
        }
        public static int CreateAuditTracing(Entity.AuditTracing entity)
        {
            return new AuditRepository().Insert(new Entity.AuditTracing());
        }
    }
}
