using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoicePrj.Models
{
    public class InvoiceContext: DbContext
    {
        public InvoiceContext() : base("name=InvoiceContext") { }
        public DbSet<Invoice> Invoice { get; set; }
        
    }
}