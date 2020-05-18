using DonaldsonMotors.Models;
using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace DonaldsonMotors.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account", null);
            }
        }

        public ActionResult ActiveBookings()
        {
            if (User.Identity.IsAuthenticated)
            {
                string id = User.Identity.GetUserId();

                List<Booking> allCustBookings = context.Bookings.Where(b => b.CustId == id).Include(b => b.Vehicle).ToList();

                List<Booking> activeCustBookings = new List<Booking>();

                foreach(Booking b in allCustBookings)
                {
                   if(b.Complete == false)
                    {
                        activeCustBookings.Add(b);
                    }
                } 

                return View(activeCustBookings);
            }
            else
            {
                return RedirectToAction("Login", "Account", null);
            }
        }

        public ActionResult PastBookings()
        {
            if (User.Identity.IsAuthenticated)
            {
                string id = User.Identity.GetUserId();

                List<Booking> allCustBookings = context.Bookings.Where(b => b.CustId == id).Include(b => b.Vehicle).ToList();

                List<Booking> activeCustBookings = new List<Booking>();

                foreach (Booking b in allCustBookings)
                {
                    if (b.Complete == true)
                    {
                        activeCustBookings.Add(b);
                    }
                }

                return View(activeCustBookings);
            }
            else
            {
                return RedirectToAction("Login", "Account", null);
            }
        }

        public ActionResult GetPDF ()
        {
            return View();
        }
    }
}