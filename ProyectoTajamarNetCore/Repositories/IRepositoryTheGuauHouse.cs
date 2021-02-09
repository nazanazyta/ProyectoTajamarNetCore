using ProyectoTajamarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Repositories
{
    public interface IRepositoryTheGuauHouse
    {
        //List<Usuario> GetUsuarios();

        Usuario GetUsuarioUsername(String username);

        int GetMaxIdUsuarios();

        Usuario InsertarUsuario(String nombre
            , String username, String password);

        Usuario Login(String username, String password);
    }
}
