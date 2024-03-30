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
    internal class RemoverProdutoPedidoComand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (vm.ProdutoSelecionado.Descricao == null)
            {
                MessageBox.Show("Selecione um produto para remover.", "Atenção");
                return;
            }

            if (vm.Pedido.Produtos.Remove(vm.ProdutoSelecionado))
            {
                vm.Pedido.Total -= vm.ProdutoSelecionado.Preco;
            }
            else
            {
                MessageBox.Show("O produto selecionado não está no pedido atual.", "Atenção");
            }
        }
    }
}