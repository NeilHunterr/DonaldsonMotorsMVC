using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Calendar;
using DayPilot.Web.Mvc.Events.Month;
using DonaldsonMotors.Models;
using InitArgs = DayPilot.Web.Mvc.Events.Month.InitArgs;
using EventClickArgs = DayPilot.Web.Mvc.Events.Month.EventClickArgs;

namespace DonaldsonMotors.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpm().CallBack(this);
        }

        class Dpm : DayPilotMonth
        {
            protected override void OnInit(InitArgs e)
            {
                var db = new ApplicationDbContext();

                Events = from ev in db.Bookings select ev;

                DataIdField = "BookingId";
                DataTextField = "Book Now";
                DataStartField = "BookingDate";
                DataEndField = "BookingDate"; 

                Update();
            }

        }
    }
}