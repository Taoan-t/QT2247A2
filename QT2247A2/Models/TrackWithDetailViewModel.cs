using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace QT2247A2.Models
{
    public class TrackWithDetailViewModel:TrackBaseViewModel
    {
        [Display(Name = "Album")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Genre")]
        public string GenreName { get; set; }

    }
}