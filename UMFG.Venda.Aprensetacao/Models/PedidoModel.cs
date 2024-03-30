using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.Venda.Aprensetacao.Classes;

namespace UMFG.Venda.Aprensetacao.Models
{
    internal sealed class PedidoModel : AbstractModel
    {
        private ObservableCollection <ProdutoModel> _produtos
            = new ObservableCollection <ProdutoModel> ();

        private decimal _total;

        public ObservableCollection<ProdutoModel> Produtos
        {
            get => _produtos;
            set => SetField(ref _produtos, value);
        }

        public decimal Total
        {
            get => _total;
            set => SetField(ref _total, value);
        }

    }
}
