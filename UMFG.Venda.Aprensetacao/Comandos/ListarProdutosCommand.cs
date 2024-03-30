using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.UserControls;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.Comandos
{
    internal sealed class ListarProdutosCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {

            ucListarProdutos.Exibir(parameter as MainWindowViewModel);        
        }
    }
}
