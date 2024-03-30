using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Globalization;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.UserControls
{
    public partial class ucReceber : UserControl
    {
        private IObserver observer;

        private ucReceber(IObserver observer, PedidoModel pedido)
        {
            InitializeComponent();
            this.observer = observer;
            DataContext = new ReceberViewModel(this, observer, pedido);
        }

        internal static PedidoModel Exibir(IObserver observer, PedidoModel pedido)
        {
            var tela = new ucReceber(observer, pedido);
            (tela.DataContext as ReceberViewModel)?.Notify();
            return (tela.DataContext as ReceberViewModel)?.Pedido;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox)?.Text.Length >= 3)
                e.Handled = true;
        }

        private void VerificarDados(object sender, RoutedEventArgs e)
        {
            string data = this.data.Text;
            string numeroCartao = this.numeroCartao.Text;
            string cvv = this.cvv.Text;

            bool dataValida = DateTime.TryParseExact(data, "MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataConvertida) && dataConvertida >= DateTime.Today;
            bool cvvValido = int.TryParse(cvv, out int _) && cvv.Length == 3;
            bool cartaoValido = long.TryParse(numeroCartao, out long _) && numeroCartao.Length == 16;

            if (cartaoValido && dataValida && cvvValido)
            {
                MessageBox.Show("Pagamento realizado", "Sucesso");
                ucListarProdutos.Exibir(observer);
            }
            else
            {
                MessageBox.Show("Verifique seus dados novamente", "Erro");
            }
        }
    }
}
