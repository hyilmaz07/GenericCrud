using GenericCrud.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Tool
{
    public static class Audit
    {
        static string Compare<T>(object _object1, object _object2)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            List<AuditTracing> detailList = new List<AuditTracing>();
            foreach (PropertyInfo property in properties)
            {
                object firstValue = property.GetValue(_object1);
                object secondValue = property.GetValue(_object2);
                if (!object.Equals(firstValue, secondValue))
                {
                    AuditTracing details = new AuditTracing();
                    details.Property = property.Name;
                    details.OldValue = firstValue.ToString();
                    details.NewValue = secondValue.ToString();
                    detailList.Add(details);
                }
            }
            return Serialize(detailList);
        }
        static string Serialize(this object obj)
        {
            var serializerSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializedObject = JsonConvert.SerializeObject(obj, serializerSettings);
            return serializedObject;
        }
    }
}
