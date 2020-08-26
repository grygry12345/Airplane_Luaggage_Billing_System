using AirplaneLuggageBilling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneLuggageBilling.Controllers
{
    public class adminController : Controller
    {
        LugageBillingEntities db = new LugageBillingEntities();

        // Main Page
        public ActionResult Main()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // Login Page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (LuggageUsersEntities db = new LuggageUsersEntities())
                {
                    var obj = db.UserProfile.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Main");
                    }
                }
            }
            return View(objUser);
        }

        // List All Teller Employers with CRUD Operations
        // Read Teller
        public ActionResult Teller()
        {
            var teller = from ce in db.Company_Employee
                         join t in db.Teller on ce.coEmId equals t.coEmId
                         where ce.coEmId > 0 & t.tellerId > 0 & ce.employeeType.Contains("Teller")
                         select ce;

            return View(teller);
        }

        // Create Teller
        public ActionResult AddTeller()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddTeller(Company_Employee company_Employee, Teller teller)
        {
            company_Employee.employeeType = "Teller";
            db.Company_Employee.Add(company_Employee);
            db.Teller.Add(teller);
            teller.coEmId = company_Employee.coEmId;
            db.SaveChanges();
            return RedirectToAction("Teller");
        }

        // Update Teller
        public ActionResult UpdateTeller(int tellerId)
        {
            var teller = db.Company_Employee.Find(tellerId);

            return View(teller);
        }

        [HttpPost]
        public ActionResult UpdateTeller(Company_Employee teller)
        {
            Company_Employee updatedTeller = db.Company_Employee.Where(x => x.coEmId == teller.coEmId).FirstOrDefault();
            updatedTeller.FName = teller.FName;
            updatedTeller.MName = teller.MName;
            updatedTeller.LName = teller.LName;
            updatedTeller.BDate = teller.BDate;
            updatedTeller.Address = teller.Address;
            updatedTeller.Salary = teller.Salary;
            updatedTeller.Sex = teller.Sex;
            updatedTeller.AirCompanyName = teller.AirCompanyName;
            updatedTeller.AirPortName = teller.AirPortName;
            db.SaveChanges();
            return RedirectToAction("Teller");

        }

        // Delete Teller
        public ActionResult DeleteTeller(int? coEmId)
        {
            var teller = db.Company_Employee.Find(coEmId);

            return View(teller);
        }
        public RedirectToRouteResult DeleteFromList(int? coEmId)
        {
            db.Company_Employee.RemoveRange(db.Company_Employee.Where(x => x.coEmId == coEmId));
            db.Teller.RemoveRange(db.Teller.Where(x => x.coEmId == coEmId));
            db.SaveChanges();
            return RedirectToAction("Teller");
        }

        // List All Pilot Employers with CRUD Operations
        public ActionResult Pilot()
        {
            var pilot = from ce in db.Company_Employee
                        join p in db.Pilot on ce.coEmId equals p.coEmId
                        where ce.coEmId > 0 & p.pilotId > 0 & ce.employeeType.Contains("Pilot")
                        select ce;

            return View(pilot);
        }

        // Add Pilot
        public ActionResult AddPilot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPilot(Company_Employee company_Employee, Pilot pilot)
        {
            company_Employee.employeeType = "Pilot";
            db.Company_Employee.Add(company_Employee);
            db.Pilot.Add(pilot);
            pilot.coEmId = company_Employee.coEmId;
            db.SaveChanges();
            return RedirectToAction("Pilot");
        }

        // Update Pilot
        public ActionResult UpdatePilot(int pilotId)
        {
            var pilot = db.Company_Employee.Find(pilotId);

            return View(pilot);
        }

        [HttpPost]
        public ActionResult UpdatePilot(Company_Employee pilot)
        {
            Company_Employee updatedTeller = db.Company_Employee.Where(x => x.coEmId == pilot.coEmId).FirstOrDefault();
            updatedTeller.FName = pilot.FName;
            updatedTeller.MName = pilot.MName;
            updatedTeller.LName = pilot.LName;
            updatedTeller.BDate = pilot.BDate;
            updatedTeller.Address = pilot.Address;
            updatedTeller.Salary = pilot.Salary;
            updatedTeller.Sex = pilot.Sex;
            updatedTeller.AirCompanyName = pilot.AirCompanyName;
            updatedTeller.AirPortName = pilot.AirPortName;
            db.SaveChanges();
            return RedirectToAction("Pilot");
        }

        // Delete Pilot
        public ActionResult DeletePilot(int? coEmId)
        {
            var pilot = db.Company_Employee.Find(coEmId);

            return View(pilot);
        }
        public RedirectToRouteResult DeletePilotFromList(int? coEmId)
        {
            db.Company_Employee.RemoveRange(db.Company_Employee.Where(x => x.coEmId == coEmId));
            db.Pilot.RemoveRange(db.Pilot.Where(x => x.coEmId == coEmId));
            db.SaveChanges();
            return RedirectToAction("Pilot");
        }

        // List All Transporter Employers with CRUD Operations
        public ActionResult Transporter()
        {
            var tranporter = from ae in db.Airport_Employee
                             join t in db.Transporter on ae.airEmId equals t.airEmId
                             where ae.airEmId > 0 & t.transporterId > 0 & ae.employeeType.Contains("Transporter")
                             select ae;

            return View(tranporter);
        }

        //Add Transporter
        public ActionResult AddTransporter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTransporter(Airport_Employee airport_Employee, Transporter transporter)
        {
            airport_Employee.employeeType = "Transporter";
            db.Airport_Employee.Add(airport_Employee);
            db.Transporter.Add(transporter);
            transporter.airEmId = airport_Employee.airEmId;
            db.SaveChanges();
            return RedirectToAction("Transporter");
        }

        // Update Transporter
        public ActionResult UpdateTransporter(int transporterId)
        {
            var transporter = db.Airport_Employee.Find(transporterId);

            return View(transporter);
        }

        [HttpPost]
        public ActionResult UpdateTransporter(Airport_Employee transporter)
        {
            Airport_Employee updatedTransporter = db.Airport_Employee.Where(x => x.airEmId == transporter.airEmId).FirstOrDefault();
            updatedTransporter.FName = transporter.FName;
            updatedTransporter.MName = transporter.MName;
            updatedTransporter.LName = transporter.LName;
            updatedTransporter.BDate = transporter.BDate;
            updatedTransporter.Address = transporter.Address;
            updatedTransporter.Salary = transporter.Salary;
            updatedTransporter.Sex = transporter.Sex;
            updatedTransporter.AirportName = transporter.AirportName;
            db.SaveChanges();
            return RedirectToAction("Transporter");
        }

        // Delete Transporter
        public ActionResult DeleteTransporter(int? airEmId)
        {
            var transporter = db.Airport_Employee.Find(airEmId);

            return View(transporter);
        }
        public RedirectToRouteResult DeleteTransporterFromList(int? airEmId)
        {
            db.Airport_Employee.RemoveRange(db.Airport_Employee.Where(x => x.airEmId == airEmId));
            db.Transporter.RemoveRange(db.Transporter.Where(x => x.airEmId == airEmId));
            db.SaveChanges();
            return RedirectToAction("Transporter");
        }

        // List All Security Employers with CRUD Operations
        public ActionResult Security()
        {
            var security = from ae in db.Airport_Employee
                             join s in db.Security on ae.airEmId equals s.airEmId
                             where ae.airEmId > 0 & s.SecurityId > 0 & ae.employeeType.Contains("Security")
                             select ae;

            return View(security);
        }

        //Add Security
        public ActionResult AddSecurity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSecurity(Airport_Employee airport_Employee, Security security)
        {
            airport_Employee.employeeType = "Security";
            db.Airport_Employee.Add(airport_Employee);
            db.Security.Add(security);
            security.airEmId = airport_Employee.airEmId;
            db.SaveChanges();
            return RedirectToAction("Security");
        }

        // Update Security
        public ActionResult UpdateSecurity(int securityId)
        {
            var security = db.Airport_Employee.Find(securityId);

            return View(security);
        }

        [HttpPost]
        public ActionResult UpdateSecurity(Airport_Employee security)
        {
            Airport_Employee updatedSecurity = db.Airport_Employee.Where(x => x.airEmId == security.airEmId).FirstOrDefault();
            updatedSecurity.FName = security.FName;
            updatedSecurity.MName = security.MName;
            updatedSecurity.LName = security.LName;
            updatedSecurity.BDate = security.BDate;
            updatedSecurity.Address = security.Address;
            updatedSecurity.Salary = security.Salary;
            updatedSecurity.Sex = security.Sex;
            updatedSecurity.AirportName = security.AirportName;
            db.SaveChanges();
            return RedirectToAction("Transporter");
        }

        // Delete Security
        public ActionResult DeleteSecurity(int? airEmId)
        {
            var security = db.Airport_Employee.Find(airEmId);

            return View(security);
        }
        public RedirectToRouteResult DeleteSecurityFromList(int? airEmId)
        {
            db.Airport_Employee.RemoveRange(db.Airport_Employee.Where(x => x.airEmId == airEmId));
            db.Security.RemoveRange(db.Security.Where(x => x.airEmId == airEmId));
            db.SaveChanges();
            return RedirectToAction("Security");
        }


        // Passangers with details and crud operations
        public ActionResult Passangers()
        {
            var passanager = db.Passanger.Where(s => s.passangerId > 0).Select(s => s);

            return View(passanager);
        }

        // Details Pasangers
        public ActionResult DetailsPassanger(int passangerId)
        {
            var passanger = db.Passanger.Where(s => s.passangerId == passangerId).Select(s => s);

            return View(passanger);
        }

        // Add Passanger
        public ActionResult AddPassanger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPassanger(Passanger passanger)
        {
            db.Passanger.Add(passanger);
           
            db.SaveChanges();
            return RedirectToAction("Passangers");
        }

        // Update Passanger
        public ActionResult UpdatePassanger(int passangerId)
        {
            var passanger = db.Passanger.Find(passangerId);

            return View(passanger);
        }

        [HttpPost]
        public ActionResult UpdatePassanger(Passanger passanger)
        {
            Passanger updatedPassanger = db.Passanger.Where(x => x.passangerId == passanger.passangerId).FirstOrDefault();

            updatedPassanger.FName = passanger.FName;
            updatedPassanger.MName = passanger.MName;
            updatedPassanger.LName = passanger.LName;
            updatedPassanger.address = passanger.address;
            updatedPassanger.bDate = passanger.bDate;
            updatedPassanger.sex = passanger.sex;
            updatedPassanger.isOkay = passanger.isOkay;
            updatedPassanger.isTicketOkay = passanger.isTicketOkay;

            db.SaveChanges();
            return RedirectToAction("Passangers");
        }

        // Delete Passanger
        public ActionResult DeletePassanger(int passangerid)
        {
            var passanger = db.Passanger.Find(passangerid);

            return View(passanger);
        }

        public RedirectToRouteResult DeletePassangerFromList(int passangerId)
        {
            db.Passanger.RemoveRange(db.Passanger.Where(x => x.passangerId == passangerId));
            if (db.Luggage.Where(l => l.passangerId == passangerId).Count() > 0)
            {
                db.Luggage.RemoveRange(db.Luggage.Where(p => p.passangerId == passangerId));
            }
            if (db.Ticket.Where(t => t.passangerId == passangerId).Count() > 0)
            {
                db.Ticket.RemoveRange(db.Ticket.Where(p => p.passangerId == passangerId));
            }
            db.SaveChanges();
            return RedirectToAction("Passangers");
        }



        // Luggage with details and crud operations
        public ActionResult AddLuggage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLuggage(Luggage luggage, int passangerId)
        {
            db.Luggage.Add(luggage);
            db.SaveChanges();
            return RedirectToAction("Passangers");
        }

        

        // Update Luggage
        public ActionResult UpdateLuggage(int luggageId, int? passangerId)
        {
            var luggage = db.Luggage.Find(luggageId);
            return View(luggage);
        }

        [HttpPost]
        public ActionResult UpdateLuggage(Luggage luggage)
        {
            Luggage updatedLuggage = db.Luggage.Where(x => x.lugageId == luggage.lugageId).FirstOrDefault();

            updatedLuggage.weight = luggage.weight;
            updatedLuggage.isSafe = luggage.isSafe;
            updatedLuggage.isBaggageClaim = luggage.isBaggageClaim;
            updatedLuggage.passangerId = luggage.passangerId;
            db.SaveChanges();
            return RedirectToAction("DetailsPassanger");
        }

        //Delete Luggage
        public ActionResult DeleteLuggage(int luggageid)
        {
            var luggage = db.Luggage.Find(luggageid);

            return View(luggage);
        }

        public RedirectToRouteResult DeleteLuggageFromList(int luggageid)
        {
            db.Luggage.RemoveRange(db.Luggage.Where(x => x.lugageId == luggageid));
            db.Luggage_Color.RemoveRange(db.Luggage_Color.Where(x => x.luggageId == luggageid));
            db.SaveChanges();

            return RedirectToAction("PassangerDetails");
        }

    }
}