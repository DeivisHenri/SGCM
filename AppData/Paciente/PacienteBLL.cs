using SGCM.Models.Paciente.CadastroPacienteModel;
//using SGCM.Models.Paciente.EditarUsuarioModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;

namespace SGCM.AppData.Paciente
{
    public class PacienteBLL {

        public int InserirPaciente(CadastroPacienteModel paciente)
        {
            paciente.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.CPF);
            paciente.pessoa.Telefone_Celular = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.Telefone_Celular);
            paciente.pessoa.TipoUsuario = 3;

            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.InserirPaciente(paciente);
        }

        //public List<CadastroUsuarioModel> ConsultarUsuario(int IdPessoa) {
        //    UsuarioDAL usuariosDAL = new UsuarioDAL();
        //    return usuariosDAL.ConsultarUsuario(IdPessoa);
        //}

        //public EditarUsuarioModel ConsultarUsuarioID(int IdPessoa){
        //    UsuarioDAL usuariosDAL = new UsuarioDAL();
        //    return usuariosDAL.ConsultarUsuarioID(IdPessoa);
        //}
        
    }
}
