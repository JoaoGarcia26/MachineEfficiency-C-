namespace Projeto_EficienciaXTemperatura.Common
{
    public class ResultadoOperacaoComConteudo<T>
    {
        public bool Sucesso { get; set; }
        public string MensagemErro { get; set; }
        public T Conteudo { get; set; }
    }
}
