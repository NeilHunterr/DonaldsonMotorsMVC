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

        //public ActionResult GetCalendarData()
        //{
        //    // Initialization.  
        //    JsonResult result = new JsonResult();

        //    try
        //    {
        //        // Loading.  
        //        List<Event> data = this.GetEventsList();

        //        // Processing.  
        //        result = this.Json(data, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Info  
        //        Console.Write(ex);
        //    }

        //    // Return info.  
        //    return result;
        //}

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            start = DateTime.Now; 
            end = DateTime.Now;

            var events = new List<Event>();

            for (var i = 1; i <= 5; i++)
            {
                events.Add(new Event()
                {
                    id = i,
                    title = "Event " + i,
                    start = start.ToString(),
                    end = end.ToString(),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            //Get the events
            //You may get from the repository also
            //var eventList = GetEventsList();

            //var rows = eventList.ToArray();

            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

        //private List<Event> GetEventsList()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    List<Booking> allBookings = context.Bookings.ToList();

        //    List<Event> eventList = new List<Event>();

        //    DateTime currentDate = DateTime.Now;

            
        //}
    }
}