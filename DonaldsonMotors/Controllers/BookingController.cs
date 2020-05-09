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

        public ActionResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEventsList();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<Event> GetEventsList()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Booking> allBookings = context.Bookings.ToList();

            List<Event> eventList = new List<Event>();

            DateTime currentDate = DateTime.Now;

            DateTime loopDate = currentDate;
            
            do
            {
                int counter = 0;

                foreach(Booking b in allBookings)
                {
                    if(b.BookingDate == loopDate)
                    {
                        Event e = new Event()
                        {
                            date = b.BookingDate,
                            start = b.BookingDate.Hour,
                            end = b.BookingDate.Hour + 1,
                            title = "Unavailable"
                        };

                        eventList.Add(e);

                        counter = counter + 1;
                    }
                }

                if(counter < 4)
                {
                    foreach(Event e in eventList)
                    {
                        if(e.date == loopDate)
                        {
                            if(e.date.Hour == 9)
                            {
                                Event ev = new Event()
                                {
                                    date = e.date,
                                    start = 11,
                                    end =  12,
                                    title = "Book Now"
                                };

                                eventList.Add(ev);

                                Event ev1 = new Event()
                                {
                                    date = e.date,
                                    start = 13,
                                    end = 14,
                                    title = "Book Now"
                                };

                                eventList.Add(ev1);

                                Event ev2 = new Event()
                                {
                                    date = e.date,
                                    start = 15,
                                    end = 16,
                                    title = "Book Now"
                                };

                                eventList.Add(ev2);
                            }
                            else if(e.date.Hour == 11)
                            {
                                Event ev3 = new Event()
                                {
                                    date = e.date,
                                    start = 9,
                                    end = 10,
                                    title = "Book Now"
                                };

                                eventList.Add(ev3);

                                Event ev4 = new Event()
                                {
                                    date = e.date,
                                    start = 13,
                                    end = 14,
                                    title = "Book Now"
                                };

                                eventList.Add(ev4);

                                Event ev5 = new Event()
                                {
                                    date = e.date,
                                    start = 15,
                                    end = 16,
                                    title = "Book Now"
                                };

                                eventList.Add(ev5);
                            }
                            else if(e.date.Hour == 13)
                            {
                                Event ev6 = new Event()
                                {
                                    date = e.date,
                                    start = 9,
                                    end = 10,
                                    title = "Book Now"
                                };

                                eventList.Add(ev6);

                                Event ev7 = new Event()
                                {
                                    date = e.date,
                                    start = 11,
                                    end = 12,
                                    title = "Book Now"
                                };

                                eventList.Add(ev7);

                                Event ev8 = new Event()
                                {
                                    date = e.date,
                                    start = 15,
                                    end = 16,
                                    title = "Book Now"
                                };

                                eventList.Add(ev8);
                            }
                            else if(e.date.Hour == 15)
                            {
                                Event ev9 = new Event()
                                {
                                    date = e.date,
                                    start = 9,
                                    end = 10,
                                    title = "Book Now"
                                };

                                eventList.Add(ev9);

                                Event ev10 = new Event()
                                {
                                    date = e.date,
                                    start = 11,
                                    end = 12,
                                    title = "Book Now"
                                };

                                eventList.Add(ev10);

                                Event ev11 = new Event()
                                {
                                    date = e.date,
                                    start = 13,
                                    end = 15,
                                    title = "Book Now"
                                };

                                eventList.Add(ev11);
                            }
                        }
                    }
                }
                else if(counter == 0)
                {
                    Event ev12 = new Event()
                    {
                        date = loopDate,
                        start = 9,
                        end = 10,
                        title = "Book Now"
                    };

                    eventList.Add(ev12);

                    Event ev13 = new Event()
                    {
                        date = loopDate,
                        start = 11,
                        end = 12,
                        title = "Book Now"
                    };

                    eventList.Add(ev13);

                    Event ev14 = new Event()
                    {
                        date = loopDate,
                        start = 13,
                        end = 15,
                        title = "Book Now"
                    };

                    eventList.Add(ev14);

                    Event ev15 = new Event()
                    {
                        date = loopDate,
                        start = 14,
                        end = 15,
                        title = "Book Now"
                    };

                    eventList.Add(ev15);
                }
                    
                loopDate = loopDate.AddDays(1);

            } while (loopDate <= currentDate.AddDays(21));

            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}