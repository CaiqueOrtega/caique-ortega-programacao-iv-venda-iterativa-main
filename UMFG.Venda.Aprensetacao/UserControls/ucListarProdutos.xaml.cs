using System;
using System.Collections.Generic;
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
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.UserControls
{
    /// <summary>
    /// Interação lógica para ucListarProdutos.xam
    /// </summary>
    public partial class ucListarProdutos : UserControl
    {
        private ucListarProdutos(IObserver observer)
        {
            InitializeComponent();
            DataContext = new ListarProdutosViewModel(this,observer);
        }

        internal static void Exibir(IObserver observer)
        {
            (new ucListarProdutos(observer).DataContext as ListarProdutosViewModel).Notify();
        }
    }
}
