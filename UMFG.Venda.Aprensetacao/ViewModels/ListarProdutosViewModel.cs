using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Comandos;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.ViewModels
{
    internal sealed class ListarProdutosViewModel : AbstractViewModel
    {
        private const string C_DESCRICAO = "Sed sed enim vehicula, " +
            "placerat enim ac, rutrum augue. Fusce tristique lacus " +
            "tempus mattis convallis. Duis ac ultrices ex, " +
            "sed ullamcorper leo. Etiam cursus consectetur sodales. " +
            "Suspendisse congue nibh sed vestibulum interdum." +
            " Duis convallis mauris sit amet justo fermentum aliquam." +
            " Vestibulum congue pretium pharetra. Donec laoreet risus eu mattis " +
            "congue. Pellentesque pulvinar finibus sagittis. Aliquam turpis ante," +
            " luctus et magna quis, feugiat facilisis augue. Curabitur rutrum" +
            " lorem at bibendum pellentesque. Nullam rhoncus, augue id imperdiet" +
            " aliquam, nibh nisl gravida felis, interdum sagittis lacus augue" +
            " non neque. Orci varius natoque penatibus et magnis dis parturient" +
            " montes, nascetur ridiculus mus.";

        private ProdutoModel _produtoSelecionado = new ProdutoModel();

        private ObservableCollection <ProdutoModel> _produtos 
            = new ObservableCollection<ProdutoModel>();

        private PedidoModel _pedido = new PedidoModel();

        public ProdutoModel ProdutoSelecionado
        {
            get => _produtoSelecionado;
            set => SetField (ref _produtoSelecionado, value);
        }

        public ObservableCollection <ProdutoModel> Produtos
        {
            get => _produtos;
            set => SetField(ref _produtos, value);
        }

        public PedidoModel Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public AdicionarProdutoPedidoComand Adicionar { get; private set; }
            = new AdicionarProdutoPedidoComand();

        public ReceberPedidoCommand Receber { get; private set;  }
            = new ReceberPedidoCommand();

        public RemoverProdutoPedidoComand Remover { get; private set; } = new RemoverProdutoPedidoComand();

        public ListarProdutosViewModel(UserControl userControl, IObserver observer)
            :base("Lista de Produtos")
        {
            UserControl = userControl;
            MainUserControl = observer;

            Add(observer);

            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            Produtos.Clear();

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net7.0-windows\Imagens\batata.png", UriKind.Relative)),
                Referencia = "Batata", 
                Descricao = C_DESCRICAO,
                Preco = 10.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net7.0-windows\Imagens\combo.png", UriKind.Relative)),
                Referencia = "Combo",
                Descricao = C_DESCRICAO,
                Preco = 45.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net7.0-windows\Imagens\lanche.png", UriKind.Relative)),
                Referencia = "Lanche",
                Descricao = C_DESCRICAO,
                Preco = 22.90m,
            });

            Produtos.Add(new ProdutoModel()
            {
                Imagem = new BitmapImage(
                    new Uri(@"..\net7.0-windows\Imagens\refrigerante.png", UriKind.Relative)),
                Referencia = "Refrigerante",
                Descricao = C_DESCRICAO,
                Preco = 7.50m,
            });

        }
    }
}
