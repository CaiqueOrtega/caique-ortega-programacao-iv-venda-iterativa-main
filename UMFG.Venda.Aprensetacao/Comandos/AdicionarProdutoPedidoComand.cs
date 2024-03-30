using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.Comandos
{
    internal sealed class AdicionarProdutoPedidoComand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (string.IsNullOrWhiteSpace(vm.ProdutoSelecionado.Descricao))
            {
                MessageBox.Show("Selecione um produto para adicionar.");
                return;
            }

            vm.Pedido.Produtos.Add(vm.ProdutoSelecionado);
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Preco);

        }
    }
}
