using Microsoft.AspNetCore.Http;
using ProyectoTajamarNetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, String key, Object value)
        {
            String objetoserializado = ToolKit.SerializeJsonObject(value);
            session.SetString(key, objetoserializado);
        }

        public static T GetObject<T>(this ISession session, String key)
        {
            String objetoserializado = session.GetString(key);
            if (objetoserializado == null)
            {
                return default(T);
            }
            return ToolKit.DeserializeJsonObject<T>(objetoserializado);
        }
    }
}
