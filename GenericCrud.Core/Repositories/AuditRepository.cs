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
        public static void CreateAuditTracing(Entity.AuditTracing entity)
        {
            new AuditTracing().Insert(new Entity.AuditTracing());
        }
    }
}
