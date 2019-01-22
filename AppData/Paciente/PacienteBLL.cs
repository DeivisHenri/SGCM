using SGCM.Models.Paciente.CadastroPacienteModel;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using SGCM.Models.Paciente.EditarPacienteModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;

namespace SGCM.AppData.Paciente
{
    public class PacienteBLL {

        public int InserirPaciente(CadastroPacienteModel paciente)
        {
            paciente.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.CPF);
            paciente.pessoa.TelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.TelefoneCelular);

            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.InserirPaciente(paciente);
        }

        public List<ConsultarPacienteModel> ConsultarPaciente(int IdMedico) {
            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.ConsultarPaciente(IdMedico);
        }

        public EditarPacienteModel ConsultarPacienteID(int IdPessoa){
            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.ConsultarPacienteID(IdPessoa);
        }

        public int EditarPaciente(EditarPacienteModel pacienteModel) {
            pacienteModel.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.pessoa.CPF);
            pacienteModel.pessoa.TelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.pessoa.TelefoneCelular);

            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.EditarPaciente(pacienteModel);
        }

    }
}
