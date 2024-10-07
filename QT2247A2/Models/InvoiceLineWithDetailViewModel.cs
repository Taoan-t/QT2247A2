using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QT2247A2.Models
{
    public class InvoiceLineWithDetailViewModel:InvoiceLineBaseViewModel
    {  
        [Display(Name = "Name")]
        public string TrackName { get; set; }

        [Display(Name = "Composer(s)")]
        public string TrackComposer { get; set; }

        [Display(Name = "Album")]
        public string TrackAlbumTitle { get; set; }

        [Display(Name = "Artist")]
        public string TrackAlbumArtistName { get; set; }

        [Display(Name = "Genre")]
        public string TrackGenreName { get; set; }

        [Display(Name = "MediaType")]
        public string TrackMediaTypeName { get; set; }

    }
}