using DonaldsonMotors.Models;
using DonaldsonMotors.Models.Actors;
using DonaldsonMotors.Models.SystemParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
            var slots = GetSlotsList().ToList();

            return View(slots);
        }

        public ActionResult SelectVehicle(DateTime date)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Vehicle> OwnedVehicles = new List<Vehicle>();

            string id = User.Identity.GetUserId();

            OwnedVehicles = context.Vehicles.Where(v => v.Id == id).ToList();

            Session["Date"] = date;

            return View(OwnedVehicles);
        }

        [HttpGet]
        public ActionResult BookNow()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BookNow(Booking model)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Booking bookingCon = new Booking
            {
                BookingDate = model.BookingDate,
                ServiceType = model.ServiceType
                
            };


            return RedirectToAction("BookingConfirm", new { booking = bookingCon });
        }










        public List<Slot> GetSlotsList()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Slot> slots = new List<Slot>();

            List<Booking> bookings = context.Bookings.ToList();

            var currentDate = DateTime.Now;
            var loopDate = currentDate;

            while(loopDate < currentDate.AddDays(21))
            {
                int counter = 0;

                foreach(Booking b in bookings)
                {
                    if (b.BookingDate == loopDate)
                    {
                        Slot e = new Slot()
                        {
                            date = b.BookingDate,
                            start = b.BookingDate.Hour,
                            end = b.BookingDate.Hour + 1,
                            desc = "Unavailable"
                        };

                        slots.Add(e);

                        counter = counter + 1;
                    }
                }

                if (counter < 4)
                {
                    foreach (Slot s in slots)
                    {
                        if (s.date == loopDate)
                        {
                            if (s.date.Hour == 9)
                            {
                                Slot ev = new Slot()
                                {
                                    date = s.date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                slots.Add(ev);

                                Slot ev1 = new Slot()
                                {
                                    date = s.date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                slots.Add(ev1);

                                Slot ev2 = new Slot()
                                {
                                    date = s.date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                slots.Add(ev2);
                            }
                            else if (s.date.Hour == 11)
                            {
                                Slot ev3 = new Slot()
                                {
                                    date = s.date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                slots.Add(ev3);

                                Slot ev4 = new Slot()
                                {
                                    date = s.date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                slots.Add(ev4);

                                Slot ev5 = new Slot()
                                {
                                    date = s.date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                slots.Add(ev5);
                            }
                            else if (s.date.Hour == 13)
                            {
                                Slot ev6 = new Slot()
                                {
                                    date = s.date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                slots.Add(ev6);

                                Slot ev7 = new Slot()
                                {
                                    date = s.date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                slots.Add(ev7);

                                Slot ev8 = new Slot()
                                {
                                    date = s.date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                slots.Add(ev8);
                            }
                            else if (s.date.Hour == 15)
                            {
                                Slot ev9 = new Slot()
                                {
                                    date = s.date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                slots.Add(ev9);

                                Slot ev10 = new Slot()
                                {
                                    date = s.date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                slots.Add(ev10);

                                Slot ev11 = new Slot()
                                {
                                    date = s.date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                slots.Add(ev11);
                            }
                        }
                    }
                }

                if (counter == 0)
                {
                    Slot ev12 = new Slot()
                    {
                        date = loopDate,
                        start = 9,
                        end = 10,
                        desc = "Book Now"
                    };

                    slots.Add(ev12);

                    Slot ev13 = new Slot()
                    {
                        date = loopDate,
                        start = 11,
                        end = 12,
                        desc = "Book Now"
                    };

                    slots.Add(ev13);

                    Slot ev14 = new Slot()
                    {
                        date = loopDate,
                        start = 13,
                        end = 14,
                        desc = "Book Now"
                    };

                    slots.Add(ev14);

                    Slot ev15 = new Slot()
                    {
                        date = loopDate,
                        start = 15,
                        end = 16,
                        desc = "Book Now"
                    };

                    slots.Add(ev15);
                }

                loopDate = loopDate.AddDays(1);

            }

            return slots;
        }
    }
}
