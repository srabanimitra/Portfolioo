using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolioo.Models
{
    public static class SessionHelper
    {
        public static void SetObject<T>(this HttpSessionStateBase session, string key, T value)
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