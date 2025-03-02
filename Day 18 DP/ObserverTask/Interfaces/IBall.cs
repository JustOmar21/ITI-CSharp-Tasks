using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTask.Interfaces
{
    public abstract class IBall
    {
        protected List<IObserver> Observers = new List<IObserver>();

        public abstract void AttachObserver(IObserver observer);
        public abstract void DeattachObserver(IObserver observer);
        public abstract void NotifyObserver();
    }
}
