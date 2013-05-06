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
            try
            {
                return repository.GetAll();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)); 
            }
            
        }
        public Invoice GetInvoice(int id)
        {
            try
            {
                Invoice item = repository.Get(id);
                if (item == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                return item;
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)); 
            }
            
        }
        public int GetMaxInvoice()
        {
            try
            {
                return Convert.ToInt32(repository.GetMax() + 1);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
            
        }
        public double GetGAmountTot()
        {
            try
            {
                return repository.GetGAmountTot();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
            
        }
        public double GetNAmountTot()
        {
            try
            {
                return repository.GetNAmountTot();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
            
        }
        public double GetTaxTot()
        {
            try
            {
                return repository.GetTaxTot();
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
            
        }
        #endregion
        #region Delete
        [System.Web.Http.AcceptVerbs("DELETE","GET")]
        public HttpResponseMessage DeleteInvoice(int id)
        {
            try
            {
                repository.Remove(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
            
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
