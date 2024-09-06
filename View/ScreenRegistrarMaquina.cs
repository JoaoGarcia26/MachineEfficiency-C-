using Projeto_EficienciaXTemperatura.Services;

namespace Projeto_EficienciaXTemperatura.View
{
    public partial class ScreenRegistrarMaquina : Form
    {
        private MaquinaServices _maquinaServices;
        public ScreenRegistrarMaquina()
        {
            InitializeComponent();
            _maquinaServices = new MaquinaServices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultado = _maquinaServices.InserirMaquina(txtNomeMaquina.Text, decimal.Parse(txtLatitude.Text), decimal.Parse(txtLongitude.Text));
            
            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
