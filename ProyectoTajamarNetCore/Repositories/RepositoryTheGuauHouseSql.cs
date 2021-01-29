using ProyectoTajamarNetCore.Data;
using ProyectoTajamarNetCore.Helpers;
using ProyectoTajamarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Repositories
{
    public class RepositoryTheGuauHouseSql : IRepositoryTheGuauHouse
    {
        TheGuauHouseContext Context;

        public RepositoryTheGuauHouseSql(TheGuauHouseContext context)
        {
            this.Context = context;
        }

        //public List<Usuario> GetUsuarios()
        //{
        //    var consulta = from datos in this.Context.Usuarios
        //                   select datos;
        //    return consulta.ToList();
        //}

        public void InsertarUsuario(int idusuario, String nombre
            , String username, String password)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(String username, String password)
        {
            Usuario user = this.Context.Usuarios
                .Where(x => x.UserName == username)
                .FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                bool res = PasswordCompare.CompararPasswordString(password, user.Password);
                if (res == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
