using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UMFG.Venda.Aprensetacao.Interfaces;

namespace UMFG.Venda.Aprensetacao.Classes
{
    internal abstract class AbstractViewModel : AbstractNotifyPropertyChange, ISubject
    {
        private readonly ICollection<IObserver> _observers = new List<IObserver>();
        private string _titulo = string.Empty;

        public string Titulo
        { 
            get => _titulo; 
            set => SetField(ref _titulo, value); 
        }

        public UserControl UserControl { get; protected set; }
        public IObserver MainUserControl { get; protected set; }

        protected AbstractViewModel(string titulo)
        {
            Titulo = titulo;
        }

        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
