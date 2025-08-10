using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolioo.Models
{
    public class SessionHelper
    {
        public static void SetObject(this HttpSessionStateBase session, string key, object value)
        {
            session[key] = JsonConvert.SerializeObject(value);
        }

        public static T GetObject<T>(this HttpSessionStateBase session, string key)
        {
            var value = session[key] as string;
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}