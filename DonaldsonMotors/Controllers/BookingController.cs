using DonaldsonMotors.Models;
using DonaldsonMotors.Models.Actors;
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
    public class BookingController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                ApplicationDbContext context = new ApplicationDbContext();

                List<Vehicle> OwnedVehicles = new List<Vehicle>();

                string id = User.Identity.GetUserId();

                OwnedVehicles = context.Vehicles.Where(v => v.Id == id).ToList();

                Session["Date"] = date;

                return View(OwnedVehicles);
            }
        }

        [HttpGet]
        public ActionResult BookNow(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {

                Session["Vehicle"] = context.Vehicles.Find(id);

                return View();
            }
        }

        [HttpPost]
        public ActionResult BookNow(Booking model)
        {

            string id = User.Identity.GetUserId();
            Vehicle veh = (Vehicle)Session["Vehicle"];
            string reg = veh.Registration;

            Customer customer = (Customer)context.Users.Find(id);

            Booking bookingCon = new Booking
            {
                ServiceType = model.ServiceType,
                ServiceNote = model.ServiceNote,
                Vehicle = veh,
                Registration = reg,
                BookingDate = (DateTime)Session["Date"],
                CustId = id,
                Customer = customer,
                PartsUsed = new List<PartUsed>()
            };

            if(model.ServiceType == ServiceType.MOT)
            {
                bookingCon.EstimatedCost = 20;
                bookingCon.Deposit = 5;
            }

            if (model.ServiceType == ServiceType.OilChange)
            {
                bookingCon.EstimatedCost = 20;
                bookingCon.Deposit = 5;
            }

            if (model.ServiceType == ServiceType.TyreChange)
            {
                bookingCon.EstimatedCost = 120;
                bookingCon.Deposit = 20;
            }

            if (model.ServiceType == ServiceType.Repair)
            {
                bookingCon.EstimatedCost = 200;
                bookingCon.Deposit = 30;
            }


            Session["Booking"] = bookingCon;

            return RedirectToAction("BookingConfirm");
        }

        [HttpGet]
        public ActionResult BookingConfirm()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                Booking booking = (Booking)Session["Booking"];

                return View(booking);
            }
        }

        [HttpPost]
        public ActionResult BookingConfirm(Booking model)
        {
       
            Booking booking = (Booking)Session["Booking"];

            List<Booking> activeBookings = context.Bookings.Where(b => b.Complete == false).Include(b => b.Staff).ToList();

            List<Staff> unavalStaff = new List<Staff>();

            foreach(Booking b in activeBookings)
            {
                if(b.BookingDate == booking.BookingDate)
                {
                    unavalStaff.Add(b.Staff);
                }          
            }

            List<Staff> avalStaff = context.Users.OfType<Staff>().Except(unavalStaff).Include(s => s.Jobs).ToList();

            booking.Staff = avalStaff.First();
            booking.StaffId = avalStaff.First().Id;
            //booking.Staff = (Staff)context.Users.Find(booking.StaffId);

            //Staff staff = booking.Staff;
            //Customer customer = context.Users.OfType<Customer>().Where(c => c.Id == booking.CustId).Include(c => c.Bookings).First();
            //Vehicle vehicle = context.Vehicles.Where(v => v.Registration == booking.Registration).Include(v => v.ServiceHistory).First();

            //staff.Jobs.Add(booking);
            //customer.Bookings.Add(booking);
            //vehicle.ServiceHistory.Add(booking);

            context.Bookings.Add(booking);

            context.SaveChanges();

            return RedirectToAction("Index", "Home", null);
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
                    if (b.BookingDate.Date == loopDate.Date)
                    {
                        Slot e = new Slot()
                        {
                            date = b.BookingDate.Date,
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
                        if (s.date == loopDate.Date)
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
                            if (s.date.Hour == 11)
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
                            if (s.date.Hour == 13)
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
                            if (s.date.Hour == 15)
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
