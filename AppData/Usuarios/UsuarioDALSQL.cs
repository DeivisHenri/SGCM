using SGCM.Models.Usuario.EditarUsuarioModel;
using System;
using System.Text;

namespace SGCM.AppData.Usuario {
    public class UsuarioDALSQL {

        public string ConsultarUsuario(int sort, string psqNome, string psqCPF, string psqTelefoneCelular) {
            StringBuilder command = new StringBuilder();

            command.AppendLine("Select Pes.nome,");
            command.AppendLine("       Pes.cpf,");
            command.AppendLine("       Pes.telefoneCelular,");
            command.AppendLine("       Pes.idPessoa,");
            command.AppendLine("       Usr.idUsuario");
            command.AppendLine("From Usuario Usr INNER JOIN Pessoa Pes ON Usr.idPessoaUsuario = Pes.idPessoa");
            command.AppendLine("Where Pes.idMedico = @IDPESSOA ");

            if (psqNome != null && psqNome != "") {
                command.AppendLine("AND Pes.nome like @NOME ");
            }

            if (psqCPF != null && psqCPF != "") {
                command.AppendLine("AND Pes.cpf like @CPF ");
            }

            if (psqTelefoneCelular != null && psqTelefoneCelular != "") {
                command.AppendLine("AND Pes.telefoneCelular like @TELEFONECELULAR ");
            }

            switch (sort) {
                case 1:
                    command.AppendLine("Order By Pes.nome ASC");
                    break;
                case 2:
                    command.AppendLine("Order By Pes.nome DESC");
                    break;
                case 3:
                    command.AppendLine("Order By Pes.cpf ASC");
                    break;
                case 4:
                    command.AppendLine("Order By Pes.cpf DESC");
                    break;
                case 5:
                    command.AppendLine("Order By Pes.telefoneCelular ASC");
                    break;
                case 6:
                    command.AppendLine("Order By Pes.telefoneCelular DESC");
                    break;
            }

            return command.ToString();
        }

        public string InserirPessoa() {
            StringBuilder command = new StringBuilder();
            command.AppendLine("INSERT INTO Pessoa(idMedico,");
            command.AppendLine("                   sexo,");
            command.AppendLine("                   nome,");
            command.AppendLine("                   cpf,");
            command.AppendLine("                   rg,");
            command.AppendLine("                   dataNascimento,");
            command.AppendLine("                   logradouro,");
            command.AppendLine("                   numero,");
            command.AppendLine("                   bairro,");
            command.AppendLine("                   cidade,");
            command.AppendLine("                   uf,");
            command.AppendLine("                   telefoneCelular,");
            command.AppendLine("                   email)");
            command.AppendLine("       VALUES(@IDMEDICO,");
            command.AppendLine("              @SEXO,");
            command.AppendLine("              @NOME,");
            command.AppendLine("              @CPF,");
            command.AppendLine("              @RG,");
            command.AppendLine("              STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
            command.AppendLine("              @LOGRADOURO,");
            command.AppendLine("              @NUMERO,");
            command.AppendLine("              @BAIRRO,");
            command.AppendLine("              @CIDADE,");
            command.AppendLine("              @UF,");
            command.AppendLine("              @TELEFONECELULAR,");
            command.AppendLine("              @EMAIL); ");

            return command.ToString();
        }

        public string InserirUsuario() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO Usuario(idPessoaUsuario, usuario, senha, tipoUsuario, dataCadastro, statusDesativacao) ");
            command.AppendLine("             VALUES(@IDPESSOA, @USUARIO, @SENHA, @TIPOUSUARIO, CURDATE(), 1); ");

            return command.ToString();
        }

