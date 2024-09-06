using Projeto_EficienciaXTemperatura.Common;
using Projeto_EficienciaXTemperatura.Model;
using RestSharp;
using System.Text.Json;

namespace Projeto_EficienciaXTemperatura.Services;

public class TemperaturaServices
{
    private readonly string _apiKey;
    private readonly RestClient _client;

    public TemperaturaServices(string apiKey)
    {
        _apiKey = apiKey;
        _client = new RestClient("https://api.openweathermap.org/data/2.5/");
    }

    public ResultadoOperacaoComConteudo<Temperatura> ConsultarTemperatura(double lat, double lon)
    {
        var request = new RestRequest($"weather?lat={lat}&lon={lon}&appid={_apiKey}&units=metric", Method.Get);
        var response = _client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(response.Content!);
            var valorTemperatura = jsonResponse.GetProperty("main").GetProperty("temp").GetDecimal();

            var objTemperatura = new Temperatura { Valor = valorTemperatura, DataHoraConsulta = DateTime.Now };

            return new ResultadoOperacaoComConteudo<Temperatura>() { Sucesso = true, MensagemErro = "Ok", Conteudo = objTemperatura };
        }
        else
        {
            return new ResultadoOperacaoComConteudo<Temperatura>() { Sucesso = false, MensagemErro = "Erro ao realizar a consulta", Conteudo = null};
        }
    }
}
