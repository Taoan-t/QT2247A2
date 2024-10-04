using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QT2247A2.Models
{
    public class InvoiceBaseViewModel
    {
        [Key]
        public int InvoiceId { get; set; }

        [Display(Name="Customer")]
        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        [Display(Name = "Billing Address")]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [StringLength(40)]
        [Display(Name = "State")]
        public string BillingState { get; set; }

        [StringLength(40)]
        [Display(Name = "Country")]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal/Zip")]
        public string BillingPostalCode { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Total { get; set; }
    }
}