        public string InserirPermissoes() {
            StringBuilder command = new StringBuilder();

            command.AppendLine("INSERT INTO permissoes(idUsuarioPermissoes,");
            command.AppendLine("					   flUsuarioI,");
            command.AppendLine("					   flUsuarioC,");
            command.AppendLine("					   flUsuarioA,");
            command.AppendLine("					   flUsuarioE,");
            command.AppendLine("					   flPacienteI,");
            command.AppendLine("					   flPacienteC,");
            command.AppendLine("					   flPacienteA,");
            command.AppendLine("					   flPacienteE,");
            command.AppendLine("					   flConsultaI,");
            command.AppendLine("					   flConsultaC,");
            command.AppendLine("					   flConsultaA,");
            command.AppendLine("					   flConsultaE,");
            command.AppendLine("					   flAusenciaI,");
            command.AppendLine("					   flAusenciaC,");
            command.AppendLine("					   flAusenciaA,");
            command.AppendLine("					   flAusenciaE,");
            command.AppendLine("					   flMedicamentoI,");
            command.AppendLine("					   flMedicamentoC,");
            command.AppendLine("					   flMedicamentoA,");
            command.AppendLine("					   flMedicamentoE,");
            command.AppendLine("					   flExamesI,");
            command.AppendLine("					   flExamesC,");
            command.AppendLine("					   flExamesA,");
            command.AppendLine("					   flExamesE,");
            command.AppendLine("					   flReceitaI,");
            command.AppendLine("					   flReceitaC,");
            command.AppendLine("					   flReceitaA,");
            command.AppendLine("					   flReceitaE,");
            command.AppendLine("					   flHistoriaMolestiaAtualI,");
            command.AppendLine("					   flHistoriaMolestiaAtualC,");
            command.AppendLine("					   flHistoriaMolestiaAtualA,");
            command.AppendLine("					   flHistoriaMolestiaAtualE,");
            command.AppendLine("					   flHistoriaPatologicaPregressaI,");
            command.AppendLine("					   flHistoriaPatologicaPregressaC,");
            command.AppendLine("					   flHistoriaPatologicaPregressaA,");
            command.AppendLine("					   flHistoriaPatologicaPregressaE,");
            command.AppendLine("					   flHipoteseDiagnosticaI,");
            command.AppendLine("					   flHipoteseDiagnosticaC,");
            command.AppendLine("					   flHipoteseDiagnosticaA,");
            command.AppendLine("					   flHipoteseDiagnosticaE,");
            command.AppendLine("					   flCondutaI,");
            command.AppendLine("					   flCondutaC,");
            command.AppendLine("					   flCondutaA,");
            command.AppendLine("					   flCondutaE,");
            command.AppendLine("					   flIniciarAtendimento)");
            command.AppendLine("VALUES(@IDUSUARIO,");
            command.AppendLine("	   @FLUSUARIOI,");
            command.AppendLine("	   @FLUSUARIOC,");
            command.AppendLine("	   @FLUSUARIOA,");
            command.AppendLine("	   @FLUSUARIOE,");
            command.AppendLine("	   @FLPACIENTEI,");
            command.AppendLine("	   @FLPACIENTEC,");
            command.AppendLine("	   @FLPACIENTEA,");
            command.AppendLine("	   @FLPACIENTEE,");
            command.AppendLine("	   @FLCONSULTAI,");
            command.AppendLine("	   @FLCONSULTAC,");
            command.AppendLine("	   @FLCONSULTAA,");
            command.AppendLine("	   @FLCONSULTAE,");
            command.AppendLine("	   @FLAUSENCIAI,");
            command.AppendLine("	   @FLAUSENCIAC,");
            command.AppendLine("	   @FLAUSENCIAA,");
            command.AppendLine("	   @FLAUSENCIAE,");
            command.AppendLine("	   @FLMEDICAMENTOI,");
            command.AppendLine("	   @FLMEDICAMENTOC,");
            command.AppendLine("	   @FLMEDICAMENTOA,");
            command.AppendLine("	   @FLMEDICAMENTOE,");
            command.AppendLine("	   @FLEXAMESI,");
            command.AppendLine("	   @FLEXAMESC,");
            command.AppendLine("	   @FLEXAMESA,");
            command.AppendLine("	   @FLEXAMESE,");
            command.AppendLine("	   @FLRECEITAI,");
            command.AppendLine("	   @FLRECEITAC,");
            command.AppendLine("	   @FLRECEITAA,");
            command.AppendLine("	   @FLRECEITAE,");
            command.AppendLine("	   @FLHISTORIAMOLESTIAATUALI,");
            command.AppendLine("	   @FLHISTORIAMOLESTIAATUALC,");
            command.AppendLine("	   @FLHISTORIAMOLESTIAATUALA,");
            command.AppendLine("	   @FLHISTORIAMOLESTIAATUALE,");
            command.AppendLine("	   @FLHISTORIAPATOLOGICAPREGRESSAI,");
            command.AppendLine("	   @FLHISTORIAPATOLOGICAPREGRESSAC,");
            command.AppendLine("	   @FLHISTORIAPATOLOGICAPREGRESSAA,");
            command.AppendLine("	   @FLHISTORIAPATOLOGICAPREGRESSAE,");
            command.AppendLine("	   @FLHIPOTESEDIAGNOSTICAI,");
            command.AppendLine("	   @FLHIPOTESEDIAGNOSTICAC,");
            command.AppendLine("	   @FLHIPOTESEDIAGNOSTICAA,");
            command.AppendLine("	   @FLHIPOTESEDIAGNOSTICAE,");
            command.AppendLine("	   @FLCONDUTAI,");
            command.AppendLine("	   @FLCONDUTAC,");
            command.AppendLine("	   @FLCONDUTAA,");
            command.AppendLine("	   @FLCONDUTAE,");
            command.AppendLine("	   @FLINICIARATENDIMENTO)");

            //command.AppendLine("INSERT INTO Permissoes(idUsuarioPermissoes,");
            //command.AppendLine("                       flUsuarioI,");
            //command.AppendLine("                       flUsuarioC,");
            //command.AppendLine("                       flUsuarioA,");
            //command.AppendLine("                       flUsuarioE,");

            //command.AppendLine("                       flPacienteI,");
            //command.AppendLine("                       flPacienteC,");
            //command.AppendLine("                       flPacienteA,");
            //command.AppendLine("                       flPacienteE,");

            //command.AppendLine("                       flConsultaI,");
            //command.AppendLine("                       flConsultaC,");
            //command.AppendLine("                       flConsultaA,");
            //command.AppendLine("                       flConsultaE,");

            //command.AppendLine("                       flAusenciaI,");
            //command.AppendLine("                       flAusenciaC,");
            //command.AppendLine("                       flAusenciaA,");
            //command.AppendLine("                       flAusenciaE,");

            //command.AppendLine("                       flMedicamentoI,");
            //command.AppendLine("                       FlMedicamentoC,");
            //command.AppendLine("                       flMedicamentoA,");
            //command.AppendLine("                       flMedicamentoE,");

            //command.AppendLine("                       flExamesI,");
            //command.AppendLine("                       flExamesC,");
            //command.AppendLine("                       flExamesA,");
            //command.AppendLine("                       flExamesE,");

            //command.AppendLine("                       flReceitaI,");
            //command.AppendLine("                       flReceitaC,");
            //command.AppendLine("                       flReceitaA,");
            //command.AppendLine("                       flReceitaE,");

            //command.AppendLine("                       flHistoriaMolestiaAtualI,");
            //command.AppendLine("                       flHistoriaMolestiaAtualC,");
            //command.AppendLine("                       flHistoriaMolestiaAtualA,");
            //command.AppendLine("                       flHistoriaMolestiaAtualE,");

            //command.AppendLine("                       flHistoriaPatologicaPregressaI,");
            //command.AppendLine("                       flHistoriaPatologicaPregressaC,");
            //command.AppendLine("                       flHistoriaPatologicaPregressaA,");
            //command.AppendLine("                       flHistoriaPatologicaPregressaE,");

            //command.AppendLine("                       flHipoteseDiagnosticaI,");
            //command.AppendLine("                       flHipoteseDiagnosticaC,");
            //command.AppendLine("                       flHipoteseDiagnosticaA,");
            //command.AppendLine("                       flHipoteseDiagnosticaE,");

            //command.AppendLine("                       flCondutaI,");
            //command.AppendLine("                       flCondutaC,");
            //command.AppendLine("                       flCondutaA,");
            //command.AppendLine("                       flCondutaE,");

            //command.AppendLine("                       flIniciarAtendimento)");

            //command.AppendLine("VALUES(@IDUSUARIO,");
            //command.AppendLine("       @FLUSUARIOI,");
            //command.AppendLine("       @FLUSUARIOC,");
            //command.AppendLine("       @FLUSUARIOA,");
            //command.AppendLine("       @FLUSUARIOE,");

            //command.AppendLine("       @FLPACIENTEI,");
            //command.AppendLine("       @FLPACIENTEC,");
            //command.AppendLine("       @FLPACIENTEA,");
            //command.AppendLine("       @FLPACIENTEE,");

            //command.AppendLine("       @FLCONSULTAI,");
            //command.AppendLine("       @FLCONSULTAC,");
            //command.AppendLine("       @FLCONSULTAA,");
            //command.AppendLine("       @FLCONSULTAE,");

            //command.AppendLine("       @FLAUSENCIAI,");
            //command.AppendLine("       @FLAUSENCIAC,");
            //command.AppendLine("       @FLAUSENCIAA,");
            //command.AppendLine("       @FLAUSENCIAE,");

            //command.AppendLine("       @FLMEDICAMENTOI,");
            //command.AppendLine("       @FLMEDICAMENTOC,");
            //command.AppendLine("       @FLMEDICAMENTOA,");
            //command.AppendLine("       @FLMEDICAMENTOE,");

            //command.AppendLine("       @FLEXAMESI,");
            //command.AppendLine("       @FLEXAMESC,");
            //command.AppendLine("       @FLEXAMESA,");
            //command.AppendLine("       @FLEXAMESE,");

            //command.AppendLine("       @FLHISTORIAMOLESTIAATUALI,");
            //command.AppendLine("       @FLHISTORIAMOLESTIAATUALC,");
            //command.AppendLine("       @FLHISTORIAMOLESTIAATUALA,");
            //command.AppendLine("       @FLHISTORIAMOLESTIAATUALE,");

            //command.AppendLine("       @FLHISTORIAPATOLOGICAPREGRESSAI,");
            //command.AppendLine("       @FLHISTORIAPATOLOGICAPREGRESSAC,");
            //command.AppendLine("       @FLHISTORIAPATOLOGICAPREGRESSAA,");
            //command.AppendLine("       @FLHISTORIAPATOLOGICAPREGRESSAE,");

            //command.AppendLine("       @FLHIPOTESEDIAGNOSTICAI,");
            //command.AppendLine("       @FLHIPOTESEDIAGNOSTICAC,");
            //command.AppendLine("       @FLHIPOTESEDIAGNOSTICAA,");
            //command.AppendLine("       @FLHIPOTESEDIAGNOSTICAE,");

            //command.AppendLine("       @FLCONDUTAI,");
            //command.AppendLine("       @FLCONDUTAC,");
            //command.AppendLine("       @FLCONDUTAA,");
            //command.AppendLine("       @FLCONDUTAE,");

            //command.AppendLine("       @FLINICIARATENDIMENTO)");

            return command.ToString();
        }    

