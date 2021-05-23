
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Helper
{
    public class Object
    {
        public static T Clone<T>(T source)
        {
            if (object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            string serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
        public static bool IsChanged(object OriginalObject, object ModifiedObject)
        {
            bool result = false;
            string originalString = JsonConvert.SerializeObject(OriginalObject);
            string modifiedString = JsonConvert.SerializeObject(ModifiedObject);
            if (!originalString.Equals(modifiedString))
            {
                result = true;
            }
            return result;
        }
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
        public static string Serialize(object obj)
        {
            var serializerSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializedObject = JsonConvert.SerializeObject(obj, serializerSettings);
            return serializedObject;
        }
    }
}
