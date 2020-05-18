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
using DonaldsonMotors.Extensions;


//Name: Neil Hunter
//Project: DonaldsonMototrs
//Date : 18/05/20

namespace DonaldsonMotors.Controllers
{
    public class BookingController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Booking
        
        /// <summary>
        /// a view to see a available timeslots
        /// </summary>
        /// <returns>a view populated with available times</returns>
        public ActionResult CheckAvalability()
        {
             var slots = GetSlotsList().ToList();

             return View(slots);
            
        }

        /// <summary>
        /// a view to select a car
        /// </summary>
        /// <param name="date">the choosen timeslot date</param>
        /// <returns>a view populated with the customers vehicles</returns>
        public ActionResult SelectVehicle(DateTime date)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {

                List<Vehicle> OwnedVehicles = new List<Vehicle>();

                string id = User.Identity.GetUserId();

                OwnedVehicles = context.Vehicles.Where(v => v.Id == id).Include(v => v.Customer).ToList();

                Session["Date"] = date;

                return View(OwnedVehicles);
            }
        }

        /// <summary>
        /// a view to select a service required
        /// </summary>
        /// <param name="id">the choosen vehicles id</param>
        /// <returns>a view to be populated</returns>
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

        /// <summary>
        /// an action to create the booking
        /// </summary>
        /// <param name="model">the booking</param>
        /// <returns>redirect to confrimation</returns>
        [HttpPost]
        public ActionResult BookNow(Booking model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                string id = User.Identity.GetUserId();
                Vehicle veh = (Vehicle)Session["Vehicle"];
                string reg = veh.Registration;

                Customer customer = (Customer)context.Users.Find(id);

                Booking bookingCon = model;

                bookingCon.ServiceType = model.ServiceType;
                bookingCon.ServiceNote = model.ServiceNote;
                bookingCon.Vehicle = veh;
                bookingCon.Registration = reg;
                bookingCon.BookingDate = (DateTime)Session["Date"];
                bookingCon.CustId = id;
                bookingCon.Customer = customer;
                bookingCon.PartsUsed = new List<PartUsed>();


                if (model.ServiceType == ServiceType.MOT)
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

                return RedirectToAction("BookingConfirm", bookingCon);
            }
        }

        /// <summary>
        /// a view to see the booking before confirming
        /// </summary>
        /// <param name="booking"> the complete booking</param>
        /// <returns>the view</returns>
        [HttpGet]
        public ActionResult BookingConfirm(Booking booking)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                return View(booking);
            }
        }

        /// <summary>
        /// an action to add the booking to db
        /// </summary>
        /// <param name="model">the booking</param>
        /// <param name="id">n/a</param>
        /// <returns>redirects to home</returns>
        [HttpPost]
        public ActionResult BookingConfirm(Booking model, int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }
            else
            {
                Booking booking = model;

                List<Booking> activeBookings = context.Bookings.Where(b => b.Complete == false).Include(b => b.Staff).ToList();

                List<Staff> unavalStaff = new List<Staff>();

                foreach (Booking b in activeBookings)
                {
                    if (b.BookingDate == booking.BookingDate)
                    {
                        unavalStaff.Add(b.Staff);
                    }
                }

                List<Staff> avalStaff = context.Users.OfType<Staff>().Except(unavalStaff).Include(s => s.Jobs).ToList();

                booking.Staff = avalStaff.First();
                booking.StaffId = avalStaff.First().Id;

                //booking.Staff = (Staff)context.Users.Find(booking.StaffId);

                //Staff staff = booking.Staff;
                Customer customer = context.Users.OfType<Customer>().Where(c => c.Id == booking.CustId).Include(c => c.Bookings).First();
                Vehicle vehicle = context.Vehicles.Where(v => v.Registration == booking.Registration).Include(v => v.ServiceHistory).First();

                //staff.Jobs.Add(booking);
                //customer.Bookings.Add(booking);
                //vehicle.ServiceHistory.Add(booking);

                booking.Customer = customer;
                booking.Vehicle = vehicle;
                booking.CancelationReason = "";


                List<Booking> allBookings = context.Bookings.ToList();

                if (allBookings.Count > 0)
                {
                    booking.BookingId = allBookings.Count + 1;
                }
                else
                {
                    booking.BookingId = 1;
                }

                context.Bookings.Add(booking);

                context.SaveChanges();

                this.AddNotification("Booking Made for " + booking.BookingDate.ToString(), NotificationType.SUCCESS);

                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// a method to get a list of avaiable times
        /// </summary>
        /// <returns>list of available times</returns>
        public List<Slot> GetSlotsList()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<Slot> slots = new List<Slot>();

            List<Booking> bookings = context.Bookings.ToList();

            var currentDate = DateTime.Now;
            var loopDate = currentDate;

            while (loopDate < currentDate.AddDays(21))
            {
                int counter = 0;

                foreach (Booking b in bookings)
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
                    List<Slot> freeSlots = new List<Slot>();

                    foreach (Slot s in slots)
                    {
                        if (s.date.Date == loopDate.Date)
                        {
                            if (s.start == 9)
                            {
                                Slot ev = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev);

                                Slot ev1 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev1);

                                Slot ev2 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev2);
                            }
                            else if (s.start == 11)
                            {
                                Slot ev3 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev3);

                                Slot ev4 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev4);

                                Slot ev5 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev5);
                            }
                            else if (s.start == 13)
                            {
                                Slot ev6 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev6);

                                Slot ev7 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev7);

                                Slot ev8 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 15,
                                    end = 16,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev8);
                            }
                            else if (s.start == 15)
                            {
                                Slot ev9 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 9,
                                    end = 10,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev9);

                                Slot ev10 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 11,
                                    end = 12,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev10);

                                Slot ev11 = new Slot()
                                {
                                    date = s.date.Date,
                                    start = 13,
                                    end = 14,
                                    desc = "Book Now"
                                };

                                freeSlots.Add(ev11);
                            }
                        }
                    }

                    slots = slots.Union(freeSlots).ToList();

                }

                if (counter == 0)
                {
                    Slot ev12 = new Slot()
                    {
                        date = loopDate.Date,
                        start = 9,
                        end = 10,
                        desc = "Book Now"
                    };

                    slots.Add(ev12);

                    Slot ev13 = new Slot()
                    {
                        date = loopDate.Date,
                        start = 11,
                        end = 12,
                        desc = "Book Now"
                    };

                    slots.Add(ev13);

                    Slot ev14 = new Slot()
                    {
                        date = loopDate.Date,
                        start = 13,
                        end = 14,
                        desc = "Book Now"
                    };

                    slots.Add(ev14);

                    Slot ev15 = new Slot()
                    {
                        date = loopDate.Date,
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
