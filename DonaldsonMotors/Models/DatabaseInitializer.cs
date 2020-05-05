using DonaldsonMotors.Models.Objects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DonaldsonMotors.Models
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                //role manager allows us to create roles and store them in the DB
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                //if role does not exist/ Create
                if (!roleManager.RoleExists("General Manager"))
                {
                    roleManager.Create(new IdentityRole("General Manager"));
                }

                //if role does not exist/ Create
                if (!roleManager.RoleExists("Mechanic"))
                {
                    roleManager.Create(new IdentityRole("Mechanic"));
                }

                //if role does not exist/ Create
                if (!roleManager.RoleExists("Clerk"))
                {
                    roleManager.Create(new IdentityRole("Clerk"));
                }

                //if role does not exist/ Create
                if (!roleManager.RoleExists("Stock Manager"))
                {
                    roleManager.Create(new IdentityRole("Stock Manager"));
                }

                //save DB
                context.SaveChanges();

                //user manager allows us to create Users and store them in the DB
                UserManager<User> userManager = new UserManager<User>(new UserStore<User>(context));

                //Create Default GM if does not exist

                var GM = new Staff()
                {
                    //generic user props
                    UserName = "generalmanager@donaldsonmotors.com",
                    Email = "generalmanager@donaldsonmotors.com",
                    FirstName = "General",
                    LastName = "Manager",
                    Street = "12 New Street",
                    City = "Glasgow",
                    PostCode = "G14 6GS",

                    //staff props
                    HighestQualification = "",
                    EmergencyContactName =  "Batman",
                    EmergencyContactNumber = "08001111",
                    NationalInsuranceNumber = "NI 21 33 A",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-1200),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(GM, "lambo123");

                //add the user to their role
                userManager.AddToRole(GM.Id, "General Manager");

                //save DB
                context.SaveChanges();

                //Create a few Staff if they do not exist

                var StockManager = new Staff()
                {
                    //generic user props
                    UserName = "stockmanager@donaldsonmotors.com",
                    Email = "stockmanager@donaldsonmotors.com",
                    FirstName = "Stock",
                    LastName = "Manager",
                    Street = "12 New Street",
                    City = "Glasgow",
                    PostCode = "G14 6GS",

                    //staff props
                    HighestQualification = "",
                    EmergencyContactName = "SpiderMan",
                    EmergencyContactNumber = "08001111",
                    NationalInsuranceNumber = "NI 24 34 J",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-1200),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(StockManager, "HummerBoy");

                //add the user to their role
                userManager.AddToRole(StockManager.Id, "Stock Manager");

                var Clerk = new Staff()
                {
                    //generic user props
                    UserName = "clerk@donaldsonmotors.com",
                    Email = "clerk@donaldsonmotors.com",
                    FirstName = "Peyton",
                    LastName = "Sawyer",
                    Street = "332 Long Street",
                    City = "Glasgow",
                    PostCode = "G35 9YR",

                    //staff props
                    HighestQualification = "",
                    EmergencyContactName = "Superman",
                    EmergencyContactNumber = "08001111",
                    NationalInsuranceNumber = "NX 32 12 D",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-1100),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(GM, "mini123");

                //add the user to their role
                userManager.AddToRole(GM.Id, "Clerk");

                //save DB
                context.SaveChanges();

                //add mechanics

                var Mech1 = new Staff()
                {
                    //generic user props
                    UserName = "mech1@donaldsonmotors.com",
                    Email = "mech1@donaldsonmotors.com",
                    FirstName = "Fred",
                    LastName = "West",
                    Street = "99 Love Street",
                    City = "Paisley",
                    PostCode = "PA3 2FF",

                    //staff props
                    HighestQualification = "HND Mechanics",
                    EmergencyContactName = "Susan",
                    EmergencyContactNumber = "01418894322",
                    NationalInsuranceNumber = "NE 21 33 S",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-1200),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(Mech1, "password1");

                //add the user to their role
                userManager.AddToRole(Mech1.Id, "Mechanic");

                var Mech2 = new Staff()
                {
                    //generic user props
                    UserName = "mech2@donaldsonmotors.com",
                    Email = "mech2@donaldsonmotors.com",
                    FirstName = "Bert",
                    LastName = "Zebra",
                    Street = "33 Green Street",
                    City = "Greenock",
                    PostCode = "ML3 4RE",

                    //staff props
                    HighestQualification = "HND Mechanics",
                    EmergencyContactName = "Susan",
                    EmergencyContactNumber = "01418894322",
                    NationalInsuranceNumber = "NE 21 33 S",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-1200),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(Mech2, "password1");

                //add the user to their role
                userManager.AddToRole(Mech2.Id, "Mechanic");
                //Create a few Members if they do not exist

                var Mech3 = new Staff()
                {
                    //generic user props
                    UserName = "mech3@donaldsonmotors.com",
                    Email = "mech3@donaldsonmotors.com",
                    FirstName = "Scott",
                    LastName = "Montgomery",
                    Street = "35 Craigpark Drive",
                    City = "Glasgow",
                    PostCode = "G42 2QX",

                    //staff props
                    HighestQualification = "HND Mechanics",
                    EmergencyContactName = "Susan",
                    EmergencyContactNumber = "01418894322",
                    NationalInsuranceNumber = "NE 21 33 S",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-600),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(Mech3, "password1");

                //add the user to their role
                userManager.AddToRole(Mech3.Id, "Mechanic");

                var Mech4 = new Staff()
                {
                    //generic user props
                    UserName = "mech4@donaldsonmotors.com",
                    Email = "mech4@donaldsonmotors.com",
                    FirstName = "Craig",
                    LastName = "Purdie",
                    Street = "27 Mossvale Drive",
                    City = "Glasgow",
                    PostCode = "G45 2FG",

                    //staff props
                    HighestQualification = "HND Mechanics",
                    EmergencyContactName = "Susan",
                    EmergencyContactNumber = "01418894322",
                    NationalInsuranceNumber = "NE 21 33 S",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-543),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(Mech4, "password1");

                //add the user to their role
                userManager.AddToRole(Mech4.Id, "Mechanic");

                var Mech5 = new Staff()
                {
                    //generic user props
                    UserName = "mech5@donaldsonmotors.com",
                    Email = "mech5@donaldsonmotors.com",
                    FirstName = "George",
                    LastName = "Best",
                    Street = "450 White Street",
                    City = "Glasgow",
                    PostCode = "G44 1XZ",

                    //staff props
                    HighestQualification = "HND Mechanics",
                    EmergencyContactName = "Susan",
                    EmergencyContactNumber = "01418894322",
                    NationalInsuranceNumber = "NE 21 33 S",
                    ContractType = ContractType.FullTime,
                    ContractStartDate = DateTime.Now.AddDays(-321),
                    ContractEndDate = null
                };

                //add the hashed password to the user
                userManager.Create(Mech5, "password1");

                //add the user to their role
                userManager.AddToRole(Mech5.Id, "Mechanic");

                context.SaveChanges();

                //make a few customers

                var cust1 = new Customer()
                {
                    //generic user props
                    UserName = "FredEast@gmail.com",
                    Email = "FredEast@gmail.com",
                    FirstName = "Fred",
                    LastName = "East",
                    Street = "",
                    City = "",
                    PostCode = "",

                    //customer props
                    CustomerType = CustomerType.General
                    
                };

                //add the hashed password to the user
                userManager.Create(cust1, "password123");

                var cust2 = new Customer()
                {
                    //generic user props
                    UserName = "MaryAnderson@gmail.com",
                    Email = "MaryAnderson@gmail.com",
                    FirstName = "Mary",
                    LastName = "Anderson",
                    Street = "5 Vine Street",
                    City = "Glasgow",
                    PostCode = "G87 8DD",

                    //customer props
                    CustomerType = CustomerType.Corporate

                };

                //add the hashed password to the user
                userManager.Create(cust2, "password123");

                //add the user to their role
                userManager.AddToRole(cust2.Id, "Member");

                //save DB
                context.SaveChanges();
            }


        }
    }
}