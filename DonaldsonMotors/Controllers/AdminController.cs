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

//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin

        /// <summary>
        /// ActionResult of adminpage
        /// </summary>
        /// <returns>adminpage view</returns>
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

        /// <summary>
        /// A Actionresult to get active bookings
        /// </summary>
        /// <returns>A view populated with all active bookings</returns>
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

        /// <summary>
        /// a view to see all past bookings
        /// </summary>
        /// <returns>a view populated with all past bookings</returns>
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

        /// <summary>
        /// convert a view into a downloadable pdf 
        /// </summary>
        /// <returns>an actionaspdf and a download</returns>
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

        /// <summary>
        /// convert all past bookings to pdf
        /// </summary>
        /// <returns>actionaspdf and download</returns>
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