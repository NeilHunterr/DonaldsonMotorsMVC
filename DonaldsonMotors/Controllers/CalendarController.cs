using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DonaldsonMotors.Models;

namespace DonaldsonMotors.Controllers
{
    public class CalendarController : Controller
    {
        // GET: CalendarController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        public class Dpc : DayPilotCalendar
        {
            ApplicationDbContext context = new ApplicationDbContext();

            protected override void OnInit(InitArgs e)
            {
                UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

                DataIdField = "Id";
                DataStartField = "Start";
                DataEndField = DataStartField + 2;
                DataTextField = "Text";

                Events = from b in context.Bookings where (b.BookingDate <= VisibleStart) select b;
            }
        }
    }
}