namespace Projeto_EficienciaXTemperatura.Model
{
    public class Maquina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Eficiencia? Eficiencia { get; set; }
        public Temperatura? Temperatura { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
