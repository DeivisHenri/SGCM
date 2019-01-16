using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;
using System;

namespace SGCM.AppData.Usuario
{
    public class UsuarioBLL {

        public int InserirUsuario(CadastroUsuarioModel usuario)
        {
            usuario.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.CPF);
            usuario.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.Telefone_Celular);

            UsuarioDAL usuariosDAL = new UsuarioDAL();
            return usuariosDAL.InserirUsuario(usuario);
        }

        public List<CadastroUsuarioModel> ConsultarUsuario(int IdPessoa) {
            UsuarioDAL usuariosDAL = new UsuarioDAL();
            return usuariosDAL.ConsultarUsuario(IdPessoa);
        }

        public EditarUsuarioModel ConsultarUsuarioID(int IdPessoa){
            UsuarioDAL usuariosDAL = new UsuarioDAL();
            return usuariosDAL.ConsultarUsuarioID(IdPessoa);
        }

        public int EditarUsuario(EditarUsuarioModel usuario) {
            usuario.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.CPF);
            usuario.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.Telefone_Celular);

            UsuarioDAL usuariosDAL = new UsuarioDAL();
            return usuariosDAL.EditarUsuario(usuario);
        }
    }
}