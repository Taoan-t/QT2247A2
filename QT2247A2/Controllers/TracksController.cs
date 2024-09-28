using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QT2247A2.Controllers
{
    public class TracksController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        public ActionResult BluesJazz()
        {
            return View("Index", m.TrackGetBluesJazz());
        }

        public ActionResult CantrellStaley()
        {
            return View("Index", m.TrackGetCantrellStaley());
        }

        public ActionResult Top50Longest()
        {
            return View("Index", m.TrackGetTop50Longest());
        }

        public ActionResult Top50Smallest()
        {
            return View("Index", m.TrackGetTop50Smallest());
        }

        // GET: Tracks/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Tracks/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Tracks/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Tracks/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Tracks/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Tracks/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Tracks/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
