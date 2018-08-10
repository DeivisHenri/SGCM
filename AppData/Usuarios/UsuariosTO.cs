using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGCM.AppData.Usuarios
{
    public class UsuarioCompletoTO {
        public UsuariosTO usuarioTO { get; set; }
        public PessoaTO pessoaTO { get; set; }
        public PermissoesTO permissoesTO { get; set; }
    }

    public class UsuariosTO {

        public int ID_Usuario { get; set; }

        public int ID_Pessoa { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class PessoaTO
    {
        public int Id_Pessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Telefone_Celular { get; set; }
        public string Email { get; set; }
        public int Tipo_Usuario { get; set; }
    }

    public class PermissoesTO {
        public int Id_Permissoes { get; set; }
        public int Id_Usuario { get; set; }
        public int Fl_Usuario_I { get; set; }
        public int Fl_Usuario_C { get; set; }
        public int Fl_Usuario_A { get; set; }
        public int Fl_Usuario_E { get; set; }
        public int Fl_Paciente_I { get; set; }
        public int Fl_Paciente_C { get; set; }
        public int Fl_Paciente_A { get; set; }
        public int Fl_Paciente_E { get; set; }
        public int Fl_Consulta_I { get; set; }
        public int Fl_Consulta_C { get; set; }
        public int Fl_Consulta_A { get; set; }
        public int Fl_Consulta_E { get; set; }
        public int Fl_Medicamento_I { get; set; }
        public int Fl_Medicamento_C { get; set; }
        public int Fl_Medicamento_A { get; set; }
        public int Fl_Medicamento_E { get; set; }
        public int Fl_Exames_I { get; set; }
        public int Fl_Exames_C { get; set; }
        public int Fl_Exames_A { get; set; }
        public int Fl_Exames_E { get; set; }
    }
}
