
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}
