using Projeto_EficienciaXTemperatura.Common;
using Projeto_EficienciaXTemperatura.Model;
using System.Data.SqlClient;

namespace Projeto_EficienciaXTemperatura.Services
{
    public class MovimentacaoServices
    {

        public ResultadoOperacao RegistraMovimentacao(Maquina maquina, Temperatura temperatura, Eficiencia eficiencia)
        {
            string queryMaquina = "INSERT INTO TemperaturaXEficiencia (MaquinaId, Valor, DataHoraConsulta, Eficiencia) " +
                                  "VALUES (@MaquinaId, @Valor, @DataHoraConsulta, @Eficiencia);";

            using (SqlConnection con = new SqlConnection(DatabaseConnectionString.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdMaquina = new SqlCommand(queryMaquina, con);
                    cmdMaquina.Parameters.AddWithValue("@MaquinaId", maquina.Id);
                    cmdMaquina.Parameters.AddWithValue("@Valor", temperatura.Valor);
                    cmdMaquina.Parameters.AddWithValue("@DataHoraConsulta", temperatura.DataHoraConsulta);
                    cmdMaquina.Parameters.AddWithValue("@Eficiencia", eficiencia.Valor);

                    cmdMaquina.ExecuteNonQuery();

                    return new ResultadoOperacao { Sucesso = true, MensagemErro = "Movimentação registrada." };
                }
                catch (Exception ex)
                {
                    return new ResultadoOperacao { Sucesso = false, MensagemErro = ex.Message };
                }
            }
        }
    }
}
