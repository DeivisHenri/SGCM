using SGCM.Models.Usuario.CadastroUsuarioModel;
using SGCM.Models.Usuario.EditarUsuarioModel;
using SGCM.Models.Usuario.ConsultarUsuarioModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;
using System;

namespace SGCM.AppData.Usuario
{
    public class UsuarioBLL {

        public int InserirUsuario(CadastroUsuarioModel usuario) {
            try {
                usuario.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.CPF);
                usuario.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.Telefone_Celular);

                usuario.permissoes.flIniciarAtendimento = usuario.usuario.TipoUsuario;

                UsuarioDAL usuariosDAL = new UsuarioDAL();
                return usuariosDAL.InserirUsuario(usuario);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ListaConsultarUsuarioModel> ConsultarUsuario(int IdPessoa, int sort, string psqNome, string psqCPF, string psqTelefoneCelular) {
            try {
                if (psqCPF != null) {
                    psqCPF = UtilMetodo.RemovendoCaracteresEspeciais(psqCPF);
                }

                if (psqTelefoneCelular != null) {
                    psqTelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(psqTelefoneCelular);
                }

                UsuarioDAL usuariosDAL = new UsuarioDAL();
                return usuariosDAL.ConsultarUsuario(IdPessoa, sort, psqNome, psqCPF, psqTelefoneCelular);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarUsuarioModel ConsultarUsuarioID(int IdPessoa){
            try {
                UsuarioDAL usuariosDAL = new UsuarioDAL();
                return usuariosDAL.ConsultarUsuarioID(IdPessoa);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarUsuario(EditarUsuarioModel usuario) {
            try {
                usuario.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.CPF);
                usuario.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(usuario.pessoa.Telefone_Celular);
                usuario.permissoes.flIniciarAtendimento = usuario.usuario.TipoUsuario;

                UsuarioDAL usuariosDAL = new UsuarioDAL();
                return usuariosDAL.EditarUsuario(usuario);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}