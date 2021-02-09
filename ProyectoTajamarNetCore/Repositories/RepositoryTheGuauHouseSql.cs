using ProyectoTajamarNetCore.Data;
using ProyectoTajamarNetCore.Helpers;
using ProyectoTajamarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProyectoTajamarNetCore.Helpers.Enumerations;

namespace ProyectoTajamarNetCore.Repositories
{
    public class RepositoryTheGuauHouseSql : IRepositoryTheGuauHouse
    {
        GuauHouseContext Context;
        //CypherService Cypher;

        public RepositoryTheGuauHouseSql(GuauHouseContext context)//, CypherService cypher
        {
            this.Context = context;
            //this.Cypher = cypher;
        }

        //public List<Usuario> GetUsuarios()
        //{
        //    var consulta = from datos in this.Context.Usuarios
        //                   select datos;
        //    return consulta.ToList();
        //}

        public Usuario GetUsuarioUsername(String username)
        {
            return this.Context.Usuarios.Where(x => x.UserName == username).FirstOrDefault();
        }

        public int GetMaxIdUsuarios()
        {
            int id = (from datos in this.Context.Usuarios
                      select datos.IdUsuario).Count();
            if (id == 0)
            {
                return 1;
            }
            return (from datos in this.Context.Usuarios
                    select datos.IdUsuario).Max() + 1;
        }

        public Usuario InsertarUsuario(String nombre
            , String username, String password)
        {
            Usuario user = new Usuario();
            user.IdUsuario = this.GetMaxIdUsuarios();
            //Usuario user = new Usuario();
            //user.IdUsuario = 1;
            user.Nombre = nombre;
            user.UserName = username.ToLower();
            user.Rol = (int)Roles.Usuario;
            //String salt = this.Cypher.GetSalt();
            //user.Salt = salt;
            //byte[] res = this.Cypher.CifrarPassword(password, salt);
            //user.Password = res;
            user.Password = password;
            this.Context.Usuarios.Add(user);
            this.Context.SaveChanges();
            return user;
        }

        public Usuario Login(String username, String password)
        {
            Usuario user = this.Context.Usuarios
                .Where(x => x.UserName == username.ToLower())
                .FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            else
            {
                //String salt = user.Salt;
                //byte[] passbbdd = user.Password;
                //byte[] passtemporal = this.Cypher.CifrarPassword(password, salt);
                //bool res = PasswordCompare.CompararPasswordByte(passtemporal, user.Password);
                bool res = Comparator.CompararPasswordString(password, user.Password);
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

        //public void InsertarUsuario(String nombre
        //    , String username, String password)
        //{
        //    Usuario user = new Usuario();
        //    user.IdUsuario = 1;
        //    user.Nombre = nombre;
        //    user.UserName = username;
        //    String salt = this.Cypher.GetSalt();
        //    user.Salt = salt;
        //    byte[] res = this.Cypher.CifrarPassword(password, salt);
        //    user.Password = res;
        //    this.Context.Usuarios.Add(user);
        //    this.Context.SaveChanges();
        //}

        //public Usuario Login(String username, String password)
        //{
        //    Usuario user = this.Context.Usuarios
        //        .Where(x => x.UserName == username)
        //        .FirstOrDefault();
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        String salt = user.Salt;
        //        byte[] passbbdd = user.Password;
        //        byte[] passtemporal = this.Cypher.CifrarPassword(password, salt);
        //        bool res = PasswordCompare.CompararPasswordByte(passtemporal, user.Password);
        //        if (res == true)
        //        {
        //            return user;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}
    }
}
