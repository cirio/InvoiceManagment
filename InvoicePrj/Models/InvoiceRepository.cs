using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace InvoicePrj.Models
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private InvoiceContext db = new InvoiceContext();
        public IEnumerable<Invoice> GetAll()
        {
            return db.Invoice.AsEnumerable();
        }
        public Invoice Get(int id)
        {
            return db.Invoice.Find(id);
        }
        public Invoice Add(Invoice item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            db.Invoice.Add(item);
            db.SaveChanges();
            return item;

        }
        public void Remove(int id)
        {
            if (id <= 0)
	            throw new ArgumentNullException("id");

            Invoice invoice = db.Invoice.Find(id);
            db.Invoice.Remove(invoice);
            db.SaveChanges();
        }
        public int GetMax()
        {
            return db.Invoice.Max(u => (int?)u.invoiceNumber) ?? 0;
        }
        public double GetGAmountTot()
        {
            return Math.Round(db.Invoice.Sum(u => (double?)u.grossAmount)?? 0,2);
        }
        public double GetNAmountTot()
        {
            return Math.Round(db.Invoice.Sum(u => (double?)u.netAmount) ?? 0, 2);
        }
        public double GetTaxTot()
        {
            double gamount = db.Invoice.Sum(u => (double?)u.grossAmount) ?? 0;
            double namount = db.Invoice.Sum(u => (double?)u.netAmount) ?? 0;
            if (gamount != 0 && namount != 0)
                return Math.Round(gamount - namount, 2);
            else
                return 0;
        }

    }
}