using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePrj.Models
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll();
        Invoice Get(int id);
        Invoice Add(Invoice item);
        void Remove(int id);
        int GetMax();
        double GetGAmountTot();
        double GetNAmountTot();
        double GetTaxTot();

    }
}
