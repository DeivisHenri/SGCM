using SGCM.Models.Paciente.CadastroPacienteModel;
using SGCM.Models.Paciente.ConsultarPacienteModel;
using SGCM.Models.Paciente.EditarPacienteModel;
using SGCM.AppData.Infraestrutura.UtilMetodo;
using System.Collections.Generic;
using System;

namespace SGCM.AppData.Paciente
{
    public class PacienteBLL {

        public int InserirPaciente(CadastroPacienteModel paciente) {
            try {
                paciente.pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.CPF);
                paciente.pessoa.TelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(paciente.pessoa.TelefoneCelular);

                PacienteDAL pacienteDAL = new PacienteDAL();
                return pacienteDAL.InserirPaciente(paciente);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ListaConsultarPacienteModel> ConsultarPaciente(int IdMedico, int sortOrder, string psqNome, string psqCPF, string psqTelefoneCelular) {
            try {
                if (psqCPF != null) {
                    psqCPF = UtilMetodo.RemovendoCaracteresEspeciais(psqCPF);
                }

                if (psqTelefoneCelular != null) {
                    psqTelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(psqTelefoneCelular);
                }

                PacienteDAL pacienteDAL = new PacienteDAL();
                return pacienteDAL.ConsultarPaciente(IdMedico, sortOrder, psqNome, psqCPF, psqTelefoneCelular);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public EditarPacienteModel ConsultarPacienteID(int idPaciente) {
            try {
                PacienteDAL pacienteDAL = new PacienteDAL();
                return pacienteDAL.ConsultarPacienteID(idPaciente);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public int EditarPaciente(EditarPacienteModel pacienteModel) {
            try {
                pacienteModel.Pessoa.CPF = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.Pessoa.CPF);
                pacienteModel.Pessoa.TelefoneCelular = UtilMetodo.RemovendoCaracteresEspeciais(pacienteModel.Pessoa.TelefoneCelular);

                PacienteDAL pacienteDAL = new PacienteDAL();
                return pacienteDAL.EditarPaciente(pacienteModel);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
