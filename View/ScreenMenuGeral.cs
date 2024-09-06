using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using Projeto_EficienciaXTemperatura.Model;
using Projeto_EficienciaXTemperatura.Services;
using Projeto_EficienciaXTemperatura.View;
using System.Collections.ObjectModel;

namespace Projeto_EficienciaXTemperatura
{
    public partial class ScreenMenuGeral : Form
    {
        private MaquinaServices _maquinaServices;
        private System.Windows.Forms.Timer _timer;
        private ScreenRegistrarMaquina _registrarMaquina;
        private MovimentacaoServices _movimentacaoServices;
        public ScreenMenuGeral()
        {
            InitializeComponent();
            _maquinaServices = new MaquinaServices();
            _movimentacaoServices = new MovimentacaoServices();
            ConfiguraTimer();
        }

        public void ConfiguraTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 30000;  //30 segundos
            _timer.Tick += new EventHandler(timer1_Tick);
            _timer.Start();
        }

        private void ScreenMenuGeral_Load(object sender, EventArgs e)
        {
            CarregaGrafico();
            CarregaTabela();
        }

        private void CarregaTabela()
        {
            var resultado = _maquinaServices.CarregaMaquinas();

            listView1.Items.Clear();

            if (resultado.Sucesso)
            {
                foreach (var item in resultado.Conteudo)
                {
                    ListViewItem maquina = new ListViewItem(item.Nome);
                    var objAtualizado = _maquinaServices.AtualizaTempEfiMaquina(item);
                    maquina.SubItems.Add(objAtualizado.Conteudo.Eficiencia.Valor.ToString());
                    maquina.SubItems.Add(objAtualizado.Conteudo.Temperatura.Valor.ToString());

                    listView1.Items.Add(maquina);
                }
            }
            else
            {
                Console.WriteLine(resultado.MensagemErro);
            }
        }

        private void CarregaGrafico()
        {
            var listaMaquinasBd = _maquinaServices.CarregaMaquinas();
            List<Maquina> listaMaquinasAtualizadas = new List<Maquina>();

            foreach (var item in listaMaquinasBd.Conteudo)
            {
                var resultadoAtualizado = _maquinaServices.AtualizaTempEfiMaquina(item);
                listaMaquinasAtualizadas.Add(resultadoAtualizado.Conteudo);
            }

            var seriesList = cartesianChart1.Series.ToList();

            double tempoAtual = DateTime.Now.ToOADate();

            if (seriesList.Count == 0)
            {
                foreach (var maquina in listaMaquinasAtualizadas)
                {
                    if (maquina.Eficiencia != null)
                    {
                        var novaSerie = new LineSeries<ObservablePoint>
                        {
                            Values = new ObservableCollection<ObservablePoint>
                    {
                        new ObservablePoint(tempoAtual, (double)maquina.Eficiencia.Valor)
                    },
                            Fill = null,
                            Name = maquina.Nome
                        };

                        seriesList.Add(novaSerie);
                    }
                }
                cartesianChart1.Series = seriesList.ToArray();
            }
            else
            {
                for (int i = 0; i < listaMaquinasAtualizadas.Count; i++)
                {
                    var maquina = listaMaquinasAtualizadas[i];

                    if (i < seriesList.Count && maquina.Eficiencia != null)
                    {
                        var serieExistente = seriesList[i] as LineSeries<ObservablePoint>;
                        if (serieExistente != null && serieExistente.Values is ObservableCollection<ObservablePoint> values)
                        {
                            values.Add(new ObservablePoint(tempoAtual, (double)maquina.Eficiencia.Valor));
                        }
                    }
                }
                cartesianChart1.Series = seriesList.ToArray();
            }
            cartesianChart1.XAxes = new[]
            {
                new Axis
                {
                    Name = "Tempo",
                    LabelsRotation = 15,
                    Labeler = value => DateTime.FromOADate(value).ToString("HH:mm:ss"),
                    MinLimit = DateTime.Now.AddMinutes(-5).ToOADate(),
                    MaxLimit = tempoAtual
                }
            };
            cartesianChart1.YAxes = new[]
            {
                new Axis
                {
                    Name = "Eficiência",
                    Labeler = value => value.ToString("N1")
                }
            };
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            CarregaGrafico();
            RegistraMovimentacaoBD();
        }

        private void RegistraMovimentacaoBD()
        {
            var listaMaquinas = _maquinaServices.CarregaMaquinas();

            if (listaMaquinas.Conteudo == null)
            {
                return;
            }

            foreach (var item in listaMaquinas.Conteudo)
            {
                var maquina = _maquinaServices.AtualizaTempEfiMaquina(item);
                _movimentacaoServices.RegistraMovimentacao(maquina.Conteudo, maquina.Conteudo.Temperatura, maquina.Conteudo.Eficiencia);
            }
        }

        private void cadastrarNovaMaquinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_registrarMaquina == null || _registrarMaquina.IsDisposed)
            {
                _registrarMaquina = new ScreenRegistrarMaquina();
            }
            _registrarMaquina.ShowDialog();
        }

        private void ScreenMenuGeral_Activated(object sender, EventArgs e)
        {
            ScreenMenuGeral_Load(sender, e);
        }
    }
}