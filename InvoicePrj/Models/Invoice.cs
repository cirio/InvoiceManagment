using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InvoicePrj.Models
{
    public class Invoice
    {
        [Key]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Invoice Number")]
        public int invoiceNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Invoice Date")]
        public DateTime invoiceDate { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Gross Amount")]
        public double grossAmount { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "supp. Contribution")]
        public double supplementaryContribution { get; set; }
        
        [Display(Name = "Net Amount")]
        public double netAmount { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Customer")]
        public string customer { get; set; }
    }
}