using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DonaldsonMotors.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CheckAvalability()
        {
            return View();
        }

        public ActionResult CheckAvalability(DateTime date)
        {
            List<Slot> slots = new List<Slot>();

            return View(slots);
        }

        public List<Slot> GetSlotsList()
        {
            List<Slot> slots = new List<Slot>();

            return slots;
        }
    }
}