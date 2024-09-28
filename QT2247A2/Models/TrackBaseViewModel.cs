using QT2247A2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QT2247A2.Models
{
    public class TrackBaseViewModel
    {
        [Key]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name="Track Name")]
        public string Name { get; set; }

        [StringLength(220)]
        [Display(Name = "Composer Name(s)")]
        public string Composer { get; set; }

        [Display(Name = "Length(ms)")]
        public int Milliseconds { get; set; }

        [Display(Name = "Size(bytes)")]
        public int? Bytes { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal UnitPrice { get; set; }



    }
}