using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Helpers
{
    public class ToolKit
    {
        public static String SerializeJsonObject(Object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        public static T DeserializeJsonObject<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
