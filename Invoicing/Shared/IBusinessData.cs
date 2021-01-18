using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Invoice> AllInvoices { get; }
        decimal CA { get; }
        decimal Apayer { get; }

        public void Add(Invoice newInvoice);
    }
}
