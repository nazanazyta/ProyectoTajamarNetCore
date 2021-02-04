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
        //CypherService Cypher;

        public RepositoryTheGuauHouseSql(TheGuauHouseContext context)//, CypherService cypher
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

        private int GetMaxId()
        {

            int id = (from datos in this.Context.Usuarios
                      select datos.IdUsuario).Max() + 1;
            return id;
        }

        public void InsertarUsuario(String nombre
            , String username, String password)
        {
            Usuario user = new Usuario();
            user.IdUsuario = this.GetMaxId();
            //Usuario user = new Usuario();
            //user.IdUsuario = 1;
            user.Nombre = nombre;
            user.UserName = username;
            //String salt = this.Cypher.GetSalt();
            //user.Salt = salt;
            //byte[] res = this.Cypher.CifrarPassword(password, salt);
            //user.Password = res;
            user.Password = password;
            this.Context.Usuarios.Add(user);
            this.Context.SaveChanges();
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
                //String salt = user.Salt;
                //byte[] passbbdd = user.Password;
                //byte[] passtemporal = this.Cypher.CifrarPassword(password, salt);
                //bool res = PasswordCompare.CompararPasswordByte(passtemporal, user.Password);
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
