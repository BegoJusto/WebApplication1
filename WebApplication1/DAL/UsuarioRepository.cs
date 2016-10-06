using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    interface UsuarioRepository
    {

       IList<Usuario> getAll();

        Usuario getById(Guid codigo);

        Usuario update(Usuario usuario);

        void delete(Guid codigo);

        Guid create(Usuario usuario);




    }
}