using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Helpers
{
    public class CypherService
    {
        IConfiguration Configuration;

        public CypherService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        //MÉTODO PARA GENERAR SALT
        public String GetSalt()
        {
            Random rand = new Random();
            String salt = "";
            for (int i = 0; i <= 50; i++)
            {
                salt += Convert.ToChar(rand.Next(0, 255));
            }
            return salt;
        }

        public byte[] CifrarPassword(String password, String salt)
        {
            String passcompleta = password + salt;
            SHA256Managed sha = new SHA256Managed();
            byte[] salida;
            salida = Encoding.UTF8.GetBytes(passcompleta);
            for (int i = 1; i < Convert.ToInt32(Configuration["iteracionespass"]); i++)
            {
                salida = sha.ComputeHash(salida);
            }
            sha.Clear();
            return salida;
        }
    }
}
