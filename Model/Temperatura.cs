namespace Projeto_EficienciaXTemperatura.Model
{
    public class Temperatura
    {
        public decimal Valor { get; set; }
        public DateTime DataHoraConsulta { get; set; } = DateTime.Now;
    }
}
