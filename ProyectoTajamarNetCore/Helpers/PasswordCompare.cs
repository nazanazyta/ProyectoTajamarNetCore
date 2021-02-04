using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Helpers
{
    public class PasswordCompare
    {
        public static bool CompararPasswordString(String a, String b)
        {
            bool res = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(b[i]) == false)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public static bool CompararPasswordByte(byte[] a, byte[] b)
        {
            bool res = true;
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(b[i]) == false)
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
    }
}