        public string ConsultarUsuarioID() {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Select Pes.idPessoa,");
            command.AppendLine("       Pes.idMedico,");
            command.AppendLine("       Pes.sexo,");
            command.AppendLine("	   Pes.nome,");
            command.AppendLine("	   Pes.cpf,");
            command.AppendLine("	   Pes.rg,");
            command.AppendLine("	   Pes.dataNascimento,");
            command.AppendLine("	   Pes.logradouro,");
            command.AppendLine("	   Pes.numero,");
            command.AppendLine("	   Pes.bairro,");
            command.AppendLine("	   Pes.cidade,");
            command.AppendLine("	   Pes.uf,");
            command.AppendLine("	   Pes.telefoneCelular,");
            command.AppendLine("	   Pes.email,");

            command.AppendLine("	   Usr.idUsuario,");
            command.AppendLine("	   Usr.usuario,");
            command.AppendLine("	   Usr.tipoUsuario,");
            command.AppendLine("	   Usr.dataCadastro,");
            command.AppendLine("	   Usr.statusDesativacao,");

            command.AppendLine("       Per.idPermissoes,");
            command.AppendLine("       Per.flUsuarioI,");
            command.AppendLine("       Per.flUsuarioC,");
            command.AppendLine("       Per.flUsuarioA,");
            command.AppendLine("       Per.flUsuarioE,");

            command.AppendLine("       Per.flPacienteI,");
            command.AppendLine("       Per.flPacienteC,");
            command.AppendLine("       Per.flPacienteA,");
            command.AppendLine("       Per.flPacienteE,");

            command.AppendLine("       Per.flConsultaI,");
            command.AppendLine("       Per.flConsultaC,");
            command.AppendLine("       Per.flConsultaA,");
            command.AppendLine("       Per.flConsultaE,");

            command.AppendLine("       Per.flAusenciaI,");
            command.AppendLine("       Per.flAusenciaC,");
            command.AppendLine("       Per.flAusenciaA,");
            command.AppendLine("       Per.flAusenciaE,");

            command.AppendLine("       Per.flMedicamentoI,");
            command.AppendLine("       Per.flMedicamentoC,");
            command.AppendLine("       Per.flMedicamentoA,");
            command.AppendLine("       Per.flMedicamentoE,");

            command.AppendLine("       Per.flExamesI,");
            command.AppendLine("       Per.flExamesC,");
            command.AppendLine("       Per.flExamesA,");
            command.AppendLine("       Per.flExamesE,");

            command.AppendLine("       Per.flHistoriaMolestiaAtualI,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualC,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualA,");
            command.AppendLine("       Per.flHistoriaMolestiaAtualE,");

            command.AppendLine("       Per.flHistoriaPatologicaPregressaI,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaC,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaA,");
            command.AppendLine("       Per.flHistoriaPatologicaPregressaE,");

            command.AppendLine("       Per.flHipoteseDiagnosticaI,");
            command.AppendLine("       Per.flHipoteseDiagnosticaC,");
            command.AppendLine("       Per.flHipoteseDiagnosticaA,");
            command.AppendLine("       Per.flHipoteseDiagnosticaE,");

            command.AppendLine("       Per.flCondutaI,");
            command.AppendLine("       Per.flCondutaC,");
            command.AppendLine("       Per.flCondutaA,");
            command.AppendLine("       Per.flCondutaE,");

            command.AppendLine("       Per.flIniciarAtendimento");

            command.AppendLine("From Pessoa Pes INNER JOIN Usuario Usr ON Pes.idPessoa = Usr.idPessoaUsuario ");
            command.AppendLine("     INNER JOIN Permissoes Per ON Usr.idUsuario = Per.idUsuarioPermissoes ");
            command.AppendLine("Where Pes.idPessoa = @IDPESSOA");

            return command.ToString();
        }

