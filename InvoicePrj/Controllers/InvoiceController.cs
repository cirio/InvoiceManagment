using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using InvoicePrj.Models;
namespace InvoicePrj.Controllers
{
    public class InvoiceController : ApiController
    {
        
        static readonly IInvoiceRepository repository = new InvoiceRepository();

        #region Get
        public IEnumerable<Invoice> GetAllInvoices()
        {
            return repository.GetAll();
        }
        public Invoice GetInvoice(int id)
        {
            Invoice item = repository.Get(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return item;
        }
        public int GetMaxInvoice()
        {
            int maxInvoice = repository.GetMax();
            return maxInvoice +1;
        }
        public double GetGAmountTot()
        {
            return repository.GetGAmountTot();
        }
        public double GetNAmountTot()
        {
            return repository.GetNAmountTot();
        }
        public double GetTaxTot()
        {
            return repository.GetTaxTot();
        }
        #endregion
        #region Delete
        [System.Web.Http.AcceptVerbs("DELETE","GET")]
        public HttpResponseMessage DeleteInvoice(int id)
        {
            repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        #endregion
        #region Insert
        [System.Web.Http.AcceptVerbs("INSERT", "POST")]
        public HttpResponseMessage InsertInvoice(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                //Set Net Amount
                invoice.netAmount = Math.Round(invoice.grossAmount - (invoice.grossAmount / 100 * invoice.supplementaryContribution),2);
                
                repository.Add(invoice);
                
                var response = Request.CreateResponse<Invoice>(HttpStatusCode.Created, invoice);
                string uri = Url.Route(null, new { id = invoice.id });
                response.Headers.Location = new Uri(Request.RequestUri, uri);
                return response;
                
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        #endregion

    }
}
