using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QT2247A2.Models
{
    public class InvoiceLineBaseViewModel
    {
        [Key]
        [Display (Name="Line ID")]
        public int InvoiceLineId { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Unit Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Line Total")]
        public decimal LinePrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }
    }
}