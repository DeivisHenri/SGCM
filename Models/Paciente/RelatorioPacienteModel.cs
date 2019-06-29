using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.Models.Paciente.RelatorioPacienteModel {

    public class RelatorioPacienteModel {
        public string sortOrder { get; set; }

        [MinLength(3, ErrorMessage = "O campo 'Nome' deve conter pelo menos 3 caracteres")]
        [StringLength(50, ErrorMessage = "O campo 'Nome' deve conter no máximo 50 caracteres")]
        [Display(Name = "Nome")]
        public string psqNome { get; set; }

        [MinLength(14, ErrorMessage = "O campo 'CPF' deve conter pelo menos 11 caracteres")]
        [StringLength(14, ErrorMessage = "O campo 'CPF' deve conter no máximo 11 caracteres")]
        [Display(Name = "CPF")]
        public string psqCPF { get; set; }

        [MinLength(15, ErrorMessage = "O campo 'Telefone Celular' deve conter pelo menos 11 caracteres")]
        [StringLength(15, ErrorMessage = "O campo 'Telefone Celular' deve conter no máximo 11 caracteres")]
        [Display(Name = "Telefone Celular")]
        public string psqTelefoneCelular { get; set; }

        public List<ListPaciente> ListaPacientes { get; set; }
    }

    public class ListPaciente {
        public int idPaciente { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public string telefoneCelular { get; set; }
    }

}
