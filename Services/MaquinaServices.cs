using Projeto_EficienciaXTemperatura.Common;
using Projeto_EficienciaXTemperatura.Model;
using System.Data.SqlClient;

namespace Projeto_EficienciaXTemperatura.Services
{
    public class MaquinaServices
    {
        private EficienciaServices _eficienciaServices;
        private TemperaturaServices _temperaturaServices;

        public MaquinaServices()
        {
            _eficienciaServices = new EficienciaServices();
            _temperaturaServices = new TemperaturaServices("294c916a82c72fb40f7facaff2c2e633");
        }
        public ResultadoOperacao InserirMaquina(string nome, decimal latitude, decimal longitude)
        {
            string queryMaquina = "INSERT INTO Maquina (Nome, Latitude, Longitude) " +
                                  "VALUES (@Nome, @Latitude, @Longitude);";

            using (SqlConnection con = new SqlConnection(DatabaseConnectionString.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdMaquina = new SqlCommand(queryMaquina, con);
                    cmdMaquina.Parameters.AddWithValue("@Nome", nome);
                    cmdMaquina.Parameters.AddWithValue("@Latitude", latitude);
                    cmdMaquina.Parameters.AddWithValue("@Longitude", longitude);

                    cmdMaquina.ExecuteNonQuery();

                    return new ResultadoOperacao { Sucesso = true, MensagemErro = "Maquina cadastrada com sucesso." };
                }
                catch (Exception ex)
                {
                    return new ResultadoOperacao { Sucesso = false, MensagemErro = ex.Message };
                }
            }
        }

        public ResultadoOperacaoComConteudo<List<Maquina>> CarregaMaquinas()
        {
            string query = "SELECT Id, Nome, Latitude, Longitude FROM Maquina";

            var maquinas = new List<Maquina>();

            using (SqlConnection con = new SqlConnection(DatabaseConnectionString.ConnectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        var maquina = new Maquina
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Latitude = Convert.ToDouble(reader["Latitude"]),
                            Longitude = Convert.ToDouble(reader["Longitude"]),
                        };

                        maquinas.Add(maquina);
                    }

                    reader.Close();

                    return new ResultadoOperacaoComConteudo<List<Maquina>> { Sucesso = true, Conteudo = maquinas };
                }
                catch (Exception ex)
                {
                    return new ResultadoOperacaoComConteudo<List<Maquina>> { Sucesso = false, MensagemErro = ex.Message };
                }
            }
        }

        public ResultadoOperacaoComConteudo<Maquina> AtualizaTempEfiMaquina(Maquina maquina)
        {
            var resultadoTemperatura = _temperaturaServices.ConsultarTemperatura(maquina.Latitude, maquina.Longitude);

            if (resultadoTemperatura.Sucesso)
            {
                var resultadoEficiencia = _eficienciaServices.CalcularEficiencia(resultadoTemperatura.Conteudo);

                if (resultadoEficiencia.Sucesso)
                {
                    maquina.Temperatura = resultadoTemperatura.Conteudo;
                    maquina.Eficiencia = resultadoEficiencia.Conteudo;

                    return new ResultadoOperacaoComConteudo<Maquina>() { Sucesso = true, MensagemErro = "OK", Conteudo = maquina};
                } else
                {
                    return new ResultadoOperacaoComConteudo<Maquina>() { Sucesso = false, MensagemErro = "Falha ao consultar eficiencia." };
                }

            } else
            {
                return new ResultadoOperacaoComConteudo<Maquina>() { Sucesso = false, MensagemErro = "Falha ao consultar temperatura."};
            }
        }
    }
}
