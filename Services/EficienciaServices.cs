using Projeto_EficienciaXTemperatura.Common;
using Projeto_EficienciaXTemperatura.Model;

namespace Projeto_EficienciaXTemperatura.Services
{
    public class EficienciaServices
    {
        public ResultadoOperacaoComConteudo<Eficiencia> CalcularEficiencia(Temperatura temperatura)
        {
            Eficiencia objEficiencia = new Eficiencia();
            if (temperatura.Valor >= 28)
            {
                objEficiencia.Valor = 100;
            }
            else if (temperatura.Valor >= 24)
            {
                objEficiencia.Valor = 75;
            }
            else
            {
                // Eficiencia sofre uma alteração de 6.25%/°C
                objEficiencia.Valor = 75 + ((temperatura.Valor - 24) * 25 / 4);
                if (objEficiencia.Valor <= 0)
                {
                    objEficiencia.Valor = 0;
                }
            }
            return new ResultadoOperacaoComConteudo<Eficiencia>() { Sucesso = true, MensagemErro = "Ok", Conteudo = objEficiencia};
        }
    }
}
