using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Alpha_Immobilier_Project.Models;
using WebApplication1.Models;

namespace Alpha_Immobilier_Project.Controllers
{
    public class ListingsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Listings
        public ActionResult Index()
        {
            var listings = _db.Listings.Include(l => l.Category);
            return View(listings.ToList());
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = _db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.City = new SelectList(new[] { "Casablanca", "Agadir", "Al Hoceima", "Béni Mellal", "El Jadida", "Errachidia", "Fès", "Kénitra", "Khénifra", "Khouribga", "Larache", "Marrakech", "Meknès", "Nador", "Ouarzazate", "Oujda", "Rabat", "Safi", "Settat", "Salé", "Tanger", "Taza", "Tétouan", "laayoune", "Dakhla" }); 
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "CategoryName");
            ViewBag.TypeListingId = new SelectList(_db.TypeListings, "Id", "Type");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Listing listing , HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                listing.imageListing = upload.FileName;
                _db.Listings.Add(listing);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.City = new SelectList(new[] { "Casablanca", "Agadir", "Al Hoceima", "Béni Mellal", "El Jadida", "Errachidia", "Fès", "Kénitra", "Khénifra", "Khouribga", "Larache", "Marrakech", "Meknès", "Nador", "Ouarzazate", "Oujda", "Rabat", "Safi", "Settat", "Salé", "Tanger", "Taza", "Tétouan", "laayoune", "Dakhla" });
            ViewBag.TypeListingId = new SelectList(_db.TypeListings, "Id", "type", listing.TypeListingId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "CategoryName", listing.CategoryId);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = _db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeListingId = new SelectList(_db.TypeListings, "Id", "type", listing.TypeListingId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "CategoryName", listing.CategoryId);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,DescListing,imageListing,PrixListing,CityListing,AdressListing,NbrChambre,NbrBath,NbrBed,size,CategoryId,TypeId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(listing).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeListingId = new SelectList(_db.TypeListings, "Id", "type", listing.TypeListingId);
            ViewBag.CategoryId = new SelectList(_db.Categories, "Id", "CategoryName", listing.CategoryId);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = _db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = _db.Listings.Find(id);
            _db.Listings.Remove(listing);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
