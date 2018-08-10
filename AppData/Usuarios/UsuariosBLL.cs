using SGCM.Models.Usuarios;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;

namespace SGCM.AppData.Usuarios
{
    public class UsuariosBLL {

        public int InserirUsuario(UsuariosModel usuario)
        {
            usuario.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.CPF);
            usuario.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.Telefone_Celular);

            UsuariosDAL usuariosDAL = new UsuariosDAL();
            return usuariosDAL.InserirUsuario(usuario);
        }

        public List<UsuariosModel> ConsultarUsuario() {
            UsuariosDAL usuariosDAL = new UsuariosDAL();
            return usuariosDAL.ConsultarUsuario();
        }
    }
}
