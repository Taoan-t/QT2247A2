using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QT2247A2.Models
{
    public class InvoiceWithDetailViewModel:InvoiceBaseViewModel
    {
        // Initial the navigation property in the default constructor
        public InvoiceWithDetailViewModel() {
            InvoiceLines = new List<InvoiceLineWithDetailViewModel>();
        }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerState { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmployeeFirstName { get; set; }
        public string CustomerEmployeeLastName { get; set; }

        public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }
    }
}