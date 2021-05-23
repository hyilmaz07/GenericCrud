using Dapper.Contrib.Extensions;
using GenericCrud.Core.Repositories;
using GenericCrud.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Audit
{
    public class AuditTracing : Connection.Connection
    {
        public static string Compare<T>(object obj1, object obj2)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            List<Entity.AuditTracing> detailList = new List<Entity.AuditTracing>();
            foreach (PropertyInfo property in properties)
            {
                object firstValue = property.GetValue(obj1);
                object secondValue = property.GetValue(obj2);
                if (!object.Equals(firstValue, secondValue))
                {
                    Entity.AuditTracing details = new Entity.AuditTracing();
                    //details.Property = property.Name;
                    details.OldValue = firstValue?.ToString();
                    details.NewValue = secondValue?.ToString();
                    detailList.Add(details);
                }
            }
            return Serialize(detailList);
        }
     public   static string Serialize(object obj)
        {
            var serializerSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializedObject = JsonConvert.SerializeObject(obj, serializerSettings);
            return serializedObject;
        }
        
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
