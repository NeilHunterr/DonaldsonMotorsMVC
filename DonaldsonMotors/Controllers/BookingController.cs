using DonaldsonMotors.Models;
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

        public ActionResult CheckAvalability()
        {
            return View();
        }

        public ActionResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEvents();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<Event> GetEvents()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Booking> allBookings = context.Bookings.ToList();

            List<Event> eventList = new List<Event>();

            DateTime currentDate = DateTime.Now;

            DateTime loopDate = currentDate;
            
            do
            {
                int hour = 0;

                do
                {

                    hour = hour + 1;

                } while (hour <= 9);

                loopDate = loopDate.AddDays(1);

            } while (loopDate == currentDate.AddDays(21));

            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}