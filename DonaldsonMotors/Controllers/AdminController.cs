using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using DonaldsonMotors.Models;
using Rotativa;

namespace DonaldsonMotors.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            if(User.Identity.IsAuthenticated)
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
                List<Booking> allBookings = context.Bookings.Include(b => b.Customer).Include(b => b.Staff).ToList();

                List<Booking> activeBookings = new List<Booking>();

                foreach (Booking b in allBookings)
                {
                    if (b.Complete == false)
                    {
                        activeBookings.Add(b);
                    }
                }

                return View(activeBookings);
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
                List<Booking> allBookings = context.Bookings.Include(b => b.Customer).Include(b => b.Staff).ToList();

                List<Booking> activeBookings = new List<Booking>();

                foreach (Booking b in allBookings)
                {
                    if (b.Complete == true)
                    {
                        activeBookings.Add(b);
                    }
                }

                return View(activeBookings);
            }
            else
            {
                return RedirectToAction("Login", "Account", null);
            }
        }

        public ActionResult GetActivePDF()
        {
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();

            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }

            return new ActionAsPdf("ActiveBookings")
            {
                FileName = "ActiveBookings.pdf",
                Cookies = cookieCollection

            };  
        }

        public ActionResult GetPastPDF()
        {
            Dictionary<string, string> cookieCollection = new Dictionary<string, string>();

            foreach (var key in Request.Cookies.AllKeys)
            {
                cookieCollection.Add(key, Request.Cookies.Get(key).Value);
            }

            return new ActionAsPdf("PastBookings")
            {
                FileName = "PastBookings.pdf",
                Cookies = cookieCollection

            };
        }
    }
}