using AutoMapper;
using QT2247A2.Data;
using QT2247A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-81a99c06-96a9-42cc-add9-c58183c471aa
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace QT2247A2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track,TrackWithDetailViewModel>();
                cfg.CreateMap<Invoice,InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
                cfg.CreateMap<InvoiceLine,InvoiceLineWithDetailViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        // ############################################################
        // Tracks

        // “get all” method sorted in ascending order by track Name.
        public IEnumerable<TrackWithDetailViewModel> TrackGetAll()
        {
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(ds.Tracks.Include("Album").Include("Genre").OrderBy(t => t.Name));
        }

        // Filter where GenreId is 2 or 6 and sort in ascending order by genre Name then by track Name.
        public IEnumerable<TrackWithDetailViewModel> TrackGetBluesJazz()
        {
            var tracks = ds.Tracks.Include("Album").Include("Genre").Where(t => t.GenreId == 2 || t.GenreId == 6).OrderBy(t => t.Genre.Name).ThenBy(t=>t.Name);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
        }

        // Filter where the Composer contains the string “Jerry Cantrell” and contains the string “Layne Staley”. Sort the tracks in ascending order by Composer then by track Name.
        public IEnumerable<TrackWithDetailViewModel> TrackGetCantrellStaley()
        {
            var tracks=ds.Tracks.Include("Album").Include("Genre").Where(t=>t.Composer.Contains("Jerry Cantrell") && t.Composer.Contains("Layne Staley")).OrderBy(t=>t.Composer).ThenBy(t=>t.Name);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
        }

        // Display the 50 longest tracks based on the Milliseconds property. Sort the tracks in ascending order by track Name.
        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Longest()
        {
            var tracks=ds.Tracks.Include("Album").Include("Genre").OrderByDescending(t=>t.Milliseconds).ThenBy(t=>t.Name).Take(50);
            
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
        }

        // Display the 50 smallest tracks based on the Bytes property. Sort the tracks in ascending order by track Name.
        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Smallest()
        {
            var tracks = ds.Tracks.Include("Album").Include("Genre").OrderBy(t => t.Bytes).ThenBy(t => t.Name).Take(50);

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
        }

        // ############################################################
        // Invoice

        // InvoiceGetAll() – Return a collection of InvoiceBaseViewModel classes sorted by InvoiceDate in descending order.
        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
        {
            var invoices = ds.Invoices.OrderByDescending(t => t.InvoiceDate);
            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(invoices);
        }

        // InvoiceGetByIdWithDetail() – Return an InvoiceWithDetailViewModel for the Invoice with the specified ID.
        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int id)
        {
            var invoice=ds.Invoices.Include("Customer.Employee").Include("InvoiceLines").Include("InvoiceLines.Track").Include("InvoiceLines.Track.Album").Include("InvoiceLines.Track.Album.Artist").Include("InvoiceLines.Track.Genre").Include("InvoiceLines.Track.MediaType").SingleOrDefault(t=>t.InvoiceId== id);

            return(invoice==null)?null:mapper.Map<Invoice,InvoiceWithDetailViewModel>(invoice);
        }
    }
}