        public string EditarPessoa(EditarUsuarioModel usuario) {
            Boolean flagSet = false;
            StringBuilder command = new StringBuilder();

            command.AppendLine("Update Pessoa");            

            if (usuario.pessoa.Sexo != null) {
                command.AppendLine("Set    sexo = @SEXO,");
                flagSet = true;
            }

            if (usuario.pessoa.Nome != null) {
                if (flagSet) { 
                    command.AppendLine("       nome = @NOME,");
                } else {
                    command.AppendLine("Set    nome = @NOME,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.CPF != null) {
                if (flagSet)
                    command.AppendLine("       cpf = @CPF,");
                else {
                    command.AppendLine("Set    cpf = @CPF,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.RG != null) {
                if (flagSet)
                    command.AppendLine("       rg = @RG,");
                else {
                    command.AppendLine("Set    rg = @RG,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.DataNascimento != null && usuario.pessoa.DataNascimento != default(DateTime)) {
                if (flagSet)
                    command.AppendLine("       dataNascimento = STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
                else {
                    command.AppendLine("Set    dataNascimento = STR_TO_DATE(@DATANASCIMENTO, '%d/%m/%Y'),");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Logradouro != null) {
                if (flagSet)
                    command.AppendLine("       logradouro = @LOGRADOURO,");
                else {
                    command.AppendLine("Set    logradouro = @LOGRADOURO,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Numero != 0) {
                if (flagSet)
                    command.AppendLine("       numero = @NUMERO,");
                else {
                    command.AppendLine("Set    numero = @NUMERO,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Bairro != null) {
                if (flagSet)
                    command.AppendLine("       bairro = @BAIRRO,");
                else {
                    command.AppendLine("Set    bairro = @BAIRRO,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Cidade != null) {
                if (flagSet)
                    command.AppendLine("       cidade = @CIDADE,");
                else {
                    command.AppendLine("Set    cidade = @CIDADE,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.UF != null) {
                if (flagSet)
                    command.AppendLine("       uf = @UF,");
                else {
                    command.AppendLine("Set    uf = @UF,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Telefone_Celular != null) {
                if (flagSet)
                    command.AppendLine("       telefoneCelular = @TELEFONECELULAR,");
                else {
                    command.AppendLine("Set    telefoneCelular = @TELEFONECELULAR,");
                    flagSet = true;
                }
            }

            if (usuario.pessoa.Email != null) {
                if (flagSet)
                    command.AppendLine("       email = @EMAIL,");
                else {
                    command.AppendLine("Set    email = @EMAIL,");
                    flagSet = true;
                }
            }

            command = new StringBuilder(command.ToString().Remove(command.Length - 3, 3));           

            command.AppendLine(" Where idPessoa = @IDPESSOA AND idMedico = @IDMEDICO");

            return command.ToString();
        }

        public string EditarUsuario(EditarUsuarioModel usuarioModel) {
            StringBuilder command = new StringBuilder();
            Boolean flagSet = false;

            command.AppendLine("Update usuario");

            if (usuarioModel.usuario.Username != null) {
                if (flagSet)
                    command.AppendLine("       usuario = @USUARIO,");
                else {
                    command.AppendLine("Set    usuario = @USUARIO,");
                    flagSet = true;
                }
            }

            if (usuarioModel.usuario.Password != null) {
                if (flagSet)
                    command.AppendLine("       senha = @SENHA,");
                else {
                    command.AppendLine("Set    senha = @SENHA,");
                    flagSet = true;
                }
            }

            if (usuarioModel.usuario.TipoUsuario != null)
            {
                if (flagSet)
                    command.AppendLine("       tipoUsuario = @TIPOUSUARIO,");
                else {
                    command.AppendLine("Set    tipoUsuario = @TIPOUSUARIO,");
                    flagSet = true;
                }
            }

            if (usuarioModel.usuario.statusDesativado != 0) {
                if (flagSet)
                    command.AppendLine("       statusDesativacao = @STATUSDESATIVACAO,");
                else {
                    command.AppendLine("Set    statusDesativacao = @STATUSDESATIVACAO,");
                    flagSet = true;
                }
            }

            command = new StringBuilder(command.ToString().Remove(command.Length - 3, 3));

            command.AppendLine(" Where idUsuario = @IDUSUARIO AND idPessoaUsuario = @IDPESSOA");
            return command.ToString();
        }

        public string EditarPermissoes(EditarUsuarioModel usuarioModel) {
            StringBuilder command = new StringBuilder();
            command.AppendLine("Update permissoes");
            command.AppendLine("Set    flUsuarioI = @FLUSUARIOI,");
            command.AppendLine("       flUsuarioC = @FLUSUARIOC,");
            command.AppendLine("       flUsuarioA = @FLUSUARIOA,");
            command.AppendLine("       flUsuarioE = @FLUSUARIOE,");

            command.AppendLine("       flPacienteI = @FLPACIENTEI,");
            command.AppendLine("       flPacienteC = @FLPACIENTEC,");
            command.AppendLine("       flPacienteA = @FLPACIENTEA,");
            command.AppendLine("       flPacienteE = @FLPACIENTEE,");

            command.AppendLine("       flConsultaI = @FLCONSULTAI,");
            command.AppendLine("       flConsultaC = @FLCONSULTAC,");
            command.AppendLine("       flConsultaA = @FLCONSULTAA,");
            command.AppendLine("       flConsultaE = @FLCONSULTAE,");

            command.AppendLine("       flAusenciaI = @FLAUSENCIAI,");
            command.AppendLine("       flAusenciaC = @FLAUSENCIAC,");
            command.AppendLine("       flAusenciaA = @FLAUSENCIAA,");
            command.AppendLine("       flAusenciaE = @FLAUSENCIAE,");

            command.AppendLine("       flMedicamentoI = @FLMEDICAMENTOI,");
            command.AppendLine("       flMedicamentoC = @FLMEDICAMENTOC,");
            command.AppendLine("       flMedicamentoA = @FLMEDICAMENTOA,");
            command.AppendLine("       flMedicamentoE = @FLMEDICAMENTOE,");

            command.AppendLine("       flExamesI = @FLEXAMESI,");
            command.AppendLine("       flExamesC = @FLEXAMESC,");
            command.AppendLine("       flExamesA = @FLEXAMESA,");
            command.AppendLine("       flExamesE = @FLEXAMESE,");

            command.AppendLine("       flHistoriaMolestiaAtualI = @FLHISTORIAMOLESTIAATUALI,");
            command.AppendLine("       flHistoriaMolestiaAtualC = @FLHISTORIAMOLESTIAATUALC,");
            command.AppendLine("       flHistoriaMolestiaAtualA = @FLHISTORIAMOLESTIAATUALA,");
            command.AppendLine("       flHistoriaMolestiaAtualE = @FLHISTORIAMOLESTIAATUALE,");

            command.AppendLine("       flHistoriaPatologicaPregressaI = @FLHISTORIAPATOLOGICAPREGRESSAI,");
            command.AppendLine("       flHistoriaPatologicaPregressaC = @FLHISTORIAPATOLOGICAPREGRESSAC,");
            command.AppendLine("       flHistoriaPatologicaPregressaA = @FLHISTORIAPATOLOGICAPREGRESSAA,");
            command.AppendLine("       flHistoriaPatologicaPregressaE = @FLHISTORIAPATOLOGICAPREGRESSAE,");

            command.AppendLine("       flHipoteseDiagnosticaI = @FLHIPOTESEDIAGNOSTICAI,");
            command.AppendLine("       flHipoteseDiagnosticaC = @FLHIPOTESEDIAGNOSTICAC,");
            command.AppendLine("       flHipoteseDiagnosticaA = @FLHIPOTESEDIAGNOSTICAA,");
            command.AppendLine("       flHipoteseDiagnosticaE = @FLHIPOTESEDIAGNOSTICAE,");

            command.AppendLine("       flCondutaI = @FLCONDUTAI,");
            command.AppendLine("       flCondutaC = @FLCONDUTAC,");
            command.AppendLine("       flCondutaA = @FLCONDUTAA,");
            command.AppendLine("       flCondutaE = @FLCONDUTAE,");

            command.AppendLine("       flIniciarAtendimento = @FLINICIARATENDIMENTO");
            command.AppendLine("Where idPermissoes = @IDPERMISSOES AND idUsuarioPermissoes = @IDUSUARIO");

            return command.ToString();
        }

    }
}
