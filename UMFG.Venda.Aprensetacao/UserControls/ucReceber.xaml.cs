using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.UserControls
{
    /// <summary>
    /// Interação lógica para ucReceber.xam
    /// </summary>
    public partial class ucReceber : UserControl
    {
            private IObserver observer;

            private ucReceber(IObserver observer, PedidoModel pedido)
            {
                InitializeComponent();
                this.observer = observer;
                DataContext = new ReceberViewModel(this, observer, pedido);
            }

            internal static PedidoModel Exibir(IObserver observer,
                PedidoModel pedido)
            {
                var tela = new ucReceber(observer, pedido);
                var vm = tela.DataContext as ReceberViewModel;

                vm.Notify();
                return vm.Pedido;
            }


        private void VerificarDados(object sender, RoutedEventArgs e)
        {
            string data = this.data.Text;
            string numeroCartao = this.numeroCartao.Text;
            string cvv = this.cvv.Text;
            string nomeTitular = this.nomeTitular.Text;

           
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(numeroCartao) || string.IsNullOrWhiteSpace(cvv) || string.IsNullOrWhiteSpace(nomeTitular))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Atenção");
                return;
            }

            bool tipoCartaoSelecionado = (bool)credito.IsChecked || (bool)debito.IsChecked;

            if (!tipoCartaoSelecionado)
            {
                MessageBox.Show("Selecione o tipo de cartão (Crédito ou Débito).", "Erro");
                return;
            }

            
            bool dataValida = DateTime.TryParseExact(data, "MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida) && dataConvertida >= DateTime.Today;
            bool cvvValido = int.TryParse(cvv, out int _) && cvv.Length == 3;
            bool cartaoValido = numeroCartao.Length == 16 && long.TryParse(numeroCartao, out long _);

            if (dataValida && cvvValido && cartaoValido)
            {
                MessageBox.Show("Pagamento realizado", "Sucesso");
                ucListarProdutos.Exibir(observer);
            }
            else
            {
                StringBuilder mensagemErro = new StringBuilder("Verifique os seguintes problemas:\n");
                if (!dataValida)
                    mensagemErro.AppendLine(" - Data inválida ou vencida");
                if (!cvvValido)
                    mensagemErro.AppendLine(" - CVV inválido, deve conter apenas 3 dígitos numéricos");
                if (!cartaoValido)
                    mensagemErro.AppendLine(" - Número do cartão inválido, deve conter exatamente 16 dígitos numéricos");

                MessageBox.Show(mensagemErro.ToString(), "Erro");
            }
        }



    }
}
