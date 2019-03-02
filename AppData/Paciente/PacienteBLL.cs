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

        public EditarPacienteModel ConsultarPacienteID(int idPaciente){
            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.ConsultarPacienteID(idPaciente);
        }

        public int EditarPaciente(EditarPacienteModel pacienteModel) {
            pacienteModel.Pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.Pessoa.CPF);
            pacienteModel.Pessoa.TelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.Pessoa.TelefoneCelular);

            PacienteDAL pacienteDAL = new PacienteDAL();
            return pacienteDAL.EditarPaciente(pacienteModel);
        }
    }
